using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface IBusinessPartnerServices
    {
        Task<IEnumerable<BusinessPartnerVM>> GetBusinessPartnerDetails(int businessPartnerTypeId, int companyId, int pageId,int isActive);
        Task<BusinessPartnerVM> GetBusinessPartnerDetailsByBspId(int businessPartnerId);
        Task<BusinessPartnerVM> AddBusinessPartner(BusinessPartnerVM businessPartnerVm);
        Task<BusinessPartnerVM> UpdateBusinessPartner(BusinessPartnerVM businessPartnerVM);
        Task<IEnumerable<BankVM>> GetBusinessPartnerBanks();
        Task<BusinessPartnerVM> DeleteBusinessPartner(int businessPartnerId);
        Task<IEnumerable<BusinessPartnerVM>> GetBusinessPartnerDetailsByBSPName(string name, int businessPartnerTypeId);

        Task<BusinessPartnerGroupVM> AddBusinessPartnerGroupDetails(BusinessPartnerGroupVM businessPartnerGroupVM);
        Task<IEnumerable<BusinessPartnerGroupVM>> GetAllBusinessPartnerGroupDetails();
        Task<BusinessPartnerGroupVM> UpdateBusinessPartnerGroupDetails(BusinessPartnerGroupVM businessPartnerGroupVM);
        Task<IEnumerable<BusinessPartnerGroupVM>> GetBusinessPartnerGroupDetailsByGroupId(int groupCode);
        Task<BusinessPartnerVM> UpdateBusinessPartnerCustomerStatus(int isActive, int businessPartnerId);
        Task<BusinessPartnerVM> GetBusinessPartnerDetailsByMobileNumber(int mobileNo, int businessPartnerTypeId);

        Task<IEnumerable<BusinessPartnerGroupVM>> GetBusinessPartnerGroupDetailsByBspTypeId(int bspTypeId);

        Task<BusinessPartnerGroupVM> DeleteBusinessPartnerGroupDetails(string groupCode);
    }
}
