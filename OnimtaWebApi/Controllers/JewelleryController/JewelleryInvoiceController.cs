using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.DTO.Jewellery.JewelleryInvoice;
using OnimtaWebInventory.Models.Jewellery;

namespace OnimtaWebApi.Controllers.JewelleryController
{
    [Route("api/[controller]/[action]")]
    public class JewelleryInvoiceController : Controller
    {
        private IJewelleryInvoiceServices _JewelleryInvoiceServices;
        private ILogger<JewelleryInvoiceController> _logger;

        public JewelleryInvoiceController(IJewelleryInvoiceServices JewelleryInvoiceServices, ILogger<JewelleryInvoiceController> logger)
        {
            _JewelleryInvoiceServices = JewelleryInvoiceServices;
            _logger = logger;
        }


        [HttpPost]
        public async Task<JewelleryInvoiceResponse> AddJewelleryInvoice([FromBody]JewelleryInvoiceRequest invoiceRequest)
        {
            JewelleryInvoiceResponse JewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            InvoiceVM invoice = new InvoiceVM();

            try
            {
                invoice = await _JewelleryInvoiceServices.AddJewelleryInvoice(invoiceRequest.Invoice);
                JewelleryInvoiceResponse.Invoice = invoice;
                JewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                JewelleryInvoiceResponse.IsSuccess = false;
                JewelleryInvoiceResponse.Message = ex.Message;
            }

            return JewelleryInvoiceResponse;
        }

        [HttpPost]
        public async Task<JewelleryInvoiceResponse> GetAllInvoices([FromBody]FilterVM filter)
        {
            JewelleryInvoiceResponse JewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoices;

            try
            {
                invoices = await _JewelleryInvoiceServices.GetAllInvoices(filter);
                JewelleryInvoiceResponse.Invoices = invoices;
                JewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                JewelleryInvoiceResponse.IsSuccess = false;
                JewelleryInvoiceResponse.Message = ex.Message;
            }

            return JewelleryInvoiceResponse;
        }

        [HttpPost]
        public async Task<JewelleryInvoiceResponse> GetAllAdvanceDetails([FromBody]FilterVM filter)
        {
            JewelleryInvoiceResponse JewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoices;

            try
            {
                invoices = await _JewelleryInvoiceServices.GetAllAdvanceDetails(filter);
                JewelleryInvoiceResponse.Invoices = invoices;
                JewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                JewelleryInvoiceResponse.IsSuccess = false;
                JewelleryInvoiceResponse.Message = ex.Message;
            }

            return JewelleryInvoiceResponse;
        }

        [HttpGet("{Id}")]
        public async Task<JewelleryInvoiceResponse> GetAllInvoiceById(int Id)
        {
            JewelleryInvoiceResponse JewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            InvoiceVM invoice = new InvoiceVM();
            try
            {
                JewelleryInvoiceResponse.Invoice = await _JewelleryInvoiceServices.GetInvoiceById(Id);
                //JewelleryInvoiceResponse.Invoice = invoice;
                JewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                JewelleryInvoiceResponse.IsSuccess = false;
                JewelleryInvoiceResponse.Message = ex.Message;
            }

            return JewelleryInvoiceResponse;
        }

        [HttpGet("{id}")]
        public async Task<JewelleryInvoiceResponse> GetAdvanceDetailsById(int id)
        {
            JewelleryInvoiceResponse JewelleryInvoiceResponse = new JewelleryInvoiceResponse();

            try
            {
                JewelleryInvoiceResponse.Invoice = await _JewelleryInvoiceServices.GetAdvanceDetailsById(id);
                // JewelleryInvoiceResponse.Invoice = invoice;
                JewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                JewelleryInvoiceResponse.IsSuccess = false;
                JewelleryInvoiceResponse.Message = ex.Message;
            }

            return JewelleryInvoiceResponse;
        }


