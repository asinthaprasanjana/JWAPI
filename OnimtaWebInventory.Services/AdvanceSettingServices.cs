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
    public class AdvanceSettingServices : IAdvanceSettingServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public AdvanceSettingServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AdvanceSettingVM> AddAdvaneSettingDetails(AdvanceSettingVM advanceSettingVM)
        {
            AdvanceSettingVM advanceSettingVm = new AdvanceSettingVM();

         
            using (_unitOfWork)
            {

                try
                {
                    _unitOfWork.BeginTransaction();
                    advanceSettingVM = await _unitOfWork.AdavanceSettingRepository.AddAdvaneSettingDetails(advanceSettingVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return advanceSettingVM;
        }

        public async Task<IEnumerable<AdvanceSettingVM>> GetAllAdvaneSettingDetails()
        {
            IEnumerable<AdvanceSettingVM> advanceSettingVM;

            using (_unitOfWork)
            {

                try
                {
                    advanceSettingVM = await _unitOfWork.AdavanceSettingRepository.GetAllAdvaneSettingDetails();
                }
                catch (Exception ex)
                {
                   
                    throw new Exception(ex.Message);
                }
            }
            return advanceSettingVM;
        }

        public async Task<AdvanceSettingVM> UpdateAdvaneSettingDetails(AdvanceSettingVM advanceSettingVM)
        {
            AdvanceSettingVM advanceSettingVm = new AdvanceSettingVM();

            

            using (_unitOfWork)
            {

                try
                {
                 _unitOfWork.BeginTransaction();
                  advanceSettingVm = await _unitOfWork.AdavanceSettingRepository.UpdateAdvaneSettingDetails(advanceSettingVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return advanceSettingVM;
        }
    }
}
