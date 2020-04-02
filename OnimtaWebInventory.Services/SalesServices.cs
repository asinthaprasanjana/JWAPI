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
    public class SalesServices : ISalesServices
    {

        private readonly IApprovalServices _approvalServices;
        private readonly INotificationServices _notificationServices;
        private readonly IUnitOfWork _unitOfWork;


        public SalesServices( IUnitOfWork unitOfWork, IApprovalServices approvalServices, INotificationServices notificationServices)
        {
            _approvalServices = approvalServices;
            _notificationServices = notificationServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<SalesSummaryVM> AddSalesSummeryDetails(SalesSummaryVM salesSummaryVM)
        {
            SalesSummaryVM newSalesSummaryVM = new SalesSummaryVM();
           
               
                    newSalesSummaryVM = await  _unitOfWork.SalesRepository.AddSalesSummeryDetails(salesSummaryVM);
                   
                
           
            return newSalesSummaryVM;
        }

        public async Task<SalesOrderItemVM> AddSalesOrderItemDetails(SalesOrderItemVM salesOrderItemVM)
        {
            SalesOrderItemVM salesOrderItem = new SalesOrderItemVM();
           
                    salesOrderItem = await  _unitOfWork.SalesRepository.AddSalesOrderItemDetails(salesOrderItemVM);
                  
            return salesOrderItem;
        }

        public async Task<SalesOrderItemVM> DeleteSalesOrderItemDetailsBySalesOrderId(int salesOrderId)
        {
            SalesOrderItemVM salesOrderItemVM = new SalesOrderItemVM();
            

                    salesOrderItemVM = await  _unitOfWork.SalesRepository.DeleteSalesOrderItemDetailsBySalesOrderId(salesOrderId);
                   
            return salesOrderItemVM;
        }

        public async Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderDraftSummaryDetailsByUserId(int companyId, int userId)
        {
            IEnumerable<SalesDraftSummaryVM> salesDraftSummaryVM;
           
                salesDraftSummaryVM = await  _unitOfWork.SalesRepository.GetSalesOrderDraftSummaryDetailsByUserId(companyId, userId);
             
            return salesDraftSummaryVM;
        }

        public async Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderDraftSummaryDetailsByCompanyId(int companyId)
        {
            IEnumerable<SalesDraftSummaryVM> salesDraftSummaryVM;
           
                salesDraftSummaryVM = await  _unitOfWork.SalesRepository.GetSalesOrderDraftSummaryDetailsByCompanyId(companyId);
              
            return salesDraftSummaryVM;
        }

        public async Task<IEnumerable<SalesDraftSummaryVM>> GetSalesOrderSummaryDetailsByCompanyId(int isApproved)
        {
            IEnumerable<SalesDraftSummaryVM> salesSummaryVM;
            
                salesSummaryVM = await  _unitOfWork.SalesRepository.GetSalesOrderSummaryDetailsByCompanyId(isApproved);
           
            return salesSummaryVM;
        }

        public async Task<IEnumerable<SalesViewVM>> GetSalesViewDetails(int companyId)
        {
            IEnumerable<SalesViewVM> salesViewVM;
           
                salesViewVM = await  _unitOfWork.SalesRepository.GetSalesViewDetails(companyId);
           
            return salesViewVM;
        }

        public async Task<SalesOrderMasterVM> GetSalesOrderDetailsById(string salesOrderId, int companyId, bool isDraft )
        {
            SalesOrderMasterVM salesOrderMasterVM = new SalesOrderMasterVM();
            
                    if (isDraft)
                    {
                        salesOrderMasterVM = await  _unitOfWork.SalesRepository.GetSalesOrderDraftDetailsById(salesOrderId, companyId);
                        salesOrderMasterVM.salesOrderItemVM = await  _unitOfWork.SalesRepository.GetSalesOrderItemDraftDetailsById(salesOrderId);
                    }
                    else
                    {
                        salesOrderMasterVM = await  _unitOfWork.SalesRepository.GetSalesOrderDetailsById(salesOrderId, companyId);
                        salesOrderMasterVM.salesOrderItemVM = await  _unitOfWork.SalesRepository.GetSalesOrderItemDetailsById(salesOrderId);
                    }

            
            return salesOrderMasterVM;
        }

        public async Task<IEnumerable<SalesOrderMasterVM>> GetSalesOrderDetailsBySaleOrderIds(string saleNos)
        {

            IEnumerable<SalesOrderMasterVM> salesOrderMasterVM;
           
                salesOrderMasterVM = await  _unitOfWork.SalesRepository.GetSalesOrderDetailsBySaleOrderIds(saleNos);
           
            return salesOrderMasterVM;

        }
        public async Task<IEnumerable<SalesOrderItemVM>> GetSalesOrderItemDetailsBySaleOrderIds(string saleNos)
        {

            IEnumerable<SalesOrderItemVM> salesOrderItemVM;
           
                salesOrderItemVM = await  _unitOfWork.SalesRepository.GetSalesOrderItemDetailsBySaleOrderIds(saleNos);
           
            return salesOrderItemVM;

        }

        public async Task<IEnumerable<SalesOrderMasterVM>> GetSalesOrderDetailsByBusinessPartnerId(string businessPartnerId, int companyId)
        {
            IEnumerable<SalesOrderMasterVM> salesOrderMasterVM;
            
                   salesOrderMasterVM = await  _unitOfWork.SalesRepository.GetSalesOrderDetailsByBusinessPartnerId(businessPartnerId, companyId);
           
            return salesOrderMasterVM;
        }


        public async Task<SalesOrderFinalVM> UpdateSalesOrderById(SalesOrderFinalVM salesOrderFinalVM)
        {
            SalesOrderFinalVM salesOrderFinalVm = new SalesOrderFinalVM();
            MessageVM messageVM = new MessageVM();
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();
            ApprovalVM approvalVM = new ApprovalVM();
            ApprovalVM returnapprovalVM = new ApprovalVM();
            string[] OfficersId = new string[1000];
            int SalesOrderNotificationTypeId = 22;
            int SalesOrderApprovalTypeId = 8;

          

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    salesOrderFinalVm = await  _unitOfWork.SalesRepository.UpdateSalesOrderById(salesOrderFinalVM);
                    functionApprovalTypeVm = await _approvalServices.GetFunctionApprovalDetailsByFunctionId(SalesOrderApprovalTypeId,SalesOrderNotificationTypeId, salesOrderFinalVm.DocumentNo, salesOrderFinalVM.UserId,1);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }







            return salesOrderFinalVm;
        }

            public async Task<SalesSummaryVM> GetSalesSummeryDetails(int companyId)
        {
            SalesSummaryVM salesSummaryVM = new SalesSummaryVM();
           
               
                    // Save SO details from draft to original table 
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    salesSummaryVM = await  _unitOfWork.SalesRepository.GetSalesSummeryDetails(companyId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return salesSummaryVM;
        }
    }
}
