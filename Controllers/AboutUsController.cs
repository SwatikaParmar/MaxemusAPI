
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using MaxemusAPI.ViewModel;
using MaxemusAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using MaxemusAPI.Data;
using AutoMapper;
using MaxemusAPI.Helpers;
using MaxemusAPI.Common;
using MaxemusAPI.Models.Helper;
using System.Net;

namespace MaxemusAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AboutUsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public AboutUsController(ApplicationDbContext context, IConfiguration config, IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }

        #region getAboutUs
        [HttpGet("getAboutUs")]
        public async Task<IActionResult> getAboutUs()
        {
            var _response = new APIResponse();
            try
            {
                var getAboutUs = await _context.AboutUs.FirstOrDefaultAsync();
                var mapdata = _mapper.Map<AboutUsViewModel>(getAboutUs);
                mapdata.AboutUsContent = CommonMethod.ReplaceNewlines(mapdata.AboutUsContent, "");

                if (mapdata != null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Messages = "Data" + ResponseMessages.msgShownSuccess;
                    _response.Data = mapdata.AboutUsContent;
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = false;
                    _response.Messages = ResponseMessages.msgNotFound + "record.";
                    _response.Data = null;
                }
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Messages = ex.Message;
                _response.Data = null;
            }
            return Ok(_response);
        }
        #endregion

        #region getAdminAboutUs
        [HttpGet("getAdminAboutUs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getAdminAboutUs()
        {
            var _response = new APIResponse();
            try
            {
                var getAboutUs = await _context.AboutUs.FirstOrDefaultAsync();
                var mapdata = _mapper.Map<AboutUsAdminViewModels>(getAboutUs);
                mapdata.AboutUsContent = CommonMethod.ReplaceNewlines(mapdata.AboutUsContent, "");

                if (mapdata != null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Messages = "Data" + ResponseMessages.msgShownSuccess;
                    _response.Data = mapdata;
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = false;
                    _response.Messages = ResponseMessages.msgNotFound + "record.";
                    _response.Data = null;
                }
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Messages = ex.Message;
                _response.Data = null;
            }
            return Ok(_response);
        }
        #endregion

        #region adminAddAboutUs
        [HttpPost("adminAddAboutUs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> adminAddAboutUs([FromBody] AboutUsViewModel model)
        {
            var _response = new APIResponse();
            try
            {
                var mapdata = _mapper.Map<AboutUs>(model);

                await _context.AddAsync(mapdata);
                await _context.SaveChangesAsync();

                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _response.Messages = "Data" + ResponseMessages.msgAdditionSuccess;
                _response.Data = null;
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Messages = ex.Message;
                _response.Data = null;
            }
            return Ok(_response);
        }
        #endregion

        #region adminUpdateAboutUs
        [HttpPost("adminUpdateAboutUs")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> adminUpdateAboutUs([FromBody] UpdateAboutUsViewModels model)
        {
            var _response = new APIResponse();
            try
            {
                var getData = await _context.AboutUs
                    .Where(i => i.AboutUsId == model.AboutUsId)
                    .FirstOrDefaultAsync();

                if (getData != null)
                {
                    var mapData = _mapper.Map(model, getData);
                    _context.Update(mapData);
                    await _context.SaveChangesAsync();

                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Messages = "Data" + ResponseMessages.msgUpdationSuccess;
                    _response.Data = null;
                }
                else
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = false;
                    _response.Messages = ResponseMessages.msgNotFound + "record.";
                    _response.Data = null;
                }
            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
                _response.Messages = ex.Message;
                _response.Data = null;
            }
            return Ok(_response);
        }
        #endregion
    }
}
