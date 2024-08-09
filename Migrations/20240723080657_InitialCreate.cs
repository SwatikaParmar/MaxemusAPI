using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxemusAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeviceType",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DialCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePic",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Banner",
                columns: table => new
                {
                    BannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banner", x => x.BannerId);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    BrandImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "CompanyDetail",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Timing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuildingNameOrNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    WhatsappNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyDetail", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    ContactId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.ContactId);
                });

            migrationBuilder.CreateTable(
                name: "DashboardItem",
                columns: table => new
                {
                    DashboardItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardItem", x => x.DashboardItemId);
                });

            migrationBuilder.CreateTable(
                name: "DashboardVideo",
                columns: table => new
                {
                    DashboardVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardVideo", x => x.DashboardVideoId);
                });

            migrationBuilder.CreateTable(
                name: "DistributorOrder",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalMrp = table.Column<double>(type: "float", nullable: true),
                    TotalDiscountAmount = table.Column<double>(type: "float", nullable: true),
                    TotalSellingPrice = table.Column<double>(type: "float", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalProducts = table.Column<int>(type: "int", nullable: true),
                    CancelledBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentReceipt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributorOrder", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "LensVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    LensType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    MountType = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FocalLength = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MaxAperture = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FieldOfView = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IrisType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CloseFocusDistance = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DORIDistance = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LensVari__0EA2338479929D6B", x => x.VariantId);
                });

            migrationBuilder.CreateTable(
                name: "MainCategory",
                columns: table => new
                {
                    MainCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainCategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCategory", x => x.MainCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "OrderedPoduct",
                columns: table => new
                {
                    OrderedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    TotalMRP = table.Column<double>(type: "float", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: true),
                    ProductCount = table.Column<int>(type: "int", nullable: true),
                    ShippingCharges = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderedPoduct", x => x.OrderedProductId);
                });

            migrationBuilder.CreateTable(
                name: "PointDetail",
                columns: table => new
                {
                    PointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Points = table.Column<double>(type: "float", nullable: true),
                    RedeemedPoints = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ExpiryDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DealerProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointDetail", x => x.PointId);
                });

            migrationBuilder.CreateTable(
                name: "Points",
                columns: table => new
                {
                    PointId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ActivePoints = table.Column<double>(type: "float", nullable: true),
                    RedeemedPoints = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.PointId);
                });

            migrationBuilder.CreateTable(
                name: "PowerVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PowerSupply = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    PowerConsumption = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__PowerVar__0EA23384C9D39BF1", x => x.VariantId);
                });

            migrationBuilder.CreateTable(
                name: "RewardProduct",
                columns: table => new
                {
                    RewardProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MRP = table.Column<double>(type: "float", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    NeededPointToRedeem = table.Column<int>(type: "int", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardProduct", x => x.RewardProductId);
                });

            migrationBuilder.CreateTable(
                name: "SmartEvent",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    GeneralIVSAnalytics = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SmartEve__0EA2338408DBD89D", x => x.VariantId);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    UserDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "((0))"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.UserDetailId);
                });

            migrationBuilder.CreateTable(
                name: "UserOrder",
                columns: table => new
                {
                    OrderId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OrderStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PaymentStatus = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TotalMrp = table.Column<double>(type: "float", nullable: true),
                    TotalDiscountAmount = table.Column<double>(type: "float", nullable: true),
                    TotalSellingPrice = table.Column<double>(type: "float", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    DeliveredDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalProducts = table.Column<int>(type: "int", nullable: true),
                    CancelledBy = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentReceipt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrder", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "VideoVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    Compression = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SmartCodec = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VideoFrameRate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    StreamCapability = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Resolution = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    BitRateControl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    VideoBitRate = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DayNight = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BLC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    HLC = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    WDR = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    WhiteBalance = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    GainControl = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NoiseReduction = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MotionDetection = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RegionOfInterest = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    SmartIR = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ImageRotation = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Mirror = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PrivacyMasking = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoVariants", x => x.VariantId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategory",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubCategoryImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategory", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategory_MainCategory",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategory",
                        principalColumn: "MainCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "RedeemedProducts",
                columns: table => new
                {
                    ReedemProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardProductId = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: true),
                    ReedemedPoint = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedeemedProducts", x => x.ReedemProductId);
                    table.ForeignKey(
                        name: "FK_RedeemedProducts_RwardProduct",
                        column: x => x.RewardProductId,
                        principalTable: "RewardProduct",
                        principalColumn: "RewardProductId");
                });

            migrationBuilder.CreateTable(
                name: "ReedemProducts",
                columns: table => new
                {
                    ReedemProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardProductId = table.Column<int>(type: "int", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: true),
                    ReedemedPoint = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReedemProducts", x => x.ReedemProductId);
                    table.ForeignKey(
                        name: "FK_ReedemProducts_RewardProduct",
                        column: x => x.RewardProductId,
                        principalTable: "RewardProduct",
                        principalColumn: "RewardProductId");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image4 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image5 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalMRP = table.Column<double>(type: "float", nullable: false),
                    Discount = table.Column<double>(type: "float", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((1))"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    NeededPointToRedeem = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    DistributorDiscount = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    DistributorSellingPrice = table.Column<double>(type: "float", nullable: true, defaultValueSql: "((0))"),
                    DistributorDiscountType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Product_Brand",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Product_MainCategory",
                        column: x => x.MainCategoryId,
                        principalTable: "MainCategory",
                        principalColumn: "MainCategoryId");
                    table.ForeignKey(
                        name: "FK_Product_SubCategory",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategory",
                        principalColumn: "SubCategoryId");
                });

            migrationBuilder.CreateTable(
                name: "AccessoriesVariants",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    AccessoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Accessor__B40CC6CD9336DC1D", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_AccessoriesVariants_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "AudioVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    BuiltInMic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    AudioCompression = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AudioVar__0EA233844755CD2D", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_AudioVariants_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "CameraVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Appearance = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImageSensor = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    EffectivePixels = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ROM = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RAM = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ScanningSystem = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ElectronicShutterSpeed = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MinIllumination = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IRDistance = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IROnOffControl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IRLEDsNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PanTiltRotationRange = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraVariants", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_CameraVariants_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "CertificationVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Certifications = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Certific__0EA23384FA3F3D5A", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_CertificationVariants_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "DistributorOrderedProduct",
                columns: table => new
                {
                    OrderedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SellingPricePerItem = table.Column<double>(type: "float", nullable: true),
                    TotalMRP = table.Column<double>(type: "float", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: true),
                    ShippingCharges = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributorOrderedProduct", x => x.OrderedProductId);
                    table.ForeignKey(
                        name: "FK_DistributorOrderedProduct_DistributorOrder",
                        column: x => x.OrderId,
                        principalTable: "DistributorOrder",
                        principalColumn: "OrderId");
                    table.ForeignKey(
                        name: "FK_DistributorOrderedProduct_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "EnvironmentVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OperatingConditions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    StorageTemperature = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Protection = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Environm__0EA2338486D2E345", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_EnvironmentVariants_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "GeneralVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CasingMetalPlastic = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Dimensions = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NetWeight = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GrossWeight = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GeneralV__0EA233846EA8F05D", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_GeneralVariants_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "InstallationDocumentVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InstallationDocument = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallationDocumentVariants", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK__Installat__Produ__19AACF41",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "NetworkVariants",
                columns: table => new
                {
                    VariantId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Protocol = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Interoperability = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserHost = table.Column<int>(type: "int", nullable: true),
                    EdgeStorage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Browser = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ManagementSoftware = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NetworkV__0EA23384394CB684", x => x.VariantId);
                    table.ForeignKey(
                        name: "FK_NetworkVariants_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "ProductStock",
                columns: table => new
                {
                    ProductStockId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QRCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RewardPoint = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStock", x => x.ProductStockId);
                    table.ForeignKey(
                        name: "FK_ProductStock_ProductStock",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "UserManual",
                columns: table => new
                {
                    MannualId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    Mannual = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserManual", x => x.MannualId);
                    table.ForeignKey(
                        name: "FK__UserManua__Produ__6442E2C9",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "UserOrderedProduct",
                columns: table => new
                {
                    OrderedProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SellingPricePerItem = table.Column<double>(type: "float", nullable: true),
                    TotalMRP = table.Column<double>(type: "float", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    SellingPrice = table.Column<double>(type: "float", nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: true),
                    ShippingCharges = table.Column<double>(type: "float", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOrderedProduct", x => x.OrderedProductId);
                    table.ForeignKey(
                        name: "FK_UserOrderedProduct_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_UserOrderedProduct_UserOrder",
                        column: x => x.OrderId,
                        principalTable: "UserOrder",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateTable(
                name: "OrderedProductQR",
                columns: table => new
                {
                    ProductStockId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_OrderedProductQR_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_OrderedProductQR_ProductStock",
                        column: x => x.ProductStockId,
                        principalTable: "ProductStock",
                        principalColumn: "ProductStockId");
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    CartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    DistributorID = table.Column<int>(type: "int", nullable: true),
                    UserDetailId = table.Column<int>(type: "int", nullable: true),
                    ProductCountInCart = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__51BCD797CAAA79D2", x => x.CartID);
                    table.ForeignKey(
                        name: "FK_CartDetail_Product",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                });

            migrationBuilder.CreateTable(
                name: "DealerDetail",
                columns: table => new
                {
                    DealerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: true),
                    Address1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "((0))"),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DistributorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerDetail", x => x.DealerId);
                });

            migrationBuilder.CreateTable(
                name: "DealerProduct",
                columns: table => new
                {
                    DealerProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealerId = table.Column<int>(type: "int", nullable: false),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductStockId = table.Column<int>(type: "int", nullable: false),
                    RewardPoint = table.Column<int>(type: "int", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealerProduct", x => x.DealerProductId);
                    table.ForeignKey(
                        name: "FK_DealerProduct_DealerDetail",
                        column: x => x.DealerId,
                        principalTable: "DealerDetail",
                        principalColumn: "DealerId");
                    table.ForeignKey(
                        name: "FK_DealerProduct_Product",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_DealerProduct_ProductStock",
                        column: x => x.ProductStockId,
                        principalTable: "ProductStock",
                        principalColumn: "ProductStockId");
                });

            migrationBuilder.CreateTable(
                name: "DistributorAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    AddressType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BuildingNameOrNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Distribu__091C2AFB4B1E36ED", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_DistributorAddress_CountryMaster",
                        column: x => x.CountryId,
                        principalTable: "CountryMaster",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_DistributorAddress_StateMaster",
                        column: x => x.StateId,
                        principalTable: "StateMaster",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateTable(
                name: "DistributorDetail",
                columns: table => new
                {
                    DistributorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, defaultValueSql: "((0))"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    ModifyDate = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())"),
                    DistributorCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributorDetail", x => x.DistributorId);
                    table.ForeignKey(
                        name: "FK_DistributorDetail_DistributorAddress",
                        column: x => x.AddressId,
                        principalTable: "DistributorAddress",
                        principalColumn: "AddressId");
                });

            migrationBuilder.CreateTable(
                name: "OderAddress",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributorId = table.Column<int>(type: "int", nullable: false),
                    AddressType = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<int>(type: "int", nullable: true),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landmark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OderAddress", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_OderAddress_CountryMaster",
                        column: x => x.CountryId,
                        principalTable: "CountryMaster",
                        principalColumn: "CountryId");
                    table.ForeignKey(
                        name: "FK_OderAddress_DistributorDetail",
                        column: x => x.DistributorId,
                        principalTable: "DistributorDetail",
                        principalColumn: "DistributorId");
                    table.ForeignKey(
                        name: "FK_OderAddress_StateMaster",
                        column: x => x.StateId,
                        principalTable: "StateMaster",
                        principalColumn: "StateId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AudioVariants_ProductId",
                table: "AudioVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CameraVariants_ProductId",
                table: "CameraVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_DistributorID",
                table: "CartDetail",
                column: "DistributorID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_ProductID",
                table: "CartDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationVariants_ProductId",
                table: "CertificationVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerDetail_DistributorId",
                table: "DealerDetail",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerProduct_DealerId",
                table: "DealerProduct",
                column: "DealerId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerProduct_DistributorId",
                table: "DealerProduct",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerProduct_ProductId",
                table: "DealerProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DealerProduct_ProductStockId",
                table: "DealerProduct",
                column: "ProductStockId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorAddress_CountryId",
                table: "DistributorAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorAddress_DistributorId",
                table: "DistributorAddress",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorAddress_StateId",
                table: "DistributorAddress",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorDetail_AddressId",
                table: "DistributorDetail",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorOrderedProduct_OrderId",
                table: "DistributorOrderedProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributorOrderedProduct_ProductId",
                table: "DistributorOrderedProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_EnvironmentVariants_ProductId",
                table: "EnvironmentVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralVariants_ProductId",
                table: "GeneralVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InstallationDocumentVariants_ProductId",
                table: "InstallationDocumentVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkVariants_ProductId",
                table: "NetworkVariants",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OderAddress_CountryId",
                table: "OderAddress",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_OderAddress_DistributorId",
                table: "OderAddress",
                column: "DistributorId");

            migrationBuilder.CreateIndex(
                name: "IX_OderAddress_StateId",
                table: "OderAddress",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProductQR_ProductId",
                table: "OrderedProductQR",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderedProductQR_ProductStockId",
                table: "OrderedProductQR",
                column: "ProductStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_MainCategoryId",
                table: "Product",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SubCategoryId",
                table: "Product",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStock_ProductId",
                table: "ProductStock",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RedeemedProducts_RewardProductId",
                table: "RedeemedProducts",
                column: "RewardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ReedemProducts_RewardProductId",
                table: "ReedemProducts",
                column: "RewardProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategory_MainCategoryId",
                table: "SubCategory",
                column: "MainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserManual_ProductId",
                table: "UserManual",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderedProduct_OrderId",
                table: "UserOrderedProduct",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOrderedProduct_ProductId",
                table: "UserOrderedProduct",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartDetail_DistributorDetail",
                table: "CartDetail",
                column: "DistributorID",
                principalTable: "DistributorDetail",
                principalColumn: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerDetail_DistributorDetail",
                table: "DealerDetail",
                column: "DistributorId",
                principalTable: "DistributorDetail",
                principalColumn: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DealerProduct_DistributorDetail",
                table: "DealerProduct",
                column: "DistributorId",
                principalTable: "DistributorDetail",
                principalColumn: "DistributorId");

            migrationBuilder.AddForeignKey(
                name: "FK_DistributorAddress_DistributorDetail",
                table: "DistributorAddress",
                column: "DistributorId",
                principalTable: "DistributorDetail",
                principalColumn: "DistributorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DistributorAddress_DistributorDetail",
                table: "DistributorAddress");

            migrationBuilder.DropTable(
                name: "AccessoriesVariants");

            migrationBuilder.DropTable(
                name: "AudioVariants");

            migrationBuilder.DropTable(
                name: "Banner");

            migrationBuilder.DropTable(
                name: "CameraVariants");

            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "CertificationVariants");

            migrationBuilder.DropTable(
                name: "CompanyDetail");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "DashboardItem");

            migrationBuilder.DropTable(
                name: "DashboardVideo");

            migrationBuilder.DropTable(
                name: "DealerProduct");

            migrationBuilder.DropTable(
                name: "DistributorOrderedProduct");

            migrationBuilder.DropTable(
                name: "EnvironmentVariants");

            migrationBuilder.DropTable(
                name: "GeneralVariants");

            migrationBuilder.DropTable(
                name: "InstallationDocumentVariants");

            migrationBuilder.DropTable(
                name: "LensVariants");

            migrationBuilder.DropTable(
                name: "NetworkVariants");

            migrationBuilder.DropTable(
                name: "OderAddress");

            migrationBuilder.DropTable(
                name: "OrderedPoduct");

            migrationBuilder.DropTable(
                name: "OrderedProductQR");

            migrationBuilder.DropTable(
                name: "PointDetail");

            migrationBuilder.DropTable(
                name: "Points");

            migrationBuilder.DropTable(
                name: "PowerVariants");

            migrationBuilder.DropTable(
                name: "RedeemedProducts");

            migrationBuilder.DropTable(
                name: "ReedemProducts");

            migrationBuilder.DropTable(
                name: "SmartEvent");

            migrationBuilder.DropTable(
                name: "UserDetail");

            migrationBuilder.DropTable(
                name: "UserManual");

            migrationBuilder.DropTable(
                name: "UserOrderedProduct");

            migrationBuilder.DropTable(
                name: "VideoVariants");

            migrationBuilder.DropTable(
                name: "DealerDetail");

            migrationBuilder.DropTable(
                name: "DistributorOrder");

            migrationBuilder.DropTable(
                name: "ProductStock");

            migrationBuilder.DropTable(
                name: "RewardProduct");

            migrationBuilder.DropTable(
                name: "UserOrder");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "SubCategory");

            migrationBuilder.DropTable(
                name: "MainCategory");

            migrationBuilder.DropTable(
                name: "DistributorDetail");

            migrationBuilder.DropTable(
                name: "DistributorAddress");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeviceType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DialCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ProfilePic",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