        [HttpPost]
        public async Task<JewelleryInvoiceResponse> AddJewelleryAdvance([FromBody]JewelleryInvoiceRequest invoiceRequest)
        {
            JewelleryInvoiceResponse JewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            InvoiceVM invoice = new InvoiceVM();

            try
            {
                invoice = await _JewelleryInvoiceServices.AddJewelleryAdvance(invoiceRequest.Invoice);
                JewelleryInvoiceResponse.Invoice = invoice;
        
                JewelleryInvoiceResponse.IsSuccess = true;

                //COMMENT ADDED


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                JewelleryInvoiceResponse.IsSuccess = false;
                JewelleryInvoiceResponse.Message = ex.Message;
            }

            return JewelleryInvoiceResponse;
        }


        [HttpGet("{Keyword}")]
        public async Task<JewelleryInvoiceResponse> SearchAdvanceDetails(string Keyword)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = await _JewelleryInvoiceServices.SearchAdvanceDetails(Keyword);
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpGet("{Keyword},{PageId}")]
        public async Task<JewelleryInvoiceResponse> SearchInvoiceDetails(string Keyword, int PageId)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = await _JewelleryInvoiceServices.SearchInvoiceDetails(Keyword, PageId);
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpPost]
        public async Task<JewelleryInvoiceResponse> AddJewelleryReward([FromBody]JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<RewardsVM> rewardsVM;

            try
            {
                rewardsVM = new List<RewardsVM>
                {
                    await _JewelleryInvoiceServices.AddJewelleryReward(jewelleryInvoiceRequest.rewards)
                };
                jewelleryInvoiceResponse.rewardsVM = rewardsVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }


        [HttpPut]
        public async Task<JewelleryInvoiceResponse> UpdateInvoice([FromBody]JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = new List<InvoiceVM>
                {
                    await _JewelleryInvoiceServices.UpdateInvoice(jewelleryInvoiceRequest.Invoice)
                };
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;
            } catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpGet("{state},{invoiceID}")]
        public async Task<JewelleryInvoiceResponse> updateInvoiceUploadState(Boolean state, int invoiceID)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            try
            {

                await _JewelleryInvoiceServices.UpdateInvoiceUploadInfo(state, invoiceID);
                jewelleryInvoiceResponse.IsSuccess = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpPost]
        public async Task<JewelleryInvoiceResponse> JewelleryDailySummary([FromBody]JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = await _JewelleryInvoiceServices.JewelleryDailySummary(jewelleryInvoiceRequest.Invoice);
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }
            return jewelleryInvoiceResponse;
        }

        [HttpGet]
        public async Task<JewelleryInvoiceResponse> GetJewelleryInvoiceUploaded()
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = await _JewelleryInvoiceServices.GetJewelleryInvoiceUploaded();
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }


        [HttpPost]
        public async Task<JewelleryInvoiceResponse> GetAdvanceDetailsByDateRange([FromBody]FilterVM filter )
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
               // invoiceVM = await _JewelleryInvoiceServices.GetAdvanceDetailsByDateRange(filter.from,filter.to);
               // jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }


        [HttpPost]
        public async Task<JewelleryInvoiceResponse> GetInvoiceDetailsByDateRange([FromBody]FilterVM filter)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
               // invoiceVM = await _JewelleryInvoiceServices.GetInvoiceDetailsByDateRange(filter.from,filter.to);
                //jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpPut]
        public async Task<JewelleryInvoiceResponse> InvoiceCancellation([FromBody]JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = new List<InvoiceVM>
                {
                    await _JewelleryInvoiceServices.InvoiceCancellation(jewelleryInvoiceRequest.Invoice)
                };
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpPost]
        public async Task<JewelleryInvoiceResponse> InvoiceReturn([FromBody]JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = new List<InvoiceVM>
                {
                    await _JewelleryInvoiceServices.InvoiceReturn(jewelleryInvoiceRequest.Invoice)
                };
                jewelleryInvoiceResponse.Invoice = invoiceVM.ElementAt(0);
                jewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }


        [HttpPost]
        public async Task<JewelleryInvoiceResponse> GetAllReturnedInvoices([FromBody]FilterVM filter)
        {
            JewelleryInvoiceResponse JewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoices;

            try
            {
                invoices = await _JewelleryInvoiceServices.GetAllInvoiceReturns(filter);
                JewelleryInvoiceResponse.Invoices = invoices;
                JewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                JewelleryInvoiceResponse.IsSuccess = false;
                JewelleryInvoiceResponse.Message = ex.Message;
            }

            return JewelleryInvoiceResponse;
        }

        [HttpGet("{Id}")]
        public async Task<JewelleryInvoiceResponse> GetInvoiceReturnsById(int Id)
        {
            JewelleryInvoiceResponse JewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            InvoiceVM invoice = new InvoiceVM();
            try
            {
                JewelleryInvoiceResponse.Invoice = await _JewelleryInvoiceServices.GetInvoiceReturnsById(Id);
                //JewelleryInvoiceResponse.Invoice = invoice;
                JewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                JewelleryInvoiceResponse.IsSuccess = false;
                JewelleryInvoiceResponse.Message = ex.Message;
            }

            return JewelleryInvoiceResponse;
        }
        [HttpGet("{keyWord}")]
        public async Task<JewelleryInvoiceResponse> SearchJewelleryInvoiceReturnDetails( string keyWord)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = await _JewelleryInvoiceServices.SearchJewelleryInvoiceReturnDetails(keyWord);
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpPost]
        public async Task<JewelleryInvoiceResponse> AddJewelleryPettyCash([FromBody]JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();

            try
            {

                jewelleryInvoiceResponse.PettyCash = await _JewelleryInvoiceServices.AddJewelleryPettyCash(jewelleryInvoiceRequest.PettyCash);
                jewelleryInvoiceResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }


        [HttpPut]
        public async Task<JewelleryInvoiceResponse> UpdateJewelleryPettyCash([FromBody]JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();

            try
            {
                jewelleryInvoiceResponse.PettyCash = await _JewelleryInvoiceServices.UpdateJewelleryPettyCash(jewelleryInvoiceRequest.PettyCash);
                jewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpDelete("{id}")]
        public async Task<JewelleryInvoiceResponse> DeleteJewelleryPettyCash(int id)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = new List<InvoiceVM>
                {
                    await _JewelleryInvoiceServices.DeleteJewelleryPettyCash(id)
                };
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpGet]
        public async Task<JewelleryInvoiceResponse> GetAllJewelleryPettyCashDetails()
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                invoiceVM = await _JewelleryInvoiceServices.GetAllJewelleryPettyCashDetails();
                jewelleryInvoiceResponse.Invoices = invoiceVM;
                jewelleryInvoiceResponse.IsSuccess = true;

            } catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpPost]
        public async Task<JewelleryInvoiceResponse> GetJewelleryPettyCashDetailsByDate([FromBody] JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            IEnumerable<PettyCashVM> invoiceVM;

            try
            {
                jewelleryInvoiceResponse.PettyCashs = await _JewelleryInvoiceServices.GetJewelleryPettyCashDetailsByDate(jewelleryInvoiceRequest.PettyCash);
                
                jewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpPost]
        public async Task<JewelleryInvoiceResponse> AddRefund([FromBody] JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();
            
            try
            {
                jewelleryInvoiceResponse.Refund = await _JewelleryInvoiceServices.AddRefund(jewelleryInvoiceRequest.Refund);
                jewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        } 

        [HttpPut]
        public async Task<JewelleryInvoiceResponse> CancelRefund([FromBody] JewelleryInvoiceRequest jewelleryInvoiceRequest)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();

            try
            {
                jewelleryInvoiceResponse.Refund = await _JewelleryInvoiceServices.CancelRefund(jewelleryInvoiceRequest.Refund);
                jewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }

        [HttpGet("{id}")]
        public async Task<JewelleryInvoiceResponse> AddRefund(int Id)
        {
            JewelleryInvoiceResponse jewelleryInvoiceResponse = new JewelleryInvoiceResponse();

            try
            {
                jewelleryInvoiceResponse.Refunds = await _JewelleryInvoiceServices.GetRefundsByReturnId(Id);
                jewelleryInvoiceResponse.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                jewelleryInvoiceResponse.IsSuccess = false;
                jewelleryInvoiceResponse.Message = ex.Message;
            }

            return jewelleryInvoiceResponse;
        }
    }
}