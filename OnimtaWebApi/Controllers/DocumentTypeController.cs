using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.DTO.DocumentType;
using OnimtaWebInventory.Models;

namespace OnimtaWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DocumentTypeController : Controller
    {
        private IDocumentTypeServices _documentTypeServices;
        private ILogger<DocumentTypeController> _logger;

        public DocumentTypeController(IDocumentTypeServices DocumentTypeServices, ILogger<DocumentTypeController>logger)
        {
            _documentTypeServices = DocumentTypeServices;
            _logger = logger;
        }

        [HttpPost]
        public async Task<DocumentTypeResponse> AddDocumentNumberDetails([FromBody]DocumentTypeRequest documentTypeRequest)
        {
            DocumentTypeResponse documentTypeResponse = new DocumentTypeResponse();
            IEnumerable<DocumentTypeVm> documentTypeVm;

            try
            {
                documentTypeVm = new List<DocumentTypeVm>
                {
                    await _documentTypeServices.AddDocumentNumberDetails(documentTypeRequest.documentTypeVm)
                };
                documentTypeResponse.documentTypeVm = documentTypeVm;
                documentTypeResponse.IsSuccess = true;
                   
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                documentTypeResponse.IsSuccess = false;
                documentTypeResponse.Message = ex.Message;
            }
            return documentTypeResponse;
        }

        [HttpGet]
        public async Task<DocumentTypeResponse> GetAllDocumentTypeDetails()
        {
            DocumentTypeResponse documentTypeResponse = new DocumentTypeResponse();
            IEnumerable<DocumentTypeVm> documentTypeVm;

            try
            {
                documentTypeVm = await _documentTypeServices.GetAllDocumentTypeDetails();
                documentTypeResponse.documentTypeVm = documentTypeVm;
                documentTypeResponse.IsSuccess = true;
            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                documentTypeResponse.IsSuccess = false;
                documentTypeResponse.Message = ex.Message;
            }

            return documentTypeResponse;
        }

        [HttpGet("{DocumentTypeId},{UserId}")]
        public async Task<DocumentTypeResponse> GetDocumentTypeHistoryDetails(int DocumentTypeId, int UserId)
        {
            DocumentTypeResponse documentTypeResponse = new DocumentTypeResponse();
            IEnumerable<DocumentTypeVm> documentTypeVm;

            try
            {
                documentTypeVm = await _documentTypeServices.GetDocumentTypeHistoryDetails(DocumentTypeId,UserId);
                documentTypeResponse.documentTypeVm = documentTypeVm;
                documentTypeResponse.IsSuccess = true;

            }catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                documentTypeResponse.IsSuccess = false;
                documentTypeResponse.Message = ex.Message;
            }
            return documentTypeResponse;
        }
    }
}