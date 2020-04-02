using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using SignalRHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class PurchaseOrderRecieveServices : IPurchaseOrderRecieveServices
    {
        private readonly INotificationServices _notificationServices;
        private readonly  IUnitOfWork _unitOfWork;

        public PurchaseOrderRecieveServices(IPurchaseOrderRecieveRepository  purchaseOrderRecieveRepository , 
            IStockServices stockServices, 
            INotificationServices notificationServices,
            IUnitOfWork unitOfWork
            )
        {
            _notificationServices = notificationServices;
            _unitOfWork = unitOfWork;

        }


        public async Task< IEnumerable< PurchaseOrderSummeryVM>> GetPurchaseOrderRecievedDetailsByCompanyId(int companyId,int isPendingBill, int pageId)
        {
            IEnumerable<PurchaseOrderSummeryVM> purchaseOrderSummeryVM;
           
                purchaseOrderSummeryVM = await  _unitOfWork.PurchaseOrderRecieveRepository.GetPurchaseOrderRecievedDetailsByCompanyId(companyId, isPendingBill,pageId);

           
            return purchaseOrderSummeryVM;
        }

        public async Task<PurchaseOrderMasterVM> GetPurchaseOrderRecieveDetailsByDocumentNo(string recieved)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            IEnumerable<PurchaseOrderItemVM> PurchaseOrderItemVm = new List<PurchaseOrderItemVM>();
            IEnumerable< PurchaseOrderItemVM> PurchaseOrderMasterItemVm = new List<PurchaseOrderItemVM>();
            List<PurchaseOrderItemVM> PurchaseOrderFinalItemVm = new List<PurchaseOrderItemVM>(150);

            using (_unitOfWork)
            {


                try
                {
                PurchaseOrderItemVm = await  _unitOfWork.PurchaseOrderRecieveRepository.GetPurchaseOrderRecieveDetailsByDocumentNo(recieved);
                purchaseOrderMasterVM.purchaseOrderItemVM = PurchaseOrderItemVm;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


        
           
            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> GetPurchaseOrderRecievedDetailsByPurchaseNo(string PurchaseOrderNo, int recieveTypeId, int isHistory)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            
              
                 
            using (_unitOfWork)
            {


                try
                {
                    purchaseOrderMasterVM = await _unitOfWork.PurchaseOrderRecieveRepository.GetPurchaseOrderRecievedDetailsByPurchaseNo(PurchaseOrderNo,recieveTypeId,isHistory);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdateAllPurchaseOrderRecieve(string PurchaseOrderNo, int recieveTypeId, int userId, int isBilled, int isRecieved)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            StockTransactionTypeVm stockTransactionTypeVm = new StockTransactionTypeVm();
            NotificationTypeVM notificationTypeVM = new NotificationTypeVM();
            int createdUserId = userId;
            MessageVM messageVM = new MessageVM();
            int StockRecieveNotificationTypeId = 5;



          
               
                  int  recievingId = 0;
                    /* Perform transactional work here */
            using (_unitOfWork)
            {


                try
                {
                    purchaseOrderMasterVM = await  _unitOfWork.PurchaseOrderRecieveRepository.UpdateAllPurchaseOrderRecieve(PurchaseOrderNo,recieveTypeId, userId,recievingId,isRecieved);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            try
                {

                        messageVM.NotificationTypeId = StockRecieveNotificationTypeId;
                        messageVM.Reference = PurchaseOrderNo;
                        messageVM.ReferenceUserId = createdUserId;
                        messageVM.TransactionNo = PurchaseOrderNo;
                            Task taskA = Task.Factory.StartNew(() =>
                                  _notificationServices.SendNotification(messageVM)
                              );
                            taskA.Dispose();

                   
                }
                catch (Exception ex)
                {

                }

         
            return purchaseOrderMasterVM;
        }

       
        public async Task<PurchaseOrderMasterVM> UpdatePartiallyPurchaseOrderRecieve(PurchaseOrderMasterVM purchaseOrderMasterVM, int isBilling)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            PurchaseOrderItemVM purchaseOrderItemVM = new PurchaseOrderItemVM();
            ExpireDateHandleVM expireDateHandleVM  = new ExpireDateHandleVM();
            int createdUserId = purchaseOrderMasterVM.UserId;
            MessageVM messageVM = new MessageVM();
           
            int StockPartiallyRecieveNotificationTypeId = 6;
            int recieveTypeId = purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(0).RecieveTypeId;




            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    for (int i = 0; i < purchaseOrderMasterVM.purchaseOrderItemVM.Count(); i++)
                    {

                        if (purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i).freeQuantity > 0 || purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i).RecievingQuantity > 0)
                        {
                            purchaseOrderItemVM = purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i);
                            purchaseOrderItemVM.RecieveTypeId = recieveTypeId;
                            purchaseOrderItemVM.UserId = purchaseOrderMasterVM.UserId;
                            purchaseOrderItemVM.RecievedQuantity = purchaseOrderItemVM.RecievingQuantity;
                            string PurchaseNo = purchaseOrderMasterVM.PurchaseNo;
                            purchaseOrderMasterVm = await _unitOfWork.PurchaseOrderRecieveRepository.UpdatePartiallyPurchaseOrderRecieve(purchaseOrderItemVM, PurchaseNo, isBilling);
                        }
                    }

                    if (purchaseOrderMasterVM.ExpireDateHandleVM.Count() > 0)
                    {

                        for (int i = 0; i < purchaseOrderMasterVM.ExpireDateHandleVM.Count(); i++)
                        {
                            expireDateHandleVM = await _unitOfWork.PurchaseOrderRecieveRepository.AddProductExpireDateDetails(purchaseOrderMasterVM.ExpireDateHandleVM.ElementAt(i));
                        }
                    }



                    _unitOfWork.CommitTransaction();



                    try
                    {
                        messageVM.NotificationTypeId = StockPartiallyRecieveNotificationTypeId;
                        messageVM.Reference = purchaseOrderMasterVM.PurchaseNo;
                        messageVM.TransactionNo = purchaseOrderMasterVM.PurchaseNo;


                        Task taskA = Task.Factory.StartNew(() =>
                                 _notificationServices.SendNotification(messageVM)
                             );
                        taskA.Dispose();


                    }
                    catch (Exception ex)
                    {

                    }

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return purchaseOrderMasterVm;
        }

    }
}
