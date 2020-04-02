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
    public class CurrencyServices : ICurrencyServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<CurrencyVM> AddNewCurrencyDetails(CurrencyVM currencyVM)
        {
            CurrencyVM currencyVm = new CurrencyVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    currencyVM = await  _unitOfWork.CurrencyRepository.AddNewCurrencyDetails(currencyVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }   
            return currencyVM;
        }
        public async Task<IEnumerable<CurrencyVM>> GetCurrencyDetails(int companyId)
        {
            IEnumerable<CurrencyVM> currencyVM;

            using (_unitOfWork)
            {
                try
                {
                   currencyVM = await  _unitOfWork.CurrencyRepository.GetCurrencyDetails(companyId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return currencyVM;
        }
    }
}
