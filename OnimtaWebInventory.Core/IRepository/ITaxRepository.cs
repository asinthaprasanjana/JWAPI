using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface ITaxRepository
    {
        Task<TaxVM> GetTaxDetailsByTaxNumber(int taxNo, int companyId);
        Task<TaxVM> AddTaxDetails(TaxVM taxVM);
        Task<IEnumerable<TaxVM>> GetTaxDetails();
        Task<TaxVM> UpdateTaxDetails(TaxVM taxVM);
    }
}
