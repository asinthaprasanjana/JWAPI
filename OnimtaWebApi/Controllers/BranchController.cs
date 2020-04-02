using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.Branch;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    //[Authorize]
    public class BranchController : Controller
    {
        private IBranchServices _BranchServices;
        private ILogger<BranchController> _logger;

        public BranchController(IBranchServices BranchServices, ILogger<BranchController> logger)
        {
            _BranchServices = BranchServices;
            _logger = logger;
        }


        [HttpGet("{companyId}")]
        public async Task<BranchResponse> GetBranchDetails(int companyId)
        {
            BranchResponse branchResponse = new BranchResponse();
              IEnumerable< BranchVM >branchVM;
           
            try
            {
                branchVM = await _BranchServices.GetBranchDetailByCompanyId(companyId);
                branchResponse.branchVM = branchVM;
                branchResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                branchResponse.IsSuccess = false;
                branchResponse.Message = exc.Message;
            }
            return branchResponse;
        }
        [HttpPost]
        public async Task<BranchResponse> AddNewBranchDetails([FromBody]BranchRequest branchRequest)
        {
            BranchResponse branchResponse = new BranchResponse();
            IEnumerable<BranchVM> branchVM;
            try
            {
                branchVM = new List<BranchVM>
                {
                    await _BranchServices.AddNewBranchDetails(branchRequest.branchVM)
                };
                branchResponse.branchVM = branchVM;
                branchResponse.IsSuccess = true;
                _logger.LogInformation(branchRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                branchResponse.IsSuccess = false;
                branchResponse.Message = ex.Message;
            }
            return branchResponse;
        }

        [HttpPut]
        public async Task<BranchResponse> UpdateBranchDetails([FromBody]BranchRequest branchRequest)
        { 
             BranchResponse branchResponse = new BranchResponse();
             IEnumerable<BranchVM> branchVM;
            try
            {
                branchVM = new List<BranchVM>
                {
                    await _BranchServices.UpdateBranchDetails(branchRequest.branchVM)
                };
                 branchResponse.branchVM = branchVM;
                branchResponse.IsSuccess = true;
                _logger.LogInformation(branchRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                branchResponse.IsSuccess = false;
                branchResponse.Message = ex.Message;
            }
            return branchResponse;
        }

        [HttpGet("{userId},{businessProcessId}")]
        public async Task<BranchResponse> GetBranchDetailsByUserId(int userId, int businessProcessId)
        {
            BranchResponse branchResponse = new BranchResponse();


            IEnumerable<BranchVM> branchVM;

            try
            {
                branchVM = await _BranchServices.GetBranchDetailsByUserId(userId, businessProcessId);
                branchResponse.branchVM = branchVM;
                branchResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                branchResponse.IsSuccess = false;
                branchResponse.Message = ex.Message;
            }
            return branchResponse;
        }
    }
}

   