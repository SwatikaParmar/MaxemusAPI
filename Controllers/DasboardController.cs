using MaxemusAPI.Models.Dtos;
using MaxemusAPI.Models.Helper;
using MaxemusAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static MaxemusAPI.Common.GlobalVariables;
using MaxemusAPI.Helpers;
using Microsoft.AspNetCore.Authorization;
using MaxemusAPI.Models;
using MaxemusAPI.Repository;
using MaxemusAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using AutoMapper;
using Amazon.S3.Model;
using Amazon.S3;
using MaxemusAPI.Common;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Amazon.SimpleSystemsManagement.Model;

namespace MaxemusAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IEmailManager _emailSender;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUploadRepository _uploadRepository;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DashboardController(
            UserManager<ApplicationUser> userManager,
            IEmailManager emailSender,
            IMapper mapper,
            IUploadRepository uploadRepository,
            ApplicationDbContext context

        )
        {
            _response = new();
            _emailSender = emailSender;
            _userManager = userManager;
            _uploadRepository = uploadRepository;
            _context = context;
            _mapper = mapper;

        }

        #region AddUpdateDashboardItem
        /// <summary>
        ///  AddUpdateDashboardItem.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("AddUpdateDashboardItem")]
        public async Task<IActionResult> AddUpdateDashboardItem([FromForm] UploadDashboardItemDto model)
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }

            if (model.type != "News" && model.type != "Handout" && model.type != "Solution" && model.type != "Solution")
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = "Please select valid type";
                return Ok(_response);
            }

            DashboardItem dashboardItem = null;
            if (model.dashboardItemId > 0)
            {
                dashboardItem = await _context.DashboardItem.Where(u => u.DashboardItemId == model.dashboardItemId).FirstOrDefaultAsync();
                if (dashboardItem == null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = false;
                    _response.Messages = ResponseMessages.msgNotFound + "record.";
                    return Ok(_response);
                }
                // Delete previous file
                if (!string.IsNullOrEmpty(dashboardItem.Url))
                {
                    var chk = await _uploadRepository.DeleteFilesFromServer("FileToSave/" + dashboardItem.Url);
                }
                if (!string.IsNullOrEmpty(dashboardItem.Image))
                {
                    var chk = await _uploadRepository.DeleteFilesFromServer("FileToSave/" + dashboardItem.Image);
                }

                var documentFile = ContentDispositionHeaderValue.Parse(model.pdf.ContentDisposition).FileName.Trim('"');
                documentFile = CommonMethod.EnsureCorrectFilename(documentFile);
                documentFile = CommonMethod.RenameFileName(documentFile);

                var documentPath = DashboardItemContainer + documentFile;

                var documentFile1 = ContentDispositionHeaderValue.Parse(model.image.ContentDisposition).FileName.Trim('"');
                documentFile1 = CommonMethod.EnsureCorrectFilename(documentFile1);
                documentFile1 = CommonMethod.RenameFileName(documentFile1);

                var documentPath1 = DashboardItemContainer + documentFile1;

                dashboardItem.Url = documentPath;
                dashboardItem.Image = documentPath1;
                dashboardItem.Title = model.title;
                dashboardItem.Type = model.type;
                dashboardItem.Description = model.discdescription;
                _context.Update(dashboardItem);
                _context.SaveChangesAsync();
                bool uploadStatus = await _uploadRepository.UploadFilesToServer(
                        model.pdf,
                        DashboardItemContainer,
                        documentFile
                    );

                bool uploadStatus1 = await _uploadRepository.UploadFilesToServer(
                    model.image,
                    DashboardItemContainer,
                    documentFile1
                );

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Added successfully.";
                _response.Data = dashboardItem;
                return Ok(_response);
            }
            else
            {
                dashboardItem = new DashboardItem();
                var documentFile = ContentDispositionHeaderValue.Parse(model.pdf.ContentDisposition).FileName.Trim('"');
                documentFile = CommonMethod.EnsureCorrectFilename(documentFile);
                documentFile = CommonMethod.RenameFileName(documentFile);

                var documentPath = DashboardItemContainer + documentFile;

                var documentFile1 = ContentDispositionHeaderValue.Parse(model.image.ContentDisposition).FileName.Trim('"');
                documentFile1 = CommonMethod.EnsureCorrectFilename(documentFile1);
                documentFile1 = CommonMethod.RenameFileName(documentFile1);

                var documentPath1 = DashboardItemContainer + documentFile1;

                dashboardItem.Url = documentPath;
                dashboardItem.Image = documentPath1;
                dashboardItem.Title = model.title;
                dashboardItem.Description = model.discdescription;
                dashboardItem.Type = model.type;
                _context.Add(dashboardItem);
                _context.SaveChangesAsync();
                bool uploadStatus = await _uploadRepository.UploadFilesToServer(
                        model.pdf,
                        DashboardItemContainer,
                        documentFile
                    );

                bool uploadStatus1 = await _uploadRepository.UploadFilesToServer(
                    model.image,
                    DashboardItemContainer,
                    documentFile1
                );
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Updated successfully.";
                _response.Data = dashboardItem;
                return Ok(_response);
            }


        }
        #endregion

        #region AddUpdateDashboardVideo
        /// <summary>
        ///  AddUpdateDashboardItem.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("AddUpdateDashboardVideo")]
        public async Task<IActionResult> AddUpdateDashboardVideo([FromForm] UploadVideoDto model)
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }


            DashboardVideo dashboardVideo = null;
            if (model.DashboardVideoId > 0)
            {
                dashboardVideo = await _context.DashboardVideo.Where(u => u.DashboardVideoId == model.DashboardVideoId).FirstOrDefaultAsync();

                if (dashboardVideo == null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = false;
                    _response.Messages = ResponseMessages.msgNotFound + "record.";
                    return Ok(_response);
                }
                // Delete previous file
                if (!string.IsNullOrEmpty(dashboardVideo.Url))
                {
                    var chk = await _uploadRepository.DeleteFilesFromServer("FileToSave/" + dashboardVideo.Url);
                }
                if (!string.IsNullOrEmpty(dashboardVideo.Thumbnail))
                {
                    var chk = await _uploadRepository.DeleteFilesFromServer("FileToSave/" + dashboardVideo.Thumbnail);
                }

                var documentFile = ContentDispositionHeaderValue.Parse(model.video.ContentDisposition).FileName.Trim('"');
                documentFile = CommonMethod.EnsureCorrectFilename(documentFile);
                documentFile = CommonMethod.RenameFileName(documentFile);
                var documentPath = videoContainer + documentFile;

                if (model.thumbnail != null)
                {
                    var documentFile1 = ContentDispositionHeaderValue.Parse(model.thumbnail.ContentDisposition).FileName.Trim('"');
                    documentFile1 = CommonMethod.EnsureCorrectFilename(documentFile1);
                    documentFile1 = CommonMethod.RenameFileName(documentFile);

                    var documentPath1 = videoContainer + documentFile1; dashboardVideo.Thumbnail = documentPath1;
                    bool uploadStatus1 = await _uploadRepository.UploadFilesToServer(
                                            model.thumbnail,
                                            videoContainer,
                                            documentFile1
                                        );
                }

                dashboardVideo.Url = documentPath;
                dashboardVideo.Title = model.title;
                _context.Update(dashboardVideo);
                _context.SaveChangesAsync();
                bool uploadStatus = await _uploadRepository.UploadFilesToServer(
                        model.video,
                        videoContainer,
                        documentFile
                    );
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Updated successfully.";
                _response.Data = dashboardVideo;
                return Ok(_response);
            }
            else
            {
                dashboardVideo = new DashboardVideo();
                var documentFile = ContentDispositionHeaderValue.Parse(model.video.ContentDisposition).FileName.Trim('"');
                documentFile = CommonMethod.EnsureCorrectFilename(documentFile);
                documentFile = CommonMethod.RenameFileName(documentFile);

                var documentPath = videoContainer + documentFile;

                dashboardVideo.Url = documentPath;
                dashboardVideo.Title = model.title;

                if (model.thumbnail != null)
                {
                    var documentFile1 = ContentDispositionHeaderValue.Parse(model.thumbnail.ContentDisposition).FileName.Trim('"');
                    documentFile1 = CommonMethod.EnsureCorrectFilename(documentFile1);
                    documentFile1 = CommonMethod.RenameFileName(documentFile);

                    var documentPath1 = videoContainer + documentFile1; dashboardVideo.Thumbnail = documentPath1;
                    bool uploadStatus1 = await _uploadRepository.UploadFilesToServer(
                                            model.thumbnail,
                                            videoContainer,
                                            documentFile1
                                        );
                }

                await _context.AddAsync(dashboardVideo);
                await _context.SaveChangesAsync();
                bool uploadStatus = await _uploadRepository.UploadFilesToServer(
                        model.video,
                        videoContainer,
                        documentFile
                    );

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Added successfully.";
                _response.Data = dashboardVideo;
                return Ok(_response);
            }


        }
        #endregion

        #region getVideo
        /// <summary>
        ///  getVideo.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("getVideo")]
        public async Task<IActionResult> getVideo()
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }

            var dashboardVideoList = await _context.DashboardVideo.ToListAsync();

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Messages = "List Shown successfully.";
            _response.Data = dashboardVideoList;
            return Ok(_response);


        }
        #endregion

        #region getItems
        /// <summary>
        ///  getItems.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("getItems")]
        public async Task<IActionResult> getItems([FromQuery] string? type)
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }

            var dashboardItemList = await _context.DashboardItem.ToListAsync();

            if (!string.IsNullOrEmpty(type))
            {
                dashboardItemList = dashboardItemList.Where(u => u.Type.ToLower() == type.ToLower()).ToList();
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Messages = "List Shown successfully.";
            _response.Data = dashboardItemList;
            return Ok(_response);


        }
        #endregion

        #region getVideoDetails
        /// <summary>
        ///  get Video Details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("getVideoDetails")]
        public async Task<IActionResult> getVideoDetails([FromQuery] int dashboardVideoId)
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }

            var dashboardVideoDetail = await _context.DashboardVideo.Where(u => u.DashboardVideoId == dashboardVideoId).FirstOrDefaultAsync();

            if (dashboardVideoDetail == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgNotFound + "record";
                return Ok(_response);
            }
            else
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Detail Shown successfully.";
                _response.Data = dashboardVideoDetail;
                return Ok(_response);
            }
        }
        #endregion

        #region getItemDetails
        /// <summary>
        ///  get Item Details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("getItemDetails")]
        public async Task<IActionResult> getItemDetails([FromQuery] int dashboardItemId)
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }

            var dashboardItemDetail = await _context.DashboardItem.Where(u => u.DashboardItemId == dashboardItemId).FirstOrDefaultAsync();

            if (dashboardItemDetail == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgNotFound + "record";
                return Ok(_response);
            }
            else
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Detail Shown successfully.";
                _response.Data = dashboardItemDetail;
                return Ok(_response);
            }
        }
        #endregion

        #region AddUpdateBanner
        /// <summary>
        ///  AddUpdateBanner.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("AddUpdateBanner")]
        public async Task<IActionResult> AddUpdateBanner([FromForm] UploadBannerImageDTO model)
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }


            Banner dashboardItem = null;
            if (model.bannerId > 0)
            {
                dashboardItem = await _context.Banner.Where(u => u.BannerId == model.bannerId).FirstOrDefaultAsync();
                if (dashboardItem == null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = false;
                    _response.Messages = ResponseMessages.msgNotFound + "record.";
                    return Ok(_response);
                }
                // Delete previous file
                if (!string.IsNullOrEmpty(dashboardItem.Image))
                {
                    var chk = await _uploadRepository.DeleteFilesFromServer("FileToSave/" + dashboardItem.Image);
                }

                var documentFile = ContentDispositionHeaderValue.Parse(model.Image.ContentDisposition).FileName.Trim('"');
                documentFile = CommonMethod.EnsureCorrectFilename(documentFile);
                documentFile = CommonMethod.RenameFileName(documentFile);

                var documentPath = DashboardItemContainer + documentFile;

                dashboardItem.Image = documentPath;
                dashboardItem.Name = model.name;

                _context.Update(dashboardItem);
                _context.SaveChangesAsync();
                bool uploadStatus = await _uploadRepository.UploadFilesToServer(
                        model.Image,
                        DashboardItemContainer,
                        documentFile
                    );

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Banner added successfully.";
                _response.Data = dashboardItem;
                return Ok(_response);
            }
            else
            {
                dashboardItem = new Banner();
                var documentFile = ContentDispositionHeaderValue.Parse(model.Image.ContentDisposition).FileName.Trim('"');
                documentFile = CommonMethod.EnsureCorrectFilename(documentFile);
                documentFile = CommonMethod.RenameFileName(documentFile);

                var documentPath = DashboardItemContainer + documentFile;

                dashboardItem.Image = documentPath;
                dashboardItem.Name = model.name;

                _context.Add(dashboardItem);
                _context.SaveChangesAsync();
                bool uploadStatus = await _uploadRepository.UploadFilesToServer(
                        model.Image,
                        DashboardItemContainer,
                        documentFile
                    );

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Banner updated successfully.";
                _response.Data = dashboardItem;
                return Ok(_response);
            }


        }
        #endregion

        #region getBanners
        /// <summary>
        ///  get banner list.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("getBanners")]
        public async Task<IActionResult> getBanners()
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }

            var dashboardItemList = await _context.Banner.ToListAsync();

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Messages = "List Shown successfully.";
            _response.Data = dashboardItemList;
            return Ok(_response);


        }
        #endregion

        #region getBannerDetails
        /// <summary>
        ///  get banner details.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        [Route("getBannerDetails")]
        public async Task<IActionResult> getBannerDetails([FromQuery] int bannerId)
        {
            var currentUserId = HttpContext.User.Claims.First().Value;
            var currentUser = _userManager.FindByIdAsync(currentUserId).GetAwaiter().GetResult();
            if (currentUser == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgUserNotFound;
                return Ok(_response);
            }

            var dashboardVideoDetail = await _context.Banner.Where(u => u.BannerId == bannerId).FirstOrDefaultAsync();

            if (dashboardVideoDetail == null)
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = false;
                _response.Messages = ResponseMessages.msgNotFound + "record";
                return Ok(_response);
            }
            else
            {
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Detail Shown successfully.";
                _response.Data = dashboardVideoDetail;
                return Ok(_response);
            }
        }
        #endregion

    }
}
