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
    public class GeneralSettingServices : IGeneralSettingServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public GeneralSettingServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymentMethodVM> AddNewPaymentDetails(PaymentMethodVM paymentMethodVM)
        {

  
                PaymentMethodVM paymentMethodVm = new PaymentMethodVM();
            using (_unitOfWork)
            {
                _unitOfWork.BeginTransaction();
                paymentMethodVM = await _unitOfWork.GeneralSettingRepository.AddNewPaymentDetails(paymentMethodVM);

                _unitOfWork.CommitTransaction();
            }



            return paymentMethodVM;
        }

        public async Task<IEnumerable<PaymentMethodVM>> GetAllPaymentDetails()
        {
            IEnumerable<PaymentMethodVM> paymentMethodVM;
            
            using (_unitOfWork)
            {
                try
                {
                                paymentMethodVM = await  _unitOfWork.GeneralSettingRepository.GetAllPaymentDetails();

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }

            return paymentMethodVM;
        }

        public async Task<PaymentMethodVM> UpdatePaymentDetails(PaymentMethodVM paymentMethodVM)
        {
            PaymentMethodVM paymentMethodVm = new PaymentMethodVM();
            
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    paymentMethodVM = await _unitOfWork.GeneralSettingRepository.UpdatePaymentDetails(paymentMethodVM);

                    _unitOfWork.CommitTransaction();

                } catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
               
            }

            return paymentMethodVM;
        }
    }
}
