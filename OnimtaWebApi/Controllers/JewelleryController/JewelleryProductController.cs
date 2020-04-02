using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ExcelDataReader;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.DTO.Jewellery.JewelleryProduct;
using OnimtaWebInventory.DTO.Jewellery.JewelleryInvoice;
using OnimtaWebInventory.Models.Jewellery;
using System.Net.Http.Headers;

namespace OnimtaWebApi.Controllers.JewelleryController
{

    [Route("api/[controller]/[action]")]
    public class JewelleryProductController : Controller
    {
        private IJewelleryProductServices _jewelleryProductServices;
        private IDropDownServices _DropDownServices;
        private ILogger<JewelleryProductController> _logger;

        public JewelleryProductController(IJewelleryProductServices JewelleryProductServices , ILogger<JewelleryProductController> logger)
        {
            _jewelleryProductServices = JewelleryProductServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<JewelleryProductResponse> AddJewelleryProduct([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.AddJewelleryProduct(jewelleryProductRequest.JewelleryProduct);
                jewelleryProductResponse.JewelleryProduct = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpPut]
        public async Task<JewelleryProductResponse> UpdateJewelleryProductDetails([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.UpdateJewelleryProductDetails(jewelleryProductRequest.JewelleryProduct);
                jewelleryProductResponse.JewelleryProduct = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }


        [HttpPost]
        public async Task<JewelleryProductResponse> GetAllJewelleryProductDetails([FromBody]FilterVM filter)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.GetAllJewelleryProductDetails(filter);
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpGet("{id}")]
        public async Task<JewelleryProductResponse> GetJewelleryProductDetailsById(int id)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = new List<JewelleryProductVM>
                {
                    await _jewelleryProductServices.GetJewelleryProductDetailsById(id)
                };
               // jewelleryProductVM = await _jewelleryProductServices.GetAllJewelleryProductDetails();
                jewelleryProductResponse.JewelleryProduct = jewelleryProductVM.ElementAt(0);
                jewelleryProductResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }
            return jewelleryProductResponse;
        }

