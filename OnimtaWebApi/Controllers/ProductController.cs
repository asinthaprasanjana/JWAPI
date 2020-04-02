using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.PriceCategory;
using OnimtaWebInventory.DTO.Product;
using OnimtaWebInventory.DTO.ProductPriceLevel;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class ProductController : Controller
    {
        private IProductServices _productServices;
        private ILogger<ProductController> _logger;

        public ProductController(IProductServices ProductServices, ILogger<ProductController> logger)
        {
            _productServices = ProductServices;
            _logger = logger;
        }
        [HttpGet("{productId},{companyId}")]
        public async Task<ProductResponse> GetProductDetailsByProductId(int productId, int companyId)
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<ProductVM> productVM;
            try
            {
                productVM = new List<ProductVM>
                {
                    await _productServices.GetProductDetailsByProductId(productId,companyId)
                };
                productResponse.productVM = productVM;
                productResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                productResponse.IsSuccess = false;
                productResponse.Message = exc.Message;

            }
            return productResponse;
        }

        [HttpGet]
        public async Task<ProductResponse> GetAllProductDetails()
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<PurchaseOrderRequestItemsViewVm> productVM;
            try
            {

                productVM = await _productServices.GetAllProductDetails();

                productResponse.purchaseOrderRequestItemsViewVm = productVM;
                productResponse.IsSuccess = true;
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                productResponse.IsSuccess = false;
                productResponse.Message = exc.Message;

            }
            return productResponse;
        }

        [HttpPost]
        public async Task<ProductResponse> AddProductDetails([FromBody] ProductRequest productRequest)
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<ProductVM> productVm;
            try
            {
                productVm = new List<ProductVM>{
                    await _productServices.AddProductDetails(productRequest.productVM)
                };
                productResponse.IsSuccess = true;
                productResponse.productVM = productVm;
                _logger.LogInformation(productRequest.ToString());

            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
                productResponse.IsSuccess = false;
                productResponse.Message = exc.Message;
            }
            return productResponse;
        }

        [HttpPost]
        public async Task<PriceCategoryResponse> AddPriceCategoryDetails([FromBody]PriceCategoryRequest priceCategoryRequest)
        {
            PriceCategoryResponse priceCategoryResponse = new PriceCategoryResponse();
            IEnumerable<PriceCategoryVM> priceCategoryVM;
            try
            {
                priceCategoryVM = new List<PriceCategoryVM>
                {
                    await _productServices.AddPriceCategoryDetails(priceCategoryRequest.priceCategoryVM)
                };
                priceCategoryResponse.priceCategoryVM = priceCategoryVM;
                priceCategoryResponse.IsSuccess = true;
                _logger.LogInformation(priceCategoryRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                priceCategoryResponse.IsSuccess = false;
                priceCategoryResponse.Message = ex.Message;
            }
            return priceCategoryResponse;
        }

        [HttpPost]
        public async Task<ProductResponse> AddProductPriceLevelDetails([FromBody]ProductRequest productRequest)
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<PriceLevelVM> priceLevelVm;
            try
            {
                priceLevelVm = new List<PriceLevelVM>
                {
                    await _productServices.AddProductPriceLevelDetails(productRequest.priceLevelVM)
                };
                productResponse.priceLevelVM = priceLevelVm;
                productResponse.IsSuccess = true;
                _logger.LogInformation(productRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productResponse.IsSuccess = true;
                productResponse.Message = ex.Message;
            }
            return productResponse;
        }

        [HttpPut]
        public async Task<ProductResponse> UpdateProductPriceLevelDetails([FromBody]ProductRequest productRequest)
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<PriceLevelVM> priceLevelVm;
            try
            {
                priceLevelVm = new List<PriceLevelVM>
                {
                    await _productServices.UpdateProductPriceLevelDetails(productRequest.priceLevelVM)
                };
                productResponse.priceLevelVM = priceLevelVm;
                productResponse.IsSuccess = true;
                _logger.LogInformation(productRequest.ToString());

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productResponse.IsSuccess = true;
                productResponse.Message = ex.Message;
            }
            return productResponse;
        }

        [HttpGet]
        public async Task<PriceCategoryResponse> GetPriceCategoryDetails()
        {
            PriceCategoryResponse priceCategoryResponse = new PriceCategoryResponse();
            IEnumerable<PriceCategoryVM> priceCategoryVM;
            try
            {
                priceCategoryVM = await _productServices.GetPriceCategoryDetails();
                priceCategoryResponse.priceCategoryVM = priceCategoryVM;
                priceCategoryResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                priceCategoryResponse.IsSuccess = false;
                priceCategoryResponse.Message = ex.Message;
            }
            return priceCategoryResponse;
        }

        [HttpGet("{productId},{PriceLevelId}")]
        public async Task<ProductPriceLevelResponse> GetPriceLevelItemsDetails(int productId, int PriceLevelId)
        {
            ProductPriceLevelResponse productPriceLevelResponse = new ProductPriceLevelResponse();
            IEnumerable<PriceLevelVM> priceLevelVM;
            try
            {
                priceLevelVM = await _productServices.GetPriceLevelDetails(productId, PriceLevelId, 0);
                productPriceLevelResponse.priceLevelVM = priceLevelVM;
                productPriceLevelResponse.IsSuccess = true;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productPriceLevelResponse.IsSuccess = false;
                productPriceLevelResponse.Message = ex.Message;
            }
            return productPriceLevelResponse;
        }

        [HttpGet]
        public async Task<ProductResponse> GetProductAllDetails()
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<ProductVM> productVM;

            try
            {
                productVM = await _productServices.GetProductAllDetails();
                productResponse.productVM = productVM;
                productResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productResponse.IsSuccess = false;
                productResponse.Message = ex.Message;
            }
            return productResponse;
        }

        [HttpGet("{productId}")]
        public async Task<ProductResponse> GetProductDetailsById(int productId)
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<ProductVM> productVM;

            try
            {
                productVM = new List<ProductVM>{

                    await _productServices.GetProductDetailsById(productId)

                };
                productResponse.productVM = productVM;
                productResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productResponse.IsSuccess = false;
                productResponse.Message = ex.Message;
            }
            return productResponse;
        }

        [HttpPut]
        public async Task<ProductResponse> UpdateProductDetails([FromBody]ProductRequest productRequest)
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<ProductVM> productVM;

            try
            {
                productVM = new List<ProductVM>
                {
                    await _productServices.UpdateProductDetails(productRequest.productVM)
                };
                productResponse.productVM = productVM;
                productResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productResponse.IsSuccess = false;
                productResponse.Message = ex.Message;
            }
            return productResponse;
        }

        [HttpGet("{productId},{companyId}")]
        public async Task<PackSizeResponse> GetPackSizeDetailsByProductId(int productId)
        {
            PackSizeResponse packSizeResponse = new PackSizeResponse();
            IEnumerable<PackSizeVM> packSizeVM;
            try
            {
                packSizeVM = await _productServices.GetPackSizeDetailsByProductId(productId);
                packSizeResponse.packSizeVM = packSizeVM;
                packSizeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                packSizeResponse.IsSuccess = false;
                packSizeResponse.Message = ex.Message;
            }
            return packSizeResponse;
        }

        [HttpGet("{pageNumber},{rowsPage}")]
        public async Task<ProductResponse> GetProducts(int pageNumber, int rowsPage)
        {
            ProductResponse productResponse = new ProductResponse();
            IEnumerable<ProductVM> productVMs;
            try
            {
                productVMs = await _productServices.GetProducts(pageNumber, rowsPage);
                productResponse.productVM = productVMs;
                productResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productResponse.IsSuccess = false;
                productResponse.Message = ex.Message;
            }
            return productResponse;
        }

        [HttpGet("{ProductId}")]
        public async Task<ProductPriceLevelResponse> GetCompanyPriceLevelDetails(int ProductId)
        {
            ProductPriceLevelResponse productPriceLevelResponse = new ProductPriceLevelResponse();
            IEnumerable<PriceLevelVM> priceLevelVM;

            try
            {
                priceLevelVM = await _productServices.GetCompanyPriceLevelDetails(ProductId);
                productPriceLevelResponse.priceLevelVM = priceLevelVM;
                productPriceLevelResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productPriceLevelResponse.IsSuccess = false;
                productPriceLevelResponse.Message = ex.Message;
            }
            return productPriceLevelResponse;
        }


        [HttpGet("{productId},{priceCategory},{BranchId},{PackSizeId}")]
        public async Task<ProductPriceLevelResponse> GetProductPriceByProductLevelId(int productId, int priceCategory, int BranchId, int PackSizeId)
        {
            ProductPriceLevelResponse productPriceLevelResponse = new ProductPriceLevelResponse();
            IEnumerable<PriceLevelVM> priceLevelVM;
            Data data = new Data();
            data.BranchId = BranchId;
            data.PackSizeId = PackSizeId;
            data.PriceType = priceCategory;
            data.ProductId = productId;
            try
            {
                priceLevelVM = await _productServices.GetProductPriceByProductLevelId(data);
                productPriceLevelResponse.priceLevelVM = priceLevelVM;
                productPriceLevelResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productPriceLevelResponse.IsSuccess = false;
                productPriceLevelResponse.Message = ex.Message;
            }
            return productPriceLevelResponse;
        }

        [HttpPut]
        public async Task<PriceCategoryResponse> UpdatePriceCategoryDetails([FromBody]PriceCategoryRequest priceCategoryRequest)
        {
            PriceCategoryResponse priceCategoryResponse = new PriceCategoryResponse();
            IEnumerable<PriceCategoryVM> priceCategoryVM;

            try
            {
                priceCategoryVM = new List<PriceCategoryVM>{
                    await _productServices.UpdatePriceCategoryDetails(priceCategoryRequest.priceCategoryVM)
                    };
                priceCategoryResponse.priceCategoryVM = priceCategoryVM;
                priceCategoryResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                priceCategoryResponse.IsSuccess = false;
                priceCategoryResponse.Message = ex.Message;
            }

            return priceCategoryResponse;
        }

        [HttpDelete("{id}")]
        public async Task<PriceCategoryResponse> DeletePriceCategoryDetails(int id)
        {
            PriceCategoryResponse priceCategoryResponse = new PriceCategoryResponse();
            IEnumerable<PriceCategoryVM> priceCategoryVM;

            try
            {
                priceCategoryVM = new List<PriceCategoryVM>
                {
                    await _productServices.DeletePriceCategoryDetails(id)
                };
                priceCategoryResponse.priceCategoryVM = priceCategoryVM;
                priceCategoryResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                priceCategoryResponse.IsSuccess = false;
                priceCategoryResponse.Message = ex.Message;
            }

            return priceCategoryResponse;
        }

        [HttpDelete("{productId}")]
        public async Task<ProductResponse> DeleteProduct(int productId)
        {
            ProductResponse productResponse = new ProductResponse();
            try
            {
                await _productServices.DeleteProductByProductId(productId);
                productResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productResponse.IsSuccess = false;
                productResponse.Message = ex.Message;
            }
            return productResponse;
        }

    }
}