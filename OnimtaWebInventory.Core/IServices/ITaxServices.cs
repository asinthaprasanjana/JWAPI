using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface ITaxServices
    {
        Task<TaxVM> GetTaxDetailsByTaxNumber(int taxNo, int companyId);
        Task <IEnumerable<TaxVM>> GetTaxDetails();
        Task<TaxVM> AddTaxDetails(TaxVM taxVM);
        Task<TaxVM> UpdateTaxDetails(TaxVM taxVM);
    }
}