        [HttpPut("{id}")]
        public async Task<JewelleryProductResponse> DeleteJewelleryProduct(int id)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = new List<JewelleryProductVM>
                {
                    await _jewelleryProductServices.DeleteJewelleryProduct(id)
                };
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;

            } 
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }
            return jewelleryProductResponse;
        }

        [HttpPost("{autoGenItemCode}")]
        public async Task<JewelleryProductResponse> importProducts(Boolean autoGenItemCode, [FromForm] IFormFile file)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;
            
            try
            {
                jewelleryProductVM = await _jewelleryProductServices.ImportProductExcel(autoGenItemCode,file);
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }
            return jewelleryProductResponse;
        }

        [HttpPost]
        public async Task<JewelleryProductResponse> importProductsBarCode([FromForm] IFormFile file)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.ImportProductExcelBarCode(file);
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }
            return jewelleryProductResponse;
        }

        [HttpPut("{trayId},{sectionId},{productId},{traySlot}")]
        public async Task<JewelleryProductResponse> UpdateTraySlotDetails(int trayId, int sectionId, int productId, int traySlot)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<TraySlotVM> traySlotVM;

            try
            {
                traySlotVM = new List<TraySlotVM>{
                    await _jewelleryProductServices.UpdateTraySlotDetails(trayId,sectionId,productId,traySlot)
                     };
                jewelleryProductResponse.TraySlotVM = traySlotVM;
                jewelleryProductResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }
        [HttpGet("{itemCode},{pageId}")]
        public async Task<JewelleryProductResponse> SearchJewelleryProductDetailsByItemCode(string itemCode, int pageId)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.SearchJewelleryProductDetailsByItemCode(itemCode, pageId);
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpGet("{itemCode},{pageId}")]
        public async Task<JewelleryProductResponse> SearchJewelleryProductDetailsByItemCodeAll(string itemCode, int pageId)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.SearchJewelleryProductDetailsByItemCode_All(itemCode, pageId);
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpGet("{id}")]
        public async Task<JewelleryProductResponse> GetJewelleryProductLogByProductId(int id)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.GetJewelleryProductLogByProductId(id);
              
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }


        [HttpGet("{itemCode},{description},{pageId}")]
        public async Task<JewelleryProductResponse> SearchJewelleryProductDetails(string itemCode, string description, int pageId)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.SearchJewelleryProductDetails(itemCode, description, pageId);
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;

            }
            return jewelleryProductResponse;
        }

      [HttpPost]
      public async Task<JewelleryProductResponse> AddGoldRateDetail([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<GoldRateVM> goldRateVM;

            try
            {
                goldRateVM = new List<GoldRateVM>
               {
                   await _jewelleryProductServices.AddGoldRateDetail(jewelleryProductRequest.goldRate)
               };
                jewelleryProductResponse.goldRates = goldRateVM;
                jewelleryProductResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpPut]
        public async Task<JewelleryProductResponse> UpdateGoldRateDetail([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<GoldRateVM> goldRateVM;

            try
            {
                goldRateVM = new List<GoldRateVM>
               {
                   await _jewelleryProductServices.UpdateGoldRateDetail(jewelleryProductRequest.goldRate)
               };
                jewelleryProductResponse.goldRates = goldRateVM;
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpGet()]
        public async Task<JewelleryProductResponse> GetGoldRateDetailsByDate()
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<GoldRateVM> goldRateVM;

            try
            {
                goldRateVM = new List<GoldRateVM>
               {
                   await _jewelleryProductServices.GetGoldRateDetailsByDate()
               };
                jewelleryProductResponse.goldRates = goldRateVM;
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpGet]
        public async Task<JewelleryProductResponse> GetAllGoldRateDetails()
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<GoldRateVM> goldRateVM;

            try
            {
                goldRateVM = await _jewelleryProductServices.GetAllGoldRateDetails();
                jewelleryProductResponse.goldRates = goldRateVM;
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpGet]
        public async Task<JewelleryProductResponse> GetReceiptNumber()
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<GoldRateVM> goldRateVM;

            try
            {
                goldRateVM = new List<GoldRateVM>
               {
                   await _jewelleryProductServices.GetReceiptNumber()
               };
                jewelleryProductResponse.goldRates = goldRateVM;
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpPost("{Id},{Add}"), DisableRequestSizeLimit]
        public async Task<IActionResult> UploadJewImage(int Id,Boolean Add)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            JewelleryProductVM jewelleryProductVM=new JewelleryProductVM();
            try
            {
                var file = Request.Form.Files[0];
                //var folderName = Path.Combine("Resources", "Images");
                // var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(@"E:\Hansaka\webInventory\WebInventoryFrontEnd\src\assets\Images\products", fileName);
                    var backUpPath = Path.Combine(@"E:\Hansaka\webInventory\productImageBackUp", fileName);
                   
                    //var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    using (var stream = new FileStream(backUpPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    jewelleryProductVM = await _jewelleryProductServices.UpdateJewelleryImage(Id,Add);

                    return Ok(new { fullPath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut]
        public async Task<JewelleryProductResponse> JewelleryProductTransfer()
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            IEnumerable<JewelleryProductVM> jewelleryProductVM;

            try
            {
                jewelleryProductVM = await _jewelleryProductServices.JewelleryProductTransfer();
                jewelleryProductResponse.JewelleryProducts = jewelleryProductVM;
                jewelleryProductResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }
            return jewelleryProductResponse;
        }

        [HttpPost]
        public async Task<JewelleryProductResponse> AddJewelleryTransfer([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();

            try
            {
                jewelleryProductResponse.JewelleryTransfer =  await _jewelleryProductServices.AddJewelleryTransfer(jewelleryProductRequest.JewelleryTransfer);
            
                
                jewelleryProductResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpGet("{TransferId}")]
        public async Task<JewelleryProductResponse> GetJewelleryTransferProductsByTransferId(int TransferId)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();
            try
            {
                jewelleryProductResponse.JewelleryTransfer = await _jewelleryProductServices.GetJewelleryTransferByTransferId(TransferId);
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }



        [HttpPost]
        public async Task<JewelleryProductResponse> GetAllJewelleryTransfers([FromBody]FilterVM filter)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();

            try
            {
                jewelleryProductResponse.JewelleryTransfers = await _jewelleryProductServices.GetAllJewelleryTransfers(filter);
                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }

        [HttpPut]
        public async Task<JewelleryProductResponse> CancelJewelleryTransfer([FromBody]JewelleryProductRequest jewelleryProductRequest)
        {
            JewelleryProductResponse jewelleryProductResponse = new JewelleryProductResponse();

            try
            {
                jewelleryProductResponse.JewelleryTransfer = await _jewelleryProductServices.CancellTransfer(jewelleryProductRequest.JewelleryTransfer);


                jewelleryProductResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryProductResponse.IsSuccess = false;
                jewelleryProductResponse.Message = ex.Message;
            }

            return jewelleryProductResponse;
        }


    }
}