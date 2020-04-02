using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class DocumentTypeServices : IDocumentTypeServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public DocumentTypeServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DocumentTypeVm> AddDocumentNumberDetails(DocumentTypeVm documentTypeVm)
        {
            DocumentTypeVm documentTypeVM = new DocumentTypeVm();

            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    documentTypeVm = await  _unitOfWork.DocumentTypeRepository.AddDocumentNumberDetails(documentTypeVm);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }


            return documentTypeVm;

        }

        public async Task<IEnumerable<DocumentTypeVm>> GetAllDocumentTypeDetails()
        {
            IEnumerable<DocumentTypeVm> documentTypeVm;

            
            using (_unitOfWork)
            {


                try
                {
                documentTypeVm = await  _unitOfWork.DocumentTypeRepository.GetAllDocumentTypeDetails();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return documentTypeVm;
        }

        public async Task<IEnumerable<DocumentTypeVm>> GetDocumentTypeHistoryDetails(int DocumentTypeId, int UserId)
        {
            IEnumerable<DocumentTypeVm> documentTypeVm;

           
            using (_unitOfWork)
            {


                try
                {
                documentTypeVm = await  _unitOfWork.DocumentTypeRepository.GetDocumentTypeHistoryDetails(DocumentTypeId, UserId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return documentTypeVm;
        }
    }
}
