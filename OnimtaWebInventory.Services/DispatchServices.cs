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
    public class DispatchServices : IDispatchServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public DispatchServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DispatchVM> AddNewDispatchDetails(DispatchVM dispatchVM)
        {
            DispatchVM dispatchVm = new DispatchVM();

           
               
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    dispatchVM = await  _unitOfWork.DispatchRepository.AddNewDispatchDetails(dispatchVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return dispatchVM;
        }

        public async Task<IEnumerable<DispatchVM>> GetAllDispatchDetails(int dispatchTypeId)
        {
            IEnumerable<DispatchVM> dispatchVM;
            
            using (_unitOfWork)
            {


                try
                {
                dispatchVM = await  _unitOfWork.DispatchRepository.GetAllDispatchDetails(dispatchTypeId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            return dispatchVM;
        }

        public async Task<DispatchVM> GetDispatchDetailsById(int id)
        {
            DispatchVM dispatchVM = new DispatchVM();

           
            using (_unitOfWork)
            {


                try
                {
                dispatchVM = await  _unitOfWork.DispatchRepository.GetDispatchDetailsById(id);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }


            return dispatchVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetGatePassItemsDetails(string DocumentNumber)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM ;

           

            using (_unitOfWork)
            {


                try
                {
                purchaseOrderItemVM = await  _unitOfWork.DispatchRepository.GetGatePassItemsDetails(DocumentNumber);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return purchaseOrderItemVM;
        }
    }
}
