using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;

namespace OnimtaWebInventory.DTO.BusinessPartner
{
    public class BusinessPartnerRequest:BaseRequest
    {
         public BusinessPartnerVM businessPartnerVM { get; set; }
         //public BankVM bankVM { get; set; }

    }
}