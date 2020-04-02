using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository
{
    public class DocumentTypeRepository :DBContext, IDocumentTypeRepository
    {
        public async Task<DocumentTypeVm> AddDocumentNumberDetails(DocumentTypeVm documentTypeVm)
        {
            DocumentTypeVm documentTypeVM = new DocumentTypeVm();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@DocumentTypeId", documentTypeVm.DocumentTypeId);
                dynamicParameterlist.Add("@DocumentTypeName", documentTypeVm.DocumentTypeName);
                dynamicParameterlist.Add("@Number", documentTypeVm.Number);
                dynamicParameterlist.Add("@Text", documentTypeVm.Text);
                dynamicParameterlist.Add("@UserId", documentTypeVm.UserId);
                documentTypeVm = await dbConnection.QuerySingleOrDefaultAsync<DocumentTypeVm>("msd.AddDocumentNumberDetails", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return documentTypeVm;
        }

        public async Task<IEnumerable<DocumentTypeVm>> GetAllDocumentTypeDetails()
        {
            IEnumerable<DocumentTypeVm> documentTypeVm ;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                documentTypeVm = await dbConnection.QueryAsync<DocumentTypeVm>("msd.GetAllDocumentTypeDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return documentTypeVm;
        }

        public async Task<IEnumerable<DocumentTypeVm>> GetDocumentTypeHistoryDetails(int DocumentTypeId, int UserId)
        {
            IEnumerable<DocumentTypeVm> documentTypeVm ;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@DocumentTypeId", DocumentTypeId);
                dynamicParameterlist.Add("@UserId", UserId);
                documentTypeVm = await dbConnection.QueryAsync<DocumentTypeVm>("msd.GetDocumentTypeHistoryDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return documentTypeVm;
        }
    }
}
