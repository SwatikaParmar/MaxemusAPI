
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using MaxemusAPI.Data;
using MaxemusAPI.ViewModel;
using MaxemusAPI.Models;
using MaxemusAPI.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using MaxemusAPI.Common;
using MaxemusAPI.Models.Helper;
using System.Net;

namespace MaxemusAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TermsAndConditionsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        public TermsAndConditionsController(ApplicationDbContext context, IConfiguration config, IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }

        #region getTermsAndConditions
        [HttpGet("getTermsAndConditions")]
        public async Task<IActionResult> getTermsAndConditions()
        {
            var _response = new APIResponse();
            try
            {
                var getTermsAndConditions = await _context.TermsAndConditions.FirstOrDefaultAsync();
                var mapdata = _mapper.Map<TermsAndConditionsViewModel>(getTermsAndConditions);
                mapdata.termsAndConditionsContent = CommonMethod.ReplaceNewlines(mapdata.termsAndConditionsContent, "");

                if (mapdata != null)
                {
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                    _response.Messages = "Data" + ResponseMessages.msgShownSuccess;
                    _response.Data = mapdata.termsAndConditionsContent;
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

        #region getAdminTermsAndConditions
        [HttpGet("getAdminTermsAndConditions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> getAdminTermsAndConditions()
        {
            var _response = new APIResponse();
            try
            {
                var getTermsAndConditions = await _context.TermsAndConditions.FirstOrDefaultAsync();
                var mapdata = _mapper.Map<TermsAndConditionsAdminViewModel>(getTermsAndConditions);
                mapdata.TermsAndConditionsContent = CommonMethod.ReplaceNewlines(mapdata.TermsAndConditionsContent, "");

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

        #region adminAddTermsAndConditions
        [HttpPost("adminAddTermsAndConditions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> adminAddTermsAndConditions([FromBody] TermsAndConditionsViewModel model)
        {
            var _response = new APIResponse();
            try
            {
                var mapdata = _mapper.Map<TermsAndConditions>(model);
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

        #region adminUpdateTermsAndConditions
        [HttpPost("adminUpdateTermsAndConditions")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> adminUpdateTermsAndConditions([FromBody] UpdateTermsAndConditionsViewModel model)
        {
            var _response = new APIResponse();
            try
            {
                var getData = await _context.TermsAndConditions
                    .Where(i => i.TermsAndConditionsId == model.termsAndConditionsId)
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
