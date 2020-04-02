using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Season;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class SeasonController : Controller
    {
        private readonly ISeasonServices _seasonServices;
        private ILogger<SeasonController> _logger;

        public SeasonController(ISeasonServices SeasonServices , ILogger<SeasonController>logger)
        {
            _seasonServices = SeasonServices;
            _logger = logger;
        }
        [HttpPost]
        public async Task<SeasonResponse> AddNewSeasonDetails([FromBody]SeasonRequest seasonRequest)
        {
            SeasonResponse seasonResponse = new SeasonResponse();
           IEnumerable< SeasonVM >seasonVm ;

            try
            {
                seasonVm = new List<SeasonVM>
                {
                    await _seasonServices.AddNewSeasonDetails(seasonRequest.seasonVM)
                };
                seasonResponse.seasonVM = seasonVm;
                seasonResponse.IsSuccess = true;
                _logger.LogInformation(seasonRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                seasonResponse.IsSuccess = false;
                seasonResponse.Message = ex.Message;
            }
            return seasonResponse;
        }
        [HttpPut]
        public async Task<SeasonResponse> UpdateSeasonDetails([FromBody]SeasonRequest seasonRequest)
        {
            SeasonResponse seasonResponse = new SeasonResponse();
            IEnumerable<SeasonVM> seasonVm;

            try
            {
                seasonVm = new List<SeasonVM>
                {
                    await _seasonServices.UpdateSeasonDetails(seasonRequest.seasonVM)
                };
                seasonResponse.seasonVM = seasonVm;
                seasonResponse.IsSuccess = true;
                _logger.LogInformation(seasonRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                seasonResponse.IsSuccess = false;
                seasonResponse.Message = ex.Message;
            }
            return seasonResponse;
        }

        [HttpGet("{id}")]
        public async Task<SeasonResponse> GetAllSeasonDetailsById(int id)
        {
            SeasonResponse seasonResponse = new SeasonResponse();
            IEnumerable<SeasonVM> seasonVM;
            try
            {
                seasonVM = await _seasonServices.GetAllSeasonDetailsById(id);
                seasonResponse.seasonVM = seasonVM;
                seasonResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                seasonResponse.IsSuccess = false;
                seasonResponse.Message = ex.Message;
            }
            return seasonResponse;
        }
    }
}