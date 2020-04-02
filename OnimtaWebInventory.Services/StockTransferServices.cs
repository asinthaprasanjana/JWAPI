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
   public  class StockTransferServices : IStockTransferServices
    {
        private readonly IApprovalServices _approvalServices;
        private readonly INotificationServices _notificationServices;
        private readonly IUnitOfWork _unitOfWork;




        public StockTransferServices( IUnitOfWork unitOfWork, IApprovalServices approvalServices, INotificationServices notificationServices)
        {
            _approvalServices = approvalServices;
            _notificationServices = notificationServices;
            _unitOfWork = unitOfWork;
        }

        public async  Task<StockTransferItemVM> AddStockTransferItemDraft( StockTransferItemVM stockTransferItemVM)
        {
            StockTransferItemVM stockTransferItemVm = new StockTransferItemVM();
           

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    stockTransferItemVm = await  _unitOfWork.StockTransferRepository.AddStockTransferItemDraft(stockTransferItemVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return stockTransferItemVm;
        }

        public async Task<StockTransferSummeryVM> updateStockTransferDetails(int transferId)
        {
            StockTransferSummeryVM stockTransferSummeryVM = new StockTransferSummeryVM();
            ApprovalVM approvalVM = new ApprovalVM();
            ApprovalVM returnapprovalVM = new ApprovalVM();
            //int StockTranferApprovalTypeId = 2;
            int createdUserId = stockTransferSummeryVM.CreatedUserId;
            MessageVM messageVM = new MessageVM();
           
            NotificationTypeVM notificationTypeVM  = new NotificationTypeVM();
            ApprovalEventVM approvalEventVM = new ApprovalEventVM();

            int StockTranferNotificationTypeId = 2;
           
                
                  
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
          /* Perform transactional work here */
                            stockTransferSummeryVM = await  _unitOfWork.StockTransferRepository.updateStockTransferDetails(transferId);
                

                        try
                        {

                                messageVM.NotificationTypeId = StockTranferNotificationTypeId;
                                messageVM.Reference = stockTransferSummeryVM.TransferId;
                                messageVM.TransactionNo = stockTransferSummeryVM.TransferId;
                                messageVM.ReferenceUserId = createdUserId;
                                await _notificationServices.SendNotification(messageVM);

                        }
                        catch (Exception ex)
                        {

                        }
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVM;
        }

        public async Task<StockTransferSummeryVM> AddStockTransferSummeryDetailsDraft(StockTransferSummeryVM stockTransferSummeryVM)
        {
            StockTransferSummeryVM stockTransferSummeryVm = new StockTransferSummeryVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    stockTransferSummeryVm = await  _unitOfWork.StockTransferRepository.AddStockTransferSummeryDraftDetails(stockTransferSummeryVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVm;
        }

        public async Task<StockTransferItemVM> DeleteStockTransferItemById(int Id)
        {
            StockTransferItemVM stockTransferItemVm = new StockTransferItemVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    stockTransferItemVm = await  _unitOfWork.StockTransferRepository.DeleteStockTransferItemById(Id);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return stockTransferItemVm;
        }

        public async Task<StockTransferSummeryVM> GetStockTransferDetailsById(int transferId,int companyId)
        {
            StockTransferSummeryVM stockTransferSummeryVM = new StockTransferSummeryVM();
           
            using (_unitOfWork)
            {


                try
                {
                stockTransferSummeryVM = await  _unitOfWork.StockTransferRepository.GetStockTransferDetailsById(transferId, companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVM;
        }

        public async  Task<IEnumerable<StockTransferSummeryVM>> GetStockTransferId(int companyId)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            
            using (_unitOfWork)
            {


                try
                {
                stockTransferSummeryVM = await  _unitOfWork.StockTransferRepository.GetStockTransferId(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVM;
        }

     public async  Task<IEnumerable<StockTransferSummeryVM>>GetStockTransferSummaryDetails(int companyId )
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
           
            using (_unitOfWork)
            {


                try
                {
                   stockTransferSummeryVM = await  _unitOfWork.StockTransferRepository.GetStockTransferId(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVM;
        }

       

        public async Task<IEnumerable<StockTransferSummeryVM>> GetAllTransferSummeryDraft()
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
           
            using (_unitOfWork)
            {


                try
                {
                    stockTransferSummeryVM = await  _unitOfWork.StockTransferRepository.GetAllTransferSummeryDraft();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockTransferItemVM>> GetStockTransferItemDraftByTransferId(string TransferId)
        {
            IEnumerable<StockTransferItemVM> StockTransferItemVM;
           
            using (_unitOfWork)
            {


                try
                {
                    StockTransferItemVM = await  _unitOfWork.StockTransferRepository.GetStockTransferItemDraftByTransferId(TransferId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return StockTransferItemVM;
        }

        public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetailsByDestinationId(int BranchId)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
           
            using (_unitOfWork)
            {


                try
                {
                    stockTransferSummeryVM = await  _unitOfWork.StockTransferRepository.GetStockTranferSummeryDetailsByDestinationId(BranchId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockTransferItemVM>> GetStockTransferItemByTransferId(string TransferId)
        {
            IEnumerable<StockTransferItemVM> StockTransferItemVM;
           
            using (_unitOfWork)
            {


                try
                {
                    StockTransferItemVM = await  _unitOfWork.StockTransferRepository.GetStockTransferItemByTransferId(TransferId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return StockTransferItemVM;
        }

        public async Task<StockTransferSummeryVM> UpdateStockTransferSummeryDetailsByTransferId(StockTransferSummeryVM stockTransferSummeryVM)
        {
            StockTransferSummeryVM stockTransferSummeryVm = new StockTransferSummeryVM();
           
               
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    stockTransferSummeryVm = await  _unitOfWork.StockTransferRepository.UpdateStockTransferSummeryDetailsByTransferId(stockTransferSummeryVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVm;
        }

        public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetailsBySourceId(int BranchId)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
            
            using (_unitOfWork)
            {

                try
                {
                    stockTransferSummeryVM = await  _unitOfWork.StockTransferRepository.GetStockTranferSummeryDetailsBySourceId(BranchId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTranferSummeryDetails(int pageNumber, int rows)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;

            using (_unitOfWork)
            {

                try
                {
                    stockTransferSummeryVM = await _unitOfWork.StockTransferRepository.GetStockTranferSummeryDetails(pageNumber,rows);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return stockTransferSummeryVM;
        }
    }
}
