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
    public class QuotationServices : IQuotationServices
    {
        private readonly INotificationServices _notificationServices;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApprovalServices _approvalServices;



        public QuotationServices( IUnitOfWork unitOfWork, IApprovalServices approvalServices,INotificationServices notificationServices )
        {
            _notificationServices = notificationServices;
            _approvalServices = approvalServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseOrderMasterVM> AddNewQuotationDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVMs;
            MessageVM messageVM = new MessageVM();
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();
            ApprovalVM approvalVM = new ApprovalVM();
            ApprovalVM returnapprovalVM = new ApprovalVM();
            string[] OfficersId = new string[1000];


            int SalesOrderQuatationNotificationTypeId = 21;
            int SalesOrderQuatationApprovalTypeId = 7;
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                 purchaseOrderMasterVm = await  _unitOfWork.QuotationRepository.AddNewQuotationDetails(purchaseOrderMasterVM);

                                    for(int i = 0; i < purchaseOrderMasterVM.purchaseOrderItemVM.Count(); i++) {
                                        purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i).QuotationId = purchaseOrderMasterVm.QuotationId;
                                        purchaseOrderItemVMs = await  _unitOfWork.QuotationRepository.AddSalesQuotationProducts(purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i));
                                    }

                                    functionApprovalTypeVm =await  _approvalServices.GetFunctionApprovalDetailsByFunctionId(SalesOrderQuatationApprovalTypeId, SalesOrderQuatationNotificationTypeId, purchaseOrderMasterVm.QuotationId, purchaseOrderMasterVm.UserId, 1);

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

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllQuotationDetails(int branchId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM ;

           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderMasterVM = await  _unitOfWork.QuotationRepository.GetAllQuotationDetails(branchId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderMasterVM;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllQuotationSummeryByBranchId(int branchId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;

           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderMasterVM = await  _unitOfWork.QuotationRepository.GetAllQuotationSummeryByBranchId(branchId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            return purchaseOrderMasterVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetAllSalesQuotaionProductByQuotationId(int quotationId)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;

           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderItemVM = await  _unitOfWork.QuotationRepository.GetAllSalesQuotaionProductByQuotationId(quotationId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            return purchaseOrderItemVM;
        }

        public async Task<PurchaseOrderMasterVM> GetQuotationDetailsById(int id)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;

            
              
            using (_unitOfWork)
            {


                try
                {
               purchaseOrderMasterVM = await  _unitOfWork.QuotationRepository.GetQuotationDetailsById(id);
                purchaseOrderItemVM = await  _unitOfWork.QuotationRepository.GetAllSalesQuotaionProductByQuotationId(id);
                purchaseOrderMasterVM.purchaseOrderItemVM = purchaseOrderItemVM;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdateQuotationDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();

           
            using (_unitOfWork)
            {


                try
                {
                    purchaseOrderMasterVM = await  _unitOfWork.QuotationRepository.UpdateQuotationDetails(purchaseOrderMasterVM);

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
