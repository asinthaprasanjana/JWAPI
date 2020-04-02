using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IProductRepository
    {
        Task<ProductVM> GetProductDetailsByProductId(int productId, int companyId);
        Task<ProductVM> GetProductDetailsById(int productId);
        Task<ProductVM> UpdateProductDetails(ProductVM productVM);
        Task<IEnumerable<ProductVM>> GetProductAllDetails();
        

        Task<BasicProductDetailsVM> AddProductDetails(BasicProductDetailsVM basicProductDetails);

        Task<PriceCategoryVM> AddPriceCategoryDetails(PriceCategoryVM priceCategoryVM);
        Task<PriceCategoryVM> UpdatePriceCategoryDetails(PriceCategoryVM priceCategoryVM);
        Task<IEnumerable<PriceCategoryVM>> GetPriceCategoryDetails();
        Task<PriceCategoryVM> DeletePriceCategoryDetails(int id);


        Task<IEnumerable<BranchVM>> GetPriceLevelBranchDetails();

        Task<PriceLevelVM> AddPriceLevelDetails(PriceLevelVM priceLevelVM);
        Task<PriceLevelVM> AddPriceLevelItemsDetails(Data data);
        Task<PriceLevelVM> UpdatePriceLevelItemsDetails(Data data);
        Task<PriceLevelVM> UpdatePriceLevelDetails(PriceLevelVM priceLevelVM);
        Task<IEnumerable<PriceLevelVM>> GetCompanyPriceLevelDetails(int ProductId);
        Task<IEnumerable<PriceLevelVM>> GetProductPriceByProductLevelId(Data data);


        Task<IEnumerable<PriceLevelBasicDetailsVM>> GetPriceLevelDetails(int branchId , int ref1 ,int ref2, int ref3 );

        Task<PackSizeVM> AddProductPackSize(PackSizeVM packSizeVM);
        Task<IEnumerable<PackSizeVM>> GetPackSizeDetailsByProductId(int productId);


        Task<IEnumerable<PurchaseOrderRequestItemsViewVm>> GetAllProductDetails();
       

        Task<CommonAttributesValuesVM> AddAttributeValues(CommonAttributesValuesVM commonAttributesValues);

        Task<CheckingDetailsVM> AddCheckingDetails(int branchId,CheckingDetailsVM checkingDetails);
               

        Task<IEnumerable<ProductVM>> GetProducts(int pageNumber, int rowsPage);
        Task<IEnumerable<CheckingDetailsVM>> GetCheckingDetailsByProductId(int productId);

        Task<ProductVM> DeleteProductByProductId(int productId);

    }
}
