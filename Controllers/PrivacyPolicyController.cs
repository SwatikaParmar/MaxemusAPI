
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
    public class PrivacyPolicyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public PrivacyPolicyController(ApplicationDbContext context, IConfiguration config, IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }

        #region getPrivacyPolicy
        [HttpGet("getPrivacyPolicy")]
        public async Task<IActionResult> getPrivacyPolicy()
        {
            var _response = new APIResponse();
            try
            {
                var getPrivacyPolicy = await _context.PrivacyPolicy.FirstOrDefaultAsync();
                var mapdata = _mapper.Map<PrivacyPolicyViewModel>(getPrivacyPolicy);
                mapdata.privacyPolicyContent = CommonMethod.ReplaceNewlines(mapdata.privacyPolicyContent, "");

                if (mapdata != null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Messages = "Data" + ResponseMessages.msgShownSuccess;
                    _response.Data = mapdata.privacyPolicyContent;
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

        #region getAdminPrivacyPolicy
        [HttpGet("getAdminPrivacyPolicy")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getAdminPrivacyPolicy()
        {
            var _response = new APIResponse();
            try
            {
                var getPrivacyPolicy = await _context.PrivacyPolicy.FirstOrDefaultAsync();
                var mapdata = _mapper.Map<PrivacyPolicyAdminViewModels>(getPrivacyPolicy);
                mapdata.privacyPolicyContent = CommonMethod.ReplaceNewlines(mapdata.privacyPolicyContent, "");

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

        #region adminAddPrivacyPolicy
        [HttpPost("adminAddPrivacyPolicy")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> adminAddPrivacyPolicy([FromBody] PrivacyPolicyViewModel model)
        {
            var _response = new APIResponse();
            try
            {
                var mapdata = _mapper.Map<PrivacyPolicy>(model);

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

        #region adminUpdatePrivacyPolicy
        [HttpPost("adminUpdatePrivacyPolicy")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> adminUpdatePrivacyPolicy([FromBody] UpdatePrivacyPolicyViewModels model)
        {
            var _response = new APIResponse();
            try
            {
                var getData = await _context.PrivacyPolicy
                    .Where(i => i.PrivacyPolicyId == model.privacyPolicyId)
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
