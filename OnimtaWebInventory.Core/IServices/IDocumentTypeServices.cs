using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IDocumentTypeServices
    {
        Task<DocumentTypeVm> AddDocumentNumberDetails(DocumentTypeVm documentTypeVm);
        Task<IEnumerable<DocumentTypeVm>> GetAllDocumentTypeDetails();
        Task<IEnumerable<DocumentTypeVm>> GetDocumentTypeHistoryDetails(int DocumentTypeId, int UserId);

    }
}
