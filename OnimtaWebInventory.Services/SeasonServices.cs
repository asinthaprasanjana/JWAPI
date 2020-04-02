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
    public class SeasonServices : ISeasonServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public SeasonServices(ISeasonRepository ISeasonRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SeasonVM> AddNewSeasonDetails(SeasonVM seasonVM)
        {
            SeasonVM seasonVm = new SeasonVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    seasonVm = await  _unitOfWork.SeasonRepository.AddNewSeasonDetails(seasonVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return seasonVm;
        }

        public async Task<IEnumerable<SeasonVM>> GetAllSeasonDetailsById(int id)
        {
            IEnumerable<SeasonVM> seasonVM;
           
            using (_unitOfWork)
            {


                try
                {
                seasonVM = await  _unitOfWork.SeasonRepository.GetAllSeasonDetailsById(id);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }



            return seasonVM;
        }

        public async Task<SeasonVM> UpdateSeasonDetails(SeasonVM seasonVM)
        {
            SeasonVM seasonVm = new SeasonVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    seasonVM = await  _unitOfWork.SeasonRepository.UpdateSeasonDetails(seasonVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return seasonVM;
        }
    }
}
