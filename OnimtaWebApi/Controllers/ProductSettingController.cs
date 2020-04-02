using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.GemProductSetting;
using OnimtaWebInventory.DTO.ProductLevel;
using OnimtaWebInventory.DTO.ProductLevelSummeryRequest;
using OnimtaWebInventory.DTO.ProductLevelSummeryResponse;
using OnimtaWebInventory.Models;


namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ProductSettingController : Controller
    {
        private ILogger<ProductSettingController> _logger;
        private IProductSettingServices _productSettingServices;

        public ProductSettingController(IProductSettingServices ProductSettingServices, ILogger<ProductSettingController> logger)
        {
            _productSettingServices = ProductSettingServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<CommonAttributeResponse> AddCommonAttribute([FromBody]CommonAttributeRequest commonAttributeRequest)
        {
            CommonAttributeResponse commonAttributeResponse = new CommonAttributeResponse();
            IEnumerable<CommonAttributesVM> commonAttributes;

            try
            {
                commonAttributes = new List<CommonAttributesVM>
                {
                    await _productSettingServices.AddCommonAttribute(commonAttributeRequest.CommonAttributes)
                };
                commonAttributeResponse.CommonAttributes = commonAttributes;
                commonAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                commonAttributeResponse.IsSuccess = false;
                commonAttributeResponse.Message = ex.Message;

            }
            return commonAttributeResponse;
        }


        [HttpGet("{filter}")]
        public async Task<CommonAttributeResponse> getCommonAttributeDetails(int filter)
        {
            CommonAttributeResponse commonAttributeResponse = new CommonAttributeResponse();
            IEnumerable<CommonAttributesVM> commonAttributes;

            try
            {
                commonAttributes = await _productSettingServices.GetCommonAttributes(filter);
                commonAttributeResponse.CommonAttributes = commonAttributes;
                commonAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                commonAttributeResponse.IsSuccess = false;
                commonAttributeResponse.Message = ex.Message;
            }
            return commonAttributeResponse;
        }

        [HttpGet("{attributeId}")]
        public async Task<CommonAttributeResponse> getCommonAttributeData(int attributeId)
        {
            CommonAttributeResponse commonAttributeResponse = new CommonAttributeResponse();
            CommonAttributesVM commonAttributes = new CommonAttributesVM();

            try
            {

                commonAttributes.Data = await _productSettingServices.GetCommonAttributeData(attributeId);
                commonAttributeResponse.CommonAttribute = commonAttributes;
                commonAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                commonAttributeResponse.IsSuccess = false;
                commonAttributeResponse.Message = ex.Message;
            }
            return commonAttributeResponse;
        }

        [HttpPut]
        public async Task<CommonAttributeResponse> UpdateCommonAttrtibuteSetting([FromBody]CommonAttributeRequest commonAttributeRequest)
        {
            CommonAttributeResponse commonAttributeResponse = new CommonAttributeResponse();
            IEnumerable<CommonAttributesVM> commonAttributes;

            try
            {
                commonAttributes = new List<CommonAttributesVM>{
                    await _productSettingServices.UpdateCommonAttributes(commonAttributeRequest.CommonAttributes)
                    };
                commonAttributeResponse.CommonAttributes = commonAttributes;
                commonAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                commonAttributeResponse.IsSuccess = false;
                commonAttributeResponse.Message = ex.Message;

            }
            return commonAttributeResponse;
        }

        [HttpPost]
        public async Task<CommonAttributeResponse> AddCommonGroup([FromBody]CommonAttributeRequest commonAttributeRequest)
        {
            CommonAttributeResponse commonAttributeResponse = new CommonAttributeResponse();
            CommonGroupsVM commonGroup = new CommonGroupsVM();

            try
            {
                commonGroup = await _productSettingServices.AddCommonGroup(commonAttributeRequest.CommonGroup);
                commonAttributeResponse.commonGroup = commonGroup;
                commonAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                commonAttributeResponse.IsSuccess = false;
                commonAttributeResponse.Message = ex.Message;

            }
            return commonAttributeResponse;
        }


        [HttpPost]
        public async Task<ProductLevelResponse> AddProductLevel([FromBody]ProductLevelRequest productLevelRequest)
        {
            ProductLevelResponse productLevelResponse = new ProductLevelResponse();
            //IEnumerable<GemProductSettingVM> gemProductSettingVM;

            try
            {
                productLevelResponse.ProductLevelVM = await _productSettingServices.AddProductLevel(productLevelRequest.ProductLevelVM);
                productLevelResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productLevelResponse.IsSuccess = false;
                productLevelResponse.Message = ex.Message;

            }
            return productLevelResponse;

        }

       [HttpPost]
        public async Task<ProductLevelResponse> GetProductLevelDetails([FromBody]ProductLevelRequest productLevelRequest)
        {
            ProductLevelResponse productLevelResponse = new ProductLevelResponse();

            ProductLevelVM productLevelVM = new ProductLevelVM();
            productLevelVM = productLevelRequest.ProductLevelVM.ElementAt(0);
          
            try
            {
                productLevelResponse.ProductLevelVM = await _productSettingServices.GetProductLevelDetails(productLevelVM);
                productLevelResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productLevelResponse.IsSuccess = false;
                productLevelResponse.Message = ex.Message;

            }
            return productLevelResponse;

        }

     

        [HttpGet("{companyId}")]
        public async Task<ProductLevelSummeryResponse> GetProductLevelSummeryDetails(int companyId)
        {
            ProductLevelSummeryResponse productLevelSummeryResponse  = new ProductLevelSummeryResponse();



            try
            {
                productLevelSummeryResponse.productLevelSummeryVMs = new List<ProductLevelSummeryVM> {
                    await _productSettingServices.GetProductLevelSummeryDetailsDetails(1)
                };

                productLevelSummeryResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productLevelSummeryResponse.IsSuccess = false;
                productLevelSummeryResponse.Message = ex.Message;

            }
            return productLevelSummeryResponse;

        }

        [HttpGet]
        public async Task<CommonAttributeResponse> GetCommonGroups()
        {
            CommonAttributeResponse commonAttributeResponse = new CommonAttributeResponse();
            IEnumerable<CommonGroupsVM> commonGroups;
            try
            {

                commonGroups = await _productSettingServices.GetCommonGroups();
                commonAttributeResponse.commonGroups = commonGroups;
                commonAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                commonAttributeResponse.IsSuccess = false;
                commonAttributeResponse.Message = ex.Message;
            }
            return commonAttributeResponse;
        }

        [HttpPut]
        public async Task<CommonAttributeResponse> UpdateCommonGroup([FromBody] CommonAttributeRequest commonAttributeRequest)
        {
            CommonAttributeResponse commonAttributeResponse = new CommonAttributeResponse();
            CommonGroupsVM commonGroup = new CommonGroupsVM();
            try
            {
                commonGroup = await _productSettingServices.UpdateCommonGroup(commonAttributeRequest.CommonGroup);
                commonAttributeResponse.commonGroup = commonGroup;
                commonAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                commonAttributeResponse.IsSuccess = false;
                commonAttributeResponse.Message = ex.Message;
            }
            return commonAttributeResponse;
        }

        [HttpPost]
        public async Task<CommonAttributeResponse> GetCommonGroupDetailsbyId([FromBody] CommonAttributeRequest commonAttributeRequest)
        {
            CommonAttributeResponse commonAttributeResponse = new CommonAttributeResponse();
            commonAttributeResponse.commonGroup = commonAttributeRequest.CommonGroup;
            IEnumerable<CommonAttributesVM> commonAttributes;
            try
            {
                commonAttributes = await _productSettingServices.GetCommonAttributeById(commonAttributeRequest.CommonGroup);
                commonAttributeResponse.commonGroup.AttributesArr = commonAttributes;
                commonAttributeResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                commonAttributeResponse.IsSuccess = false;
                commonAttributeResponse.Message = ex.Message;
            }
            return commonAttributeResponse;
        }


        [HttpGet]
        public async Task<ProductLevelResponse> GetAllIndustries()
        {
            ProductLevelResponse productLevelResponse = new ProductLevelResponse();
            IEnumerable<IndustryVM> industries;
            try
            {

                industries = await _productSettingServices.GetAllIndustries();
                productLevelResponse.Industries = industries;
                productLevelResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productLevelResponse.IsSuccess = false;
                productLevelResponse.Message = ex.Message;
            }
            return productLevelResponse;
        }


        [HttpGet("{parentId},{level}")]
        public async Task<ProductLevelResponse> GetIndustryProductLevel(int parentId,int level)
        {
            ProductLevelResponse productLevelResponse = new ProductLevelResponse();
            IEnumerable<IndustryLevelVM> industryLevels;


            try
            {
                industryLevels = await _productSettingServices.GetIndustryProductLevel(parentId, level);

                productLevelResponse.IndustryLevels = industryLevels;

                productLevelResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productLevelResponse.IsSuccess = false;
                productLevelResponse.Message = ex.Message;

            }
            return productLevelResponse;

        }

        [HttpPost]
        public async Task<ProductLevelResponse> AddIndustryProductLevel([FromBody]ProductLevelRequest productLevelRequest)
        {
            ProductLevelResponse productLevelResponse = new ProductLevelResponse();

            try
            {
                productLevelResponse.IndustryLevel = await _productSettingServices.AddIndustryProductLevel(productLevelRequest.IndustryLevel);
                productLevelResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productLevelResponse.IsSuccess = false;
                productLevelResponse.Message = ex.Message;

            }
            return productLevelResponse;
        }

        [HttpPut]
        public async Task<ProductLevelResponse> UpdateIndustryProductLevel([FromBody]ProductLevelRequest productLevelRequest)
        {
            ProductLevelResponse productLevelResponse = new ProductLevelResponse();

            try
            {
                productLevelResponse.IndustryLevel = await _productSettingServices.UpdateIndustryProductLevel(productLevelRequest.IndustryLevel);
                productLevelResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                productLevelResponse.IsSuccess = false;
                productLevelResponse.Message = ex.Message;

            }
            return productLevelResponse;
        }

    }

}