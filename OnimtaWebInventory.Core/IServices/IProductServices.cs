using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IProductServices
    {
        Task<ProductVM> GetProductDetailsByProductId(int productId, int companyId);
        Task<ProductVM> AddProductDetails( ProductVM productVM);
        Task<IEnumerable<ProductVM>> GetProductAllDetails();
        Task<ProductVM> GetProductDetailsById(int productId);
        Task<ProductVM> UpdateProductDetails(ProductVM productVM);
        Task<IEnumerable<ProductVM>> GetProducts(int pageNumber, int rowsPage);


        Task<PriceCategoryVM> AddPriceCategoryDetails(PriceCategoryVM priceCategoryVM);
        Task<PriceCategoryVM> UpdatePriceCategoryDetails(PriceCategoryVM priceCategoryVM);
        Task<IEnumerable<PriceCategoryVM> >GetPriceCategoryDetails();
        Task<PriceCategoryVM> DeletePriceCategoryDetails(int id);

        Task<PriceLevelVM> AddProductPriceLevelDetails(PriceLevelVM priceLevelVM);
        Task<PriceLevelVM> UpdateProductPriceLevelDetails(PriceLevelVM priceLevelVM);
        Task<IEnumerable <PriceLevelVM> >GetPriceLevelDetails(int productId , int ref1,int ref2);

        Task<IEnumerable<PurchaseOrderRequestItemsViewVm>> GetAllProductDetails();

       
        Task<IEnumerable<PackSizeVM>> GetPackSizeDetailsByProductId(int productId);

        Task<IEnumerable<PriceLevelVM>> GetCompanyPriceLevelDetails(int ProductId);
        Task<IEnumerable<PriceLevelVM>> GetProductPriceByProductLevelId(Data data);

        Task<ProductVM> DeleteProductByProductId(int productId);



    }
}
