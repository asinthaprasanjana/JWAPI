using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OnimtaWebInventory.Core.IServices.IJewelleryService
{
    public interface IJewelleryProductServices
    {
        Task<JewelleryProductVM> AddJewelleryProduct(JewelleryProductVM jewelleryProduct);
        Task<IEnumerable<JewelleryProductVM>> GetAllJewelleryProductDetails(FilterVM Filter);
        Task<JewelleryProductVM> GetJewelleryProductDetailsById(int id);
        Task<JewelleryProductVM> DeleteJewelleryProduct(int id);
        Task<JewelleryProductVM> UpdateJewelleryProductDetails(JewelleryProductVM jewelleryProductVM);
        Task<JewelleryProductVM> UpdateJewelleryImage(int Id, Boolean Add);
        Task<IEnumerable<JewelleryProductVM>> ImportProductExcel(Boolean autoGenItemCode,IFormFile file);
        Task<IEnumerable<JewelleryProductVM>> ImportProductExcelBarCode(IFormFile file);
        Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetailsByItemCode(string itemCode, int pageId);
        Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetailsByItemCode_All(string itemCode, int pageId);

        Task<TraySlotVM> UpdateTraySlotDetails(int trayId, int sectionId, int productId, int traySlot);
        Task<IEnumerable<JewelleryProductVM>> GetJewelleryProductLogByProductId(int id);
        Task<IEnumerable<JewelleryProductVM>> SearchJewelleryProductDetails(string itemCode, string description, int pageId);

        Task<GoldRateVM> AddGoldRateDetail(GoldRateVM goldRateVM);
        Task<IEnumerable<GoldRateVM>> GetAllGoldRateDetails();
        Task<GoldRateVM> GetGoldRateDetailsByDate();
        Task<GoldRateVM> UpdateGoldRateDetail(GoldRateVM goldRateVM);
        Task<GoldRateVM> GetReceiptNumber();

        Task<IEnumerable<JewelleryProductVM>> JewelleryProductTransfer();

        Task<IEnumerable<JewelleryTransferVM>> GetAllJewelleryTransfers(FilterVM filter);
        Task<JewelleryTransferVM> GetJewelleryTransferByTransferId(int TransferId);
        Task<JewelleryTransferVM> AddJewelleryTransfer(JewelleryTransferVM jewelleryTransfer);
        Task<JewelleryTransferVM> CancellTransfer(JewelleryTransferVM Transfer);

    }
}
 
 