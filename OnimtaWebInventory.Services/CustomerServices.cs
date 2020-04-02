using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public CustomerServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerVM> GetCustomerDetailsById(int id,int companyId)
        {
            CustomerVM customerVM = new CustomerVM();
            using (_unitOfWork)
            {


                try
                {
                    customerVM = await  _unitOfWork.CustomerRepository.GetCustomerDetailsById(id, companyId);


                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
           
            return customerVM;
        }
        public async Task<CustomerVM> UpdateCustomerDetailsById(CustomerVM customerVM)
        {
            CustomerVM customerVm = new CustomerVM();
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    customerVm = await  _unitOfWork.CustomerRepository.UpdateCustomerDetailsById(customerVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();


                    throw new Exception(ex.Message);
                }
            }
                 
           
            return customerVm;
        }
        public async Task<CustomerVM> DeleteCustomerDetailsById(int id)
        {
            CustomerVM customerVM = new CustomerVM();

            using (_unitOfWork)
            {


                try
                {
                  customerVM = await  _unitOfWork.CustomerRepository.DeleteCustomerDetailsById(id);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }
                 
            return customerVM;
        }
        public async Task<CustomerVM> AddNewCustomerDetails(CustomerVM customerVM)
        {
            CustomerVM customervM = new CustomerVM();
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                     customerVM = await  _unitOfWork.CustomerRepository.AddNewCustomerDetails(customerVM);
                    _unitOfWork.CommitTransaction();


                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();

                    throw new Exception(ex.Message);
                }
            }
                 
            return customervM;
        }
    }
}