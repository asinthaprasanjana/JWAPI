using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using SignalRHub;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class CancellationServices : ICancellationServices
    {
        private readonly INotificationServices _notificationServices;
        private readonly IApprovalServices _approvalServices;
        private readonly IUnitOfWork _unitOfWork;




        public CancellationServices( IUnitOfWork unitOfWork, INotificationServices notificationServices, IApprovalServices approvalServices)
        {
            _notificationServices = notificationServices;
            _approvalServices = approvalServices;
            _unitOfWork = unitOfWork;

        }

        public async Task<CancellationVM> AddNewCancellationDetails(CancellationVM cancellationVM)
        {
            CancellationVM cancellationVm = new CancellationVM();

            cancellationVM = await  _unitOfWork.CancellationRepository.AddNewCancellationDetails(cancellationVM);

            return cancellationVM;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetCancellationData(int typeId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

            using (_unitOfWork)
            {


                try
                {
                    purchaseOrderMasterVM = await  _unitOfWork.CancellationRepository.GetCancellationData(typeId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }



            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> GetCancellationSummaryData(int typeId, string id)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            using (_unitOfWork)
            {


                try
                {
                   purchaseOrderMasterVM = await  _unitOfWork.CancellationRepository.GetCancellationSummaryData(typeId, id);
                   purchaseOrderMasterVM.purchaseOrderItemVM = await  _unitOfWork.CancellationRepository.GetCancellationProductData(typeId, id);
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

            

            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> updateCancellationData(int cancellationTypeId, string referenceNo, int notificationTypeId, string reason, int isCancelled, int userId)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();

            MessageVM messageVM = new MessageVM();

            using (_unitOfWork)
            {


                try
                {
                    purchaseOrderMasterVM = await  _unitOfWork.CancellationRepository.updateCancellationData(cancellationTypeId, referenceNo, isCancelled, userId);
                    functionApprovalTypeVm = await _approvalServices.GetFunctionApprovalDetailsByFunctionId(cancellationTypeId, notificationTypeId, referenceNo, userId, 1);



                    try
                    {


                        //switch (notificationTypeId)
                        //{
                        //    case 1:
                        //        this.NotificationHeader = "Purchase Order";
                        //        this.NotifcationBody = "You have a pending approval for" + " " + reference;

                        //        this.BroadCastUserList = true;
                        //        break;

                        //    case 2:
                        //        this.NotificationHeader = "Stock Tranfer";
                        //        this.NotifcationBody = "Stock Transfer has been taken placed Transfer No -" + " " + reference;
                        //        this.BroadCastUserList = true;

                        //        break;

                        //}
                        messageVM.NotificationTypeId = 0;
                        messageVM.Reference = referenceNo;

                        await _notificationServices.SendNotification(messageVM);

                    }
                    catch (Exception ex)
                    {

                    }

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
          

                return purchaseOrderMasterVM;

            
            }
    }
}
