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
    public class AdvancePaymentServices : IAdvancePaymentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdvancePaymentServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AdvancePaymentVM> AddNewAdvancePayment(AdvancePaymentVM advancePaymentVM)
        {
            AdvancePaymentVM advancePaymentVm = new AdvancePaymentVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    advancePaymentVM = await _unitOfWork.AdvancePaymentRepository.AddNewAdvancePayment(advancePaymentVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return advancePaymentVM;
        }

        public async Task<AdvancePaymentVM> GetAdvancePaymentDetailsById(string AdvancePaymentId)
        {
            AdvancePaymentVM advancePaymentVM = new AdvancePaymentVM();
           
            using (_unitOfWork)
            {

                try
                {
                    advancePaymentVM = await _unitOfWork.AdvancePaymentRepository.GetAdvancePaymentDetailsById(AdvancePaymentId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return advancePaymentVM;
        }

        public async Task< AdvancePaymentVM> GetAdvancePaymentDetailsByBspId(string BusinessPartnerId)
        {
            AdvancePaymentVM advancePaymentVM = new AdvancePaymentVM();
            

            using (_unitOfWork)
            {

                try
                {
                    advancePaymentVM = await _unitOfWork.AdvancePaymentRepository.GetAdvancePaymentDetailsByBspId(BusinessPartnerId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return advancePaymentVM;
        }

       
        public async Task<IEnumerable<AdvancePaymentVM>> GetAllAdvancePaymentDetails()
        {
            IEnumerable<AdvancePaymentVM> advancePaymentVM;
           
            using (_unitOfWork)
            {
                try
                {
                     advancePaymentVM = await _unitOfWork.AdvancePaymentRepository.GetAllAdvancePaymentDetails();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return advancePaymentVM;
        }

        public async Task<IEnumerable<AdvancePaymentVM>> GetAllAdvancePaymentDetailsByBspId(string BusinessPartnerId)
        {
            IEnumerable<AdvancePaymentVM> advancePaymentVM;

            using (_unitOfWork)
            {
                try
                {
                    advancePaymentVM = await _unitOfWork.AdvancePaymentRepository.GetAllAdvancePaymentDetailsByBspId(BusinessPartnerId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return advancePaymentVM;
        }
    }
}
