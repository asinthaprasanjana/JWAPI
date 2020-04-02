using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IRepository.IJewelleryRepository
{
    public interface ICustomerJWRepository
    {
        Task<CustomerJw> AddJewelleryCustomerDetails(CustomerJw CustomerJw);
        Task<CustomerJw> UpdateJewelleryCustomerDetails(CustomerJw CustomerJw);
        Task<CustomerJw> DeleteJewelleryCustomerDetails(int id);
        Task<IEnumerable<CustomerJw>> GetJewelleryCustomerDetails(FilterVM filter);

        Task<CustomerJw> AddSalesManDetails(CustomerJw CustomerJw);
        Task<CustomerJw> UpdateSalesManDetails(CustomerJw CustomerJw);
        Task<CustomerJw> DeleteSalesManDetails(int id);
        Task<IEnumerable<CustomerJw>> GetSalesManDetails(FilterVM filter);

    }
}
