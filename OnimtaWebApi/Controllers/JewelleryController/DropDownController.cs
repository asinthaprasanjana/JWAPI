using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.DTO.Jewellery.DropDown;
using OnimtaWebInventory.Models.Jewellery;

namespace OnimtaWebApi.Controllers.JewelleryController
{
    [Route("api/[controller]/[action]")]
    public class DropDownController : Controller
    {
        private IDropDownServices _DropDownServices;
        private ILogger<DropDownController> _logger;

        public DropDownController(IDropDownServices DropDownServices, ILogger<DropDownController> logger)
        {
            _DropDownServices = DropDownServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<DropDownResponse> AddNewTrayDetails([FromBody]DropDownRequest dropDownRequest)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.AddNewTrayDetails(dropDownRequest.DropDown)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpPost]
        public async Task<DropDownResponse> AddSectionDetails([FromBody]DropDownRequest DropDownRequest)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.AddSectionDetails(DropDownRequest.DropDown)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpGet]
        public async Task<DropDownResponse> GetAllSectionDetails()
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM =  await _DropDownServices.GetAllSectionDetails();
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpGet]
        public async Task<DropDownResponse> GetAllTrayDetails()
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = await _DropDownServices.GetAllTrayDetails();
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpGet("{sectionId}")]
        public async Task<DropDownResponse> GetTrayDetailsBySectionId(int sectionId)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = await _DropDownServices.GetTrayDetailsBySectionId(sectionId);
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpPut]
        public async Task<DropDownResponse> UpdateSectionDetails ([FromBody]DropDownRequest dropDownRequest)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.UpdateSectionDetails(dropDownRequest.DropDown)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpPut]
        public async Task<DropDownResponse> UpdateTrayDetails([FromBody]DropDownRequest dropDownRequest)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.UpdateTrayDetails(dropDownRequest.DropDown)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }


        [HttpDelete("{id}")]
        public async Task<DropDownResponse> DeleteSectionDetailsById(int id)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.DeleteSectionDetailsById(id)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpDelete("{id}")]
        public async Task<DropDownResponse> DeleteTrayDetailsById(int id)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.DeleteTrayDetailsById(id)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }


        [HttpPost]
        public async Task<DropDownResponse> AddTrayCategoryDetails([FromBody]DropDownRequest dropDownRequest)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.AddTrayCategoryDetails(dropDownRequest.DropDown)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }
        

        [HttpPut]
        public async Task<DropDownResponse> UpdateTrayCategoryDetails([FromBody]DropDownRequest dropDownRequest)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.UpdateTrayCategoryDetails(dropDownRequest.DropDown)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpDelete("{id}")]
        public async Task<DropDownResponse> DeleteTrayCategoryDetails(int id)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.DeleteTrayCategoryDetails(id)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpGet("{id}")]
        public async Task<DropDownResponse> GetTrayCategoryDetailsById(int id)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.GetTrayCategoryDetailsById(id)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpGet]
        public async Task<DropDownResponse> GetAllTrayCategoryDetails()
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = await _DropDownServices.GetAllTrayCategoryDetails();
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }


        [HttpGet("{slotCode}")]
        public async Task<DropDownResponse> GetTraySlotDetailsBySlotCode(string slotCode)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<TraySlotVM> traySlotVM;

            try
            {
                traySlotVM = new List<TraySlotVM>
                {
                    await _DropDownServices.GetTraySlotDetailsBySlotCode(slotCode)
                };
                dropDownResponse.TraySlots = traySlotVM;
                dropDownResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpGet("{trayId}")]
        public async Task<DropDownResponse> GetAvailableSlot(int trayId)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<TraySlotVM> traySlotVM;

            try
            {
                traySlotVM = await _DropDownServices.GetAvailableSlot(trayId);
                dropDownResponse.TraySlots = traySlotVM;
                dropDownResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse;
        }

        [HttpPost]
        public async Task<DropDownResponse> AddJewelleryUnitDetials([FromBody]DropDownRequest dropDownRequest)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            DropDownVM dropDownVM = new DropDownVM();

            try
            {
                dropDownVM = await _DropDownServices.AddJewelleryUnitDetials(dropDownRequest.DropDown);
             
                dropDownResponse.DropDown = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }
            return dropDownResponse;
        }

        [HttpPut]
        public async Task<DropDownResponse> UpdateJewelleryUnitDetials([FromBody]DropDownRequest dropDownRequest)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            DropDownVM dropDownVM = new DropDownVM();

            try
            {
                dropDownVM = await _DropDownServices.UpdateJewelleryUnitDetials(dropDownRequest.DropDown);
                dropDownResponse.DropDown = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }
            return dropDownResponse;
        }

        [HttpDelete("{id},{Type}")]
        public async Task<DropDownResponse> DeleteJewelleryUnitDetials(int id, string Type)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.DeleteJewelleryUnitDetials(id,Type)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }
            return dropDownResponse;
        }

        [HttpGet("{id},{Type}")]
        public async Task<DropDownResponse> GetJewelleryUnitDetialsById(int id, string Type)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = new List<DropDownVM>
                {
                    await _DropDownServices.GetJewelleryUnitDetialsById(id,Type)
                };
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }
            return dropDownResponse;
        }

        [HttpGet("{Type}")]
        public async Task<DropDownResponse> GetAllJewelleryUnitDetials(string Type)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = await _DropDownServices.GetAllJewelleryUnitDetials(Type);
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }
            return dropDownResponse;
        }

        [HttpGet("{id}")]
        public async Task<DropDownResponse> GetTraySlotDetailsBySlotId(int id)
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<TraySlotVM> traySlotVM;

            try
            {
                traySlotVM = new List<TraySlotVM>
                {
                    await _DropDownServices.GetTraySlotDetailsBySlotId(id)
                };
                dropDownResponse.TraySlots = traySlotVM;
                dropDownResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }
            return dropDownResponse;
        }

        [HttpGet]
        public async Task<DropDownResponse> GetBanks()
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = await _DropDownServices.GetBanks();
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }
            return dropDownResponse;
        }


        [HttpGet]
        public async Task<DropDownResponse> GetAllCreditCards()
        {
            DropDownResponse dropDownResponse = new DropDownResponse();
            IEnumerable<DropDownVM> dropDownVM;

            try
            {
                dropDownVM = await _DropDownServices.GetAllCreditCards();
                dropDownResponse.DropDowns = dropDownVM;
                dropDownResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                dropDownResponse.IsSuccess = false;
                dropDownResponse.Message = ex.Message;
            }

            return dropDownResponse; ;
        }
    }
}
