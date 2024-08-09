using AutoMapper;
using MaxemusAPI;
using MaxemusAPI.Data;
using MaxemusAPI.Models;
using MaxemusAPI.Repository;
using MaxemusAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Amazon.S3;
using MaxemusAPI.Helpers;
using MaxemusAPI.IRepository;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MaxemusAPI.Firebase;
using MaxemusAPI.Repositories;
using ApplicationDbContext = MaxemusAPI.Data.ApplicationDbContext;
using Amazon.S3.Model;
using System.Net;
using MaxemusAPI.Models.Helper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.Features;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Configure FormOptions for file upload size limits
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 204857600; // 100 MB, for example
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;  // No requirement for digits
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;  // Required length is 6 characters
    options.Password.RequiredUniqueChars = 0;  // No requirement for unique characters
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});
// builder.Services.AddHostedService<MyBackgroundService>();

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<ITwilioManager, TwilioManager>();
builder.Services.Configure<Aws3Services>(builder.Configuration.GetSection("Aws3Services"));
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IContentRepository, ContentRepository>();
builder.Services.AddScoped<IUploadRepository, UploadRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
    // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddSingleton<IMobileMessagingClient, MobileMessagingClient>();

//Inject EmailSettings
builder.Services.AddOptions();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("GoogleAuthentication"));
builder.Services.AddSingleton<IEmailManager, EmailManager>();
builder.Services.Configure<SecurityStampValidatorOptions>(options =>
{
    options.ValidationInterval = TimeSpan.Zero; // Disable automatic security stamp validation
});
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // c.OperationFilter<AuthResponsesOperationFilter>();
    c.AddSecurityDefinition(
        "Bearer",
        new OpenApiSecurityScheme
        {
            Description =
                "JWT Authorization header using the Bearer scheme. \r\n\r\n "
                + "Enter your token in the text input below.\r\n\r\n"
                + "Example: \"12345abcdef\"",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http, //SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT"
        }
    );

    c.AddSecurityRequirement(
        new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        }
    );
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});
var key = builder.Configuration.GetValue<string>("ApiSettings:Secret");

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 300000000; // Increase limit to 30 MB
});

builder.Services
    .AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        x.Events = new JwtBearerEvents
        {
            OnTokenValidated = async context =>
            {
                var endpoint = context.HttpContext.GetEndpoint();

                // Check if the endpoint allows anonymous access
                var allowAnonymous = endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;

                if (!allowAnonymous)
                {
                    var userService = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();
                    var roleClaim = context.Principal.Claims.FirstOrDefault(claim => claim.Type == ClaimsIdentity.DefaultRoleClaimType)?.Value;

                    if (roleClaim == "Customer")
                    {
                        string securityStamp = context.Principal.Claims.FirstOrDefault(claim => claim.Type == "SecurityStamp")?.Value;
                        var userId = context.Principal.Claims.FirstOrDefault().Value.ToString();
                        var user = await userService.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();

                        if (user == null)
                        {
                            context.Fail("Unauthorized");
                            return;
                        }

                        // Perform additional checks
                        if (user.SecurityStamp != securityStamp && user.PhoneNumber.Length < 11)
                        {
                            context.Fail("Unauthorized");

                            var response = new
                            {
                                isSuccess = false,
                                statusCode = HttpStatusCode.Unauthorized,
                                messages = "Access denied. You are not authorized to perform this action."
                            };

                            var jsonResponse = JsonConvert.SerializeObject(response);

                            context.Response.ContentType = "application/json";
                            context.Response.StatusCode = 401;

                            await context.Response.WriteAsync(jsonResponse);

                            return;
                        }
                    }
                }
            }
        };

    });


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "MaxemusAPI v1");
    // options.RoutePrefix = "";
});

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
