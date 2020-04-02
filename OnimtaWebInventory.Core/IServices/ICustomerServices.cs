using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Core.IServices
{
    public interface ICustomerServices
    {
        Task<CustomerVM> GetCustomerDetailsById(int id, int companyId);
        Task<CustomerVM> UpdateCustomerDetailsById(CustomerVM customerVM );
        Task<CustomerVM> AddNewCustomerDetails(CustomerVM customerVM);
        Task<CustomerVM> DeleteCustomerDetailsById(int id);
    }
}
