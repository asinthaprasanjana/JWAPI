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
    public class StockAdjusmentServices : IStockAdjusmentServices
    {
        private readonly INotificationServices _notificationServices;
        private readonly IApprovalServices _approvalServices;
        private readonly IUnitOfWork _unitOfWork;




        public StockAdjusmentServices(   IUnitOfWork unitOfWork, INotificationServices notificationServices, IApprovalServices approvalServices)
        {
            _approvalServices = approvalServices;
            _notificationServices = notificationServices;
            _unitOfWork = unitOfWork;

        }
        public async Task <IEnumerable< StockAdjustmentSummeryVM>> GetStockAdjusmentSummeryByCompanyId(int companyId)
        {
           IEnumerable< StockAdjustmentSummeryVM> stockAdjustmentSummeryVM;
           

            using (_unitOfWork)
            {


                try
                {
                stockAdjustmentSummeryVM = await  _unitOfWork.StockAdjusmentRepository.GetStockAdjusmentSummeryByCompanyId(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return stockAdjustmentSummeryVM;
        }

       

        public async Task<StockAdjustmentSummeryVM> GetStockAdjusmentId(int companyId)
        {
            StockAdjustmentSummeryVM stockAdjustmentSummeryVM;
            
            using (_unitOfWork)
            {


                try
                {
                stockAdjustmentSummeryVM = await  _unitOfWork.StockAdjusmentRepository.GetStockAdjusmentId(companyId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockAdjustmentSummeryVM;
        }


        public async Task<StockAdjustmentDetailVM> AddstockAdjusmentDetails(IEnumerable<StockAdjustmentDetailVM> stockAdjustmentItemVM)
        {
            StockAdjustmentDetailVM stockAdjustmentItemVm = new StockAdjustmentDetailVM();
        
            int createdUserId = stockAdjustmentItemVM.ElementAt(0).CreatedUserId;
            MessageVM messageVM = new MessageVM();
            string branchId = "";
            int StockAdjusmentNotificationTypeId = 3;
            int StockAdjusmentApprovalNotificationTypeId = 9;

            int StockAdjusmentApprovalTypeId = 3;
            int companyId = 1;

            NotificationTypeVM notificationTypeVM  = new NotificationTypeVM();
            StockAdjustmentSummeryVM stockAdjustmentSummeryVM = new StockAdjustmentSummeryVM();
            StockAdjustmentSummeryVM stockAdjustmentSummeryVm = new StockAdjustmentSummeryVM();
            FunctionApprovalTypeVm functionApprovalTypeVm = new FunctionApprovalTypeVm();


            
                  
                    stockAdjustmentSummeryVM.BranchId = stockAdjustmentItemVM.ElementAt(0).BranchId;
                    stockAdjustmentSummeryVM.CompanyID = stockAdjustmentItemVM.ElementAt(0).CompanyId;
                    stockAdjustmentSummeryVM.CreatedUserId = stockAdjustmentItemVM.ElementAt(0).CreatedUserId;
                    branchId = stockAdjustmentItemVM.ElementAt(0).BranchId.ToString();



                  
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                      stockAdjustmentSummeryVm = await  _unitOfWork.StockAdjusmentRepository.AddStockAdjusmentSummeryDetails(stockAdjustmentSummeryVM);

                                        for (int i = 0; i < stockAdjustmentItemVM.Count(); i++)
                                        {
                                            stockAdjustmentItemVM.ElementAt(i).StockAdjustmentId = stockAdjustmentSummeryVm.StockAdjustmentId;
                                            stockAdjustmentItemVm = await  _unitOfWork.StockAdjusmentRepository.AddstockAdjusmentDetails(stockAdjustmentItemVM.ElementAt(i));

                                        }

                                        // get approval details for Purchase Order by approvaltypeId
                                           functionApprovalTypeVm =await _approvalServices.GetFunctionApprovalDetailsByFunctionId(StockAdjusmentApprovalTypeId, StockAdjusmentApprovalNotificationTypeId, stockAdjustmentSummeryVm.StockAdjustmentId, createdUserId ,companyId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return stockAdjustmentItemVm;
        }

        public async Task<IEnumerable<StockAdjustmentDetailVM>> GetProductStockCountByBranchId(int BranchId, int ProductId)
        {
            IEnumerable<StockAdjustmentDetailVM> StockAdjustmentDetailVm;
           
            using (_unitOfWork)
            {


                try
                {
                StockAdjustmentDetailVm = await  _unitOfWork.StockAdjusmentRepository.GetProductStockCountByBranchId(BranchId, ProductId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return StockAdjustmentDetailVm;
        }

        public async Task<StockAdjustmentSummeryVM> GetStockAdjusmentDetailsByAdjusmentId(string StockAdjustmentId)
        {
            StockAdjustmentSummeryVM StockAdjustmentDetailVm = new StockAdjustmentSummeryVM();
            
            using (_unitOfWork)
            {


                try
                {
                StockAdjustmentDetailVm = await  _unitOfWork.StockAdjusmentRepository.GetStockAdjusmentSummeryByAdjusmentId(StockAdjustmentId);
                StockAdjustmentDetailVm.stockAdjustmentDetailVM = await  _unitOfWork.StockAdjusmentRepository.GetStockAdjusmentDetailsByAdjusmentId(StockAdjustmentId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return StockAdjustmentDetailVm;
        }

        public async Task<IEnumerable<StockAdjustmentSummeryVM>> GetStockAdjusmentSummeryByBranchId(int BranchId)
        {
            IEnumerable<StockAdjustmentSummeryVM> stockAdjustmentSummeryVM;
           
            using (_unitOfWork)
            {


                try
                {
                stockAdjustmentSummeryVM = await  _unitOfWork.StockAdjusmentRepository.GetStockAdjusmentSummeryByBranchId(BranchId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockAdjustmentSummeryVM;
        }
    }
}
