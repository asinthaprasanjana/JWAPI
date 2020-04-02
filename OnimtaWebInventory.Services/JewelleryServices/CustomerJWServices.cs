using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.Models.Jewellery;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services.JewelleryServices
{
    public class CustomerJWServices : ICustomerJWServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerJWServices(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public async Task<CustomerJw> AddJewelleryCustomerDetails(CustomerJw CustomerJw)
        {
            CustomerJw customerJW = new CustomerJw();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    customerJW = await _unitOfWork.CustomerJWRepository.AddJewelleryCustomerDetails(CustomerJw);
                    _unitOfWork.CommitTransaction();
                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return customerJW;
        }

        public async Task<CustomerJw> AddSalesManDetails(CustomerJw CustomerJw)
        {
            CustomerJw customerJW = new CustomerJw();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    customerJW = await _unitOfWork.CustomerJWRepository.AddSalesManDetails(CustomerJw);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return customerJW;
        }

        public async Task<CustomerJw> DeleteJewelleryCustomerDetails(int id)
        {
            CustomerJw customerJW = new CustomerJw();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    customerJW = await _unitOfWork.CustomerJWRepository.DeleteJewelleryCustomerDetails(id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return customerJW;
        }

        public async Task<CustomerJw> DeleteSalesManDetails(int id)
        {
            CustomerJw customerJW = new CustomerJw();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    customerJW = await _unitOfWork.CustomerJWRepository.DeleteSalesManDetails(id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return customerJW;
        }

        public async Task<IEnumerable<CustomerJw>> GetJewelleryCustomerDetails(FilterVM filter)
        {
            IEnumerable<CustomerJw> CustomerJw;

            using (_unitOfWork)
            {
                try
                {
                    CustomerJw = await _unitOfWork.CustomerJWRepository.GetJewelleryCustomerDetails(filter);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return CustomerJw;
        }

        public async Task<IEnumerable<CustomerJw>> GetSalesManDetails(FilterVM filter)
        {
            IEnumerable<CustomerJw> customerJW;

            using (_unitOfWork)
            {
                try
                {
                    customerJW = await _unitOfWork.CustomerJWRepository.GetSalesManDetails(filter);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return customerJW;
        }

        public async Task<CustomerJw> UpdateJewelleryCustomerDetails(CustomerJw CustomerJw)
        {
            CustomerJw customerJW = new CustomerJw();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    customerJW = await _unitOfWork.CustomerJWRepository.UpdateJewelleryCustomerDetails(CustomerJw);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return customerJW;
        }

        public async Task<CustomerJw> UpdateSalesManDetails(CustomerJw CustomerJw)
        {
            CustomerJw customerJW = new CustomerJw();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    customerJW = await _unitOfWork.CustomerJWRepository.UpdateSalesManDetails(CustomerJw);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return customerJW;
        }
    }
}
