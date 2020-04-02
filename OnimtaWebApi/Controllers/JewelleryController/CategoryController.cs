using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.DTO.Jewellery.Category;
using OnimtaWebInventory.Models.Jewellery;

namespace OnimtaWebApi.Controllers.JewelleryController
{
   [Route("api/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private ICategoryServices _CategoryServices;
        public ILogger<CategoryController> _logger;
         
        public CategoryController(ICategoryServices CategoryServices, ILogger<CategoryController> logger)
        {
            _CategoryServices = CategoryServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<CategoryResponse> GetAllJewelleryCategoriesDesign()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = await _CategoryServices.GetAllJewelleryCategoriesDesign();
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpGet]
        public async Task<CategoryResponse> GetAllJewelleryCategoriesItem()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = await _CategoryServices.GetAllJewelleryCategoriesItem();
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }
            return categoryResponse;
        }

        [HttpGet]
        public async Task<CategoryResponse> GetAllJewelleryCategoriesGem()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = await _CategoryServices.GetAllJewelleryCategoriesGem();
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }
            return categoryResponse;
        }

        [HttpGet]
        public async Task<CategoryResponse> GetAllJewelleryCategoriesMaterial()
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = await _CategoryServices.GetAllJewelleryCategoriesMaterial();
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }
            return categoryResponse;
        }


        [HttpPost]
        public async Task<CategoryResponse> AddDesignCategoryDetails([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            CategoryVM categoryVM = new CategoryVM();

            try
            {
                categoryVM = await _CategoryServices.AddDesignCategoryDetails(categoryRequest.category);
                
                categoryResponse.category = categoryVM;
                categoryResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPost]
        public async Task<CategoryResponse> AddGemCategoryDetails([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            CategoryVM categoryVM = new CategoryVM();

            try
            {
                categoryVM = await _CategoryServices.AddGemCategoryDetails(categoryRequest.category);
                categoryResponse.category = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPost]
        public async Task<CategoryResponse> AddItemCategoryDetails([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            CategoryVM categoryVM = new CategoryVM();

            try
            {
                categoryVM = await _CategoryServices.AddItemCategoryDetails(categoryRequest.category);
                categoryResponse.category = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPost]
        public async Task<CategoryResponse> AddMaterialCategoryDetails([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            CategoryVM categoryVM = new CategoryVM();

            try
            {
                categoryVM = await _CategoryServices.AddMaterialCategoryDetails(categoryRequest.category);
                categoryResponse.category = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }




        [HttpPut]
        public async Task<CategoryResponse> UpdateDesignCategoryDetails([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = new List<CategoryVM> {
                    await _CategoryServices.UpdateDesignCategoryDetails(categoryRequest.category)
                };
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPut]
        public async Task<CategoryResponse> UpdateGemCategoryDetails([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = new List<CategoryVM> {
                    await _CategoryServices.UpdateGemCategoryDetails(categoryRequest.category)
                };
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPut]
        public async Task<CategoryResponse> UpdateItemCategoryDetails([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = new List<CategoryVM> {
                    await _CategoryServices.UpdateItemCategoryDetails(categoryRequest.category)
                };
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPut]
        public async Task<CategoryResponse> UpdateMaterialCategoryDetails([FromBody] CategoryRequest categoryRequest)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = new List<CategoryVM> {
                    await _CategoryServices.UpdateMaterialCategoryDetails(categoryRequest.category)
                };
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPut("{id}")]
        public async Task<CategoryResponse> DeleteDesignCategoryDetails(int id)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = new List<CategoryVM> {
                    await _CategoryServices.DeleteDesignCategoryDetails(id)
                };
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPut("{id}")]
        public async Task<CategoryResponse> DeleteGemCategoryDetails(int id)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = new List<CategoryVM> {
                    await _CategoryServices.DeleteGemCategoryDetails(id)
                };
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPut("{id}")]
        public async Task<CategoryResponse> DeleteItemCategoryDetails(int id)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = new List<CategoryVM> {
                    await _CategoryServices.DeleteItemCategoryDetails(id)
                };
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }

        [HttpPut("{id}")]
        public async Task<CategoryResponse> DeleteMaterialCategoryDetails(int id)
        {
            CategoryResponse categoryResponse = new CategoryResponse();
            IEnumerable<CategoryVM> categoryVM;

            try
            {
                categoryVM = new List<CategoryVM> {
                    await _CategoryServices.DeleteMaterialCategoryDetails(id)
                };
                categoryResponse.categories = categoryVM;
                categoryResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                categoryResponse.IsSuccess = false;
                categoryResponse.Message = ex.Message;
            }

            return categoryResponse;
        }
    }
}