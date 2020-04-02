using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
  public  interface ICurrencyServices
    {
        Task<CurrencyVM> AddNewCurrencyDetails(CurrencyVM currencyVM);
        Task<IEnumerable<CurrencyVM>> GetCurrencyDetails(int companyId);
    }
}
