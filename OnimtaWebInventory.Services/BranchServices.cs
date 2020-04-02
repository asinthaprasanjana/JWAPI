using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class BranchServices : IBranchServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public BranchServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BranchVM> AddNewBranchDetails(BranchVM branchVM)
        {
            BranchVM branchVm = new BranchVM();
            WareHouseVM wareHouseVM = new WareHouseVM();
            using (_unitOfWork)
            {

                try
                {
                    _unitOfWork.BeginTransaction();
                    branchVm = await _unitOfWork.BranchRepository.AddNewBranchDetails(branchVM);
                        int branchId = branchVm.BranchId;
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }

                    //for (int i = 0; i < branchVM.wareHouseVM.Count(); i++)
                    //{
                    //    branchVM.wareHouseVM.ElementAt(i).BranchId = branchId;
                    //    wareHouseVM = await _branchRepository.AddNewWareHouseDetails(branchVM.wareHouseVM.ElementAt(i));
                    //}
               
            return branchVm;
        }

        public async Task<IEnumerable< BranchVM>> GetBranchDetailByCompanyId(int companyId)
        {
           IEnumerable<BranchVM> branchVM ;

            using (_unitOfWork)
            {


                try
                {
                     branchVM   = await _unitOfWork.BranchRepository.GetBranchDetailByCompanyId(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

           
            return branchVM;
        }

        public async Task<IEnumerable<BranchVM>> GetBranchDetailsByUserId(int userId, int businessProcessId)
        {
            IEnumerable<BranchVM> branchVM ;

            using (_unitOfWork)
            {


                try
                {
                      branchVM = await _unitOfWork.BranchRepository.GetBranchDetailsByUserId(userId, businessProcessId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }


           
            return branchVM;
        }

        public async Task<BranchVM> UpdateBranchDetails(BranchVM branchVM)
        {
            BranchVM branchVm = new BranchVM();

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    branchVm = await _unitOfWork.BranchRepository.UpdateBranchDetails(branchVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }

                  
            return branchVm;
        }
    }
}
