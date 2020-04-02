using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using SignalRHub;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class StockPurchaseOrderServices : IPurchaseOrderServices
    {
        private readonly IApprovalServices _approvalServices;
        private readonly INotificationServices _notificationServices;
        private readonly IUnitOfWork _unitOfWork;



        public StockPurchaseOrderServices( IUnitOfWork unitOfWork, IApprovalServices approvalServices, INotificationServices notificationServices)
        {
            _approvalServices = approvalServices;
            _notificationServices = notificationServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PurchaseOrderSummeryVM>> GetPurchaseOrderSummeryDetails(int searchTypeId, int pageId)
        {
            IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM;
            
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderSummeryVM = await  _unitOfWork.PurchaseOrderRepository.GetPurchaseOrderSummeryDetails(searchTypeId, pageId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderSummeryVM;
        }
        public async Task<NewPurchaseOrderVM> AddPurschaseOrderSummeryDetails(NewPurchaseOrderVM newPurchaseOrderVM)
        {
            NewPurchaseOrderVM newPurchaseOrderVm = new NewPurchaseOrderVM();
            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    newPurchaseOrderVm = await  _unitOfWork.PurchaseOrderRepository.AddPurschaseOrderSummeryDetails(newPurchaseOrderVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return newPurchaseOrderVm;
        }

        public async Task<PurchaseOrderSummeryVM> GetStockPurchaseOrderId(int companyId)
        {
            PurchaseOrderSummeryVM purchaseOrderSummeryVM = new PurchaseOrderSummeryVM();
            
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderSummeryVM = await  _unitOfWork.PurchaseOrderRepository.GetStockPurchaseOrderId(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderSummeryVM;
        }
        public async Task<PurchaseOrderMasterVM> GetPurchaseOrderDetailsById(string purchaseorderId, int companyId,bool isDraft)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            
                
            using (_unitOfWork)
            {


                try
                {
                    if (isDraft)
                                    {
                                        purchaseOrderMasterVM = await  _unitOfWork.PurchaseOrderRepository.GetPurchaseOrderDraftDetailsById(purchaseorderId, companyId);
                                        purchaseOrderMasterVM.purchaseOrderItemVM = await  _unitOfWork.PurchaseOrderRepository.GetPurchaseOrderItemDraftDetailsById(purchaseorderId);
                                    }
                                    else
                                    {
                                        purchaseOrderMasterVM = await  _unitOfWork.PurchaseOrderRepository.GetPurchaseOrderDetailsById(purchaseorderId, companyId);
                                        purchaseOrderMasterVM.purchaseOrderItemVM = await  _unitOfWork.PurchaseOrderRepository.GetPurchaseOrderItemDetailsById(purchaseorderId);
                                    }
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderItemVM> AddPurschaseOrderItemDetails(PurchaseOrderItemVM purchaseOrderItemVM)
        {
            PurchaseOrderItemVM purchaseOrderItem = new PurchaseOrderItemVM();
            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderItem = await  _unitOfWork.PurchaseOrderRepository.AddPurschaseOrderItemDetails(purchaseOrderItemVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderItem;
        }

        public async Task<NewPurchaseOrderVM> UpdatePurchaseOrderSummeryDetailsById(NewPurchaseOrderVM newPurchaseOrderVM)
        {
            NewPurchaseOrderVM newPurchaseOrderVm = new NewPurchaseOrderVM();
           
                    /* Perform transactional work here */
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    newPurchaseOrderVM = await  _unitOfWork.PurchaseOrderRepository.UpdatePurchaseOrderSummeryDetailsById(newPurchaseOrderVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return newPurchaseOrderVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderDraftDetailsByUserId(int userId)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
            
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderItemVM = await  _unitOfWork.PurchaseOrderRepository.GetPurchaseOrderDraftDetailsByUserId(userId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderItemVM;
        }

        public async Task<PurchaseOrderItemVM> UpdatePurchaseOrderItemDetailsByPurchaseOrderId(PurchaseOrderItemVM purchaseOrderItemVM)
        {
            PurchaseOrderItemVM purchaseOrderItemVm = new PurchaseOrderItemVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderItemVM = await  _unitOfWork.PurchaseOrderRepository.UpdatePurchaseOrderItemDetailsByPurchaseOrderId(purchaseOrderItemVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderItemVM;
        }

        public async Task<PurchaseOrderItemVM> DeletePurchaseOrderItemDetailsByPurchaseOrderId(int purchaseOrderId)
        {
            PurchaseOrderItemVM purchaseOrderItemVM = new PurchaseOrderItemVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderItemVM = await  _unitOfWork.PurchaseOrderRepository.DeletePurchaseOrderItemDetailsByPurchaseOrderId(purchaseOrderId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderItemVM;
        }

        public async Task<PurchaseOrderFinalVM> UpdatePurchaseOrderById(PurchaseOrderFinalVM purchaseOrderFinalVM)
        {
            PurchaseOrderFinalVM purchaseOrderFinalVm = new PurchaseOrderFinalVM();
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();
            int PurchaseOrderApprovalTypeId = 1;
            int PurchaseOrderNotificationTypeId = 1;
            int createdUserId = purchaseOrderFinalVM.UserId;
            int companyId = 1;

                                    
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    // Save Po details from draft to original table 
                    purchaseOrderFinalVm    = await  _unitOfWork.PurchaseOrderRepository.UpdatePurchaseOrderById(purchaseOrderFinalVM);

                    purchaseOrderFinalVm.PurchaseNo = purchaseOrderFinalVm.DocumentNo;

                   // get approval details for Purchase Order by approvaltypeId
                    functionApprovalTypeVm =await _approvalServices.GetFunctionApprovalDetailsByFunctionId(PurchaseOrderApprovalTypeId,PurchaseOrderNotificationTypeId, purchaseOrderFinalVm.PurchaseNo, createdUserId, companyId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderFinalVm;
        }

        public async Task<IEnumerable<PurchaseDraftSummeryVM>> GetPurchaseOrderDraftSummeryDetailsByUserId(int companyId, int userId)
        {
            IEnumerable<PurchaseDraftSummeryVM> purchaseDraftSummeryVM;
            
            using (_unitOfWork)
            {


                try
                {
                purchaseDraftSummeryVM = await  _unitOfWork.PurchaseOrderRepository.GetPurchaseOrderDraftSummeryDetailsByUserId(userId, companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return purchaseDraftSummeryVM;
        }

        public async Task<NewPurchaseOrderVM> UpdateAllPurchaseOrderRecieved(int purchaseOrderId, int userId)
        {
            NewPurchaseOrderVM newPurchaseOrderVM = new NewPurchaseOrderVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    newPurchaseOrderVM = await  _unitOfWork.PurchaseOrderRepository.UpdateAllPurchaseOrderRecieved(purchaseOrderId, userId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return newPurchaseOrderVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderItemDraftDetailsById(string purchaseorderId)
        {
           IEnumerable< PurchaseOrderItemVM> purchaseOrderItemVM;
           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderItemVM = await  _unitOfWork.PurchaseOrderRepository.GetPurchaseOrderItemDraftDetailsById(purchaseorderId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderItemVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdatePurchaseOrderStatusByPurchaseNo(string purchaseNo, int userId)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderMasterVM = await  _unitOfWork.PurchaseOrderRepository.UpdatePurchaseOrderStatusByPurchaseNo(purchaseNo, userId);

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

      
    }
}