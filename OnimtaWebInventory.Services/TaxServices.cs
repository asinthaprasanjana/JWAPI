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
    public class TaxServices : ITaxServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public TaxServices(ITaxRepository ITaxRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TaxVM> AddTaxDetails(TaxVM taxVM)
        {
            TaxVM taxVm = new TaxVM();
           
            using (_unitOfWork)
            {

                try
                {
                    _unitOfWork.BeginTransaction();
                    taxVm = await _unitOfWork.TaxRepository.AddTaxDetails(taxVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return taxVm;
        }

        public async Task<IEnumerable<TaxVM>> GetTaxDetails()
        {
            IEnumerable<TaxVM> taxVMs;
            
            using (_unitOfWork)
            {
                try
                {
                  taxVMs = await _unitOfWork.TaxRepository.GetTaxDetails();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return taxVMs;
        }

        public async Task<TaxVM> GetTaxDetailsByTaxNumber(int taxNo,int companyId)
        {
            TaxVM taxVM = new TaxVM();
            
            using (_unitOfWork)
            {
                try
                {
                taxVM = await _unitOfWork.TaxRepository.GetTaxDetailsByTaxNumber(taxNo, companyId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return taxVM;
        }

        public async Task<TaxVM> UpdateTaxDetails(TaxVM taxVM)
        {
            TaxVM taxVm = new TaxVM();
           
                    /* Perform transactional work here */

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    taxVm = await _unitOfWork.TaxRepository.UpdateTaxDetails(taxVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return taxVm;
        }
    }
}
