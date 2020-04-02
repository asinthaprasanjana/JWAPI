using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services
{
   public  class StockServices : IStockServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public StockServices(IStockRepository IStockRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<StockTransactionTypeVm> GetIdByStockTransactionTypeId(int transactionTypeId, string refNo,int userId)
        {
            StockTransactionTypeVm stockTransactionTypeVm = new StockTransactionTypeVm();
           
                stockTransactionTypeVm = await  _unitOfWork.StockRepository.GetIdByStockTransactionTypeId(transactionTypeId,refNo,userId);

            
            return stockTransactionTypeVm;
        }

        public async  Task<IEnumerable<StockVM>> GetItemsBySupplierId(int supplierId,int companyId, string itemName)
        {
            IEnumerable<StockVM> stockVM;
            
                stockVM = await  _unitOfWork.StockRepository.GetItemsBySupplierId(supplierId,companyId,itemName);
            
            return stockVM;
        }
        public async Task<StockVM> GetStockDetailsById(int stockId,int companyId)
        {
            StockVM stockVM = new StockVM();
           
                stockVM = await  _unitOfWork.StockRepository.GetStockDetailsById(stockId, companyId);
            
            return stockVM;
        }
      public async Task<IEnumerable<StockTransferSummeryVM>> GetStockTransactionDetails(int companyId)
        {
            IEnumerable<StockTransferSummeryVM> stockTransferSummeryVM;
           
                stockTransferSummeryVM = await  _unitOfWork.StockRepository.GetStockTransactionDetails(companyId);
            
            return stockTransferSummeryVM;
        }

        public async Task<IEnumerable<StockVM>> GetSupplierItem(int businessPartnerId)
        {
            IEnumerable<StockVM> stockVm;
            
                stockVm = await  _unitOfWork.StockRepository.getSupplierItem(businessPartnerId);
           
            return stockVm;
        }
    }
}
