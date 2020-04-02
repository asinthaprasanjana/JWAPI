using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Currency;
using OnimtaWebInventory.DTO.Curreny;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    public class CurrencyController : Controller
    {
        private ICurrencyServices _currencyServices;
        private ILogger<CurrencyController> _logger;

        public CurrencyController(ICurrencyServices CurrencyServices, ILogger<CurrencyController> logger)
        {
            _currencyServices = CurrencyServices;
            _logger = logger;
        }
        [HttpPost]
        public async Task<CurrencyResponse> AddNewCurrencyDetails([FromBody]CurrencyRequest currencyRequest)
        {
            CurrencyResponse currencyResponse = new CurrencyResponse();
            IEnumerable<CurrencyVM> currencyVm;
            try
            {
                currencyVm = new List<CurrencyVM>{
                    await _currencyServices.AddNewCurrencyDetails(currencyRequest.currencyVM)
                };
                currencyResponse.currenyVM = currencyVm;
                currencyResponse.IsSuccess = true;
                _logger.LogInformation(currencyRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                currencyResponse.IsSuccess = false;
                currencyResponse.Message = exc.Message;
            }
            return currencyResponse;
        }

        [HttpGet("{companyId}")]
        public async Task<IEnumerable<CurrencyResponse>> GetCurrencyDetails(int companyId)
        {
            CurrencyResponse currencyResponse = new CurrencyResponse();
            IEnumerable<CurrencyVM> currencyVM;
                try
                {
                currencyVM = await _currencyServices.GetCurrencyDetails(companyId);
                currencyResponse.currenyVM = currencyVM;
                currencyResponse.IsSuccess = true;
                }
                catch (Exception ex)
                {
                _logger.LogError(ex.Message);
                currencyResponse.IsSuccess = false;
                currencyResponse.Message = ex.Message;
                
                }
            return null;     
            }
        }
    }

