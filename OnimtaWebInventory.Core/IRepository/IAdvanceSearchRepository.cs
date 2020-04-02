using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository
{
    public interface IAdvanceSearchRepository
    {
        Task<IEnumerable<BusinessPartnerVM>> GetBusinessPartnerDetails(BusinessPartnerVM businessPartnerVM);
        Task<IEnumerable<AdvanceSearchVM>> GetAdvanceSearchDetails(int advanceSearchType);

    }
}
