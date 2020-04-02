using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
   public class PageSettingServices : IPageSettingServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public PageSettingServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApplicationPageVM> AddNewApplicationPagesAsync(ApplicationPageVM applicationPageVM)
        {
            ApplicationPageVM applicationPageVm = new ApplicationPageVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    applicationPageVM = await  _unitOfWork.PageSettingRepository.AddNewApplicationPagesAsync(applicationPageVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return applicationPageVM;
        }

        public async Task<ApplicationPageVM> UpdateSelectedPage(ApplicationPageVM applicationPageVM)
        {
            ApplicationPageVM applicationPageVm = new ApplicationPageVM();
            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    applicationPageVM = await  _unitOfWork.PageSettingRepository.UpdateSelectedPage(applicationPageVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return applicationPageVM;
        }
    }
}
