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
    public class PurchaseOrderBillServices : IPurchaseOrderBillServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public PurchaseOrderBillServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseOrderMasterVM> AddPurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            PurchaseOrderItemVM purchaseOrderItemVM = new PurchaseOrderItemVM();

            using (_unitOfWork)
            {
                try
                {


                    _unitOfWork.BeginTransaction();
                    purchaseOrderMasterVm = await _unitOfWork.PurchaseOrderBillRepository.AddPurchaseOrderBillDetails(purchaseOrderMasterVM);

                    for (int i = 0; i < purchaseOrderMasterVM.purchaseOrderItemVM.Count(); i++)
                    {
                        purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i).UserId = purchaseOrderMasterVM.UserId;

                        purchaseOrderItemVM = await _unitOfWork.PurchaseOrderBillRepository.AddPurchaseOrderBillEventDetails(purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i) , purchaseOrderMasterVm.DocumentNo);
                    }
                    _unitOfWork.CommitTransaction();



                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return purchaseOrderMasterVm;
        }

        public async Task<PurchaseOrderMasterVM> GetPurchaseOrderBillDetailsByPurchaseNo(int purchaseNo)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
           
                    purchaseOrderMasterVM = await  _unitOfWork.PurchaseOrderBillRepository.GetPurchaseOrderBillDetailsByPurchaseNo(purchaseNo);
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdatePartiallyPurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
          
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderMasterVm = await  _unitOfWork.PurchaseOrderBillRepository.UpdatePartiallyPurchaseOrderBillDetails(purchaseOrderMasterVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderMasterVm;
        }

      

        public async Task<PurchaseOrderMasterVM> UpdatePurchaseOrderBillDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderMasterVm = await  _unitOfWork.PurchaseOrderBillRepository.UpdatePurchaseOrderBillDetails(purchaseOrderMasterVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderMasterVm;
        }

      public async  Task<IEnumerable<PurchaseOrderMasterVM>>GetAllPurchaseOrderBillDetails(int pageId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderMasterVM = await  _unitOfWork.PurchaseOrderBillRepository.GetAllPurchaseOrderBillDetails(pageId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderMasterVM;
        }

        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetAllBillEventDetailsByCompanyId(int companyId)
        {
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM;

            
            using (_unitOfWork)
            {

                try
                {

                    purchaseOrderBilledEventsVM = await  _unitOfWork.PurchaseOrderBillRepository.GetAllBillEventDetailsByCompanyId(companyId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderBilledEventsVM;
        }

        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetPurchaseOrderBilledDetailsByBusinessPartnerId(string businessPartnerId)
        {
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM ;

           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderBilledEventsVM = await  _unitOfWork.PurchaseOrderBillRepository.GetPurchaseOrderBilledDetailsByBusinessPartnerId(businessPartnerId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderBilledEventsVM;
        }
    }
}
