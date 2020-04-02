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
    public class PurchaseOrderRequestServices : IPurchaseOrderRequestServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public PurchaseOrderRequestServices(IPurchaseOrderRequestRepository IPurchaseOrderRequestRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseOrderMasterVM> AddPurchaseOrderRequest(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
           
                   
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                      purchaseOrderMasterVm = await  _unitOfWork.PurchaseOrderRequestRepository.AddPurchaseOrderRequest(purchaseOrderMasterVM);

                                for(int i = 0; i < purchaseOrderMasterVM.purchaseOrderItemVM.Count(); i++)
                                {
                                    PurchaseOrderItemVM purchaseOrderItemVM = new PurchaseOrderItemVM();
                                    purchaseOrderItemVM = purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i);
                                    await  _unitOfWork.PurchaseOrderRequestRepository.AddPurchaseOrderRequestItems(purchaseOrderItemVM, purchaseOrderMasterVm.PurchaseNo);
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

       
        public async Task<IEnumerable<PurchaseOrderRequestVM>> GetAllPurchaseOrderRequestDetails(int pageId)
        {
           IEnumerable<PurchaseOrderRequestVM> purchaseOrderRequestVM ;
           
            using (_unitOfWork)
            {


                try
                {
                         purchaseOrderRequestVM = await  _unitOfWork.PurchaseOrderRequestRepository.GetAllPurchaseOrderRequestDetails( pageId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderRequestVM;
        }

        public async Task<PurchaseOrderRequestVM> GetPurchaseOrderRequestDetails(int purchaseNo)
        {
            PurchaseOrderRequestVM purchaseOrderRequestVM = new PurchaseOrderRequestVM();
            
            using (_unitOfWork)
            {


                try
                {
                            purchaseOrderRequestVM = await  _unitOfWork.PurchaseOrderRequestRepository.GetPurchaseOrderRequestDetails(purchaseNo);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderRequestVM;
        }

        public async Task<IEnumerable<PurchaseOrderRequestSummaryVM>> GetPurchaseOrderRequestItemsDetails()
        {
           IEnumerable<PurchaseOrderRequestSummaryVM> purchaseOrderRequestItemsVM ;
            
            using (_unitOfWork)
            {
                try
                {
                          purchaseOrderRequestItemsVM = await  _unitOfWork.PurchaseOrderRequestRepository.GetPurchaseOrderRequestItemsDetails();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderRequestItemsVM;
        }
    }
}
