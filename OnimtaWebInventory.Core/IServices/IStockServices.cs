﻿using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IStockServices
    {
        Task<StockVM> GetStockDetailsById(int stockId, int companyId);
        Task<IEnumerable<StockTransferSummeryVM>> GetStockTransactionDetails(int companyId);
        Task<IEnumerable<StockVM>> GetItemsBySupplierId(int supplierId, int companyId, string itemName);
        Task<IEnumerable<StockVM>> GetSupplierItem(int businessPartnerId);
        Task<StockTransactionTypeVm> GetIdByStockTransactionTypeId(int transactionTypeId,string refNo,int userId);

    }
}
