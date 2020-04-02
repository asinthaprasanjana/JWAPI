using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services
{
    public class AdvanceSearchServices : IAdvanceSearchServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public AdvanceSearchServices(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async  Task<IEnumerable<AdvanceSearchVM>> GetAdvanceSearchDetails(int advanceSearchType)
        {
            IEnumerable<AdvanceSearchVM> advanceSearchVM;

            using (_unitOfWork)
            {

                try
                {
                    advanceSearchVM = await _unitOfWork.AdvanceSearchRepository.GetAdvanceSearchDetails(advanceSearchType);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
           

                          

            return advanceSearchVM;
        }

        public async Task<IEnumerable<BusinessPartnerVM>> GetBusinessPartnerDetails(BusinessPartnerVM businessPartnerVM)
        {
            IEnumerable<BusinessPartnerVM> businessPartnerVm;
          
            using (_unitOfWork)
            {


                try
                {
                businessPartnerVm = await _unitOfWork.AdvanceSearchRepository.GetBusinessPartnerDetails(businessPartnerVM);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
            return businessPartnerVm;
        }
    }
}
