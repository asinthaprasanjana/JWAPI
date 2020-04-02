using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Services
{
    public class IndustryAttributeServices : IIndustryAttributeServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndustryAttributeServices(  IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IndustryVM> AddIndustryAttributeDetails(IndustryVM industryVM)
        {
            IndustryVM industryVm = new IndustryVM();

           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                industryVM = await  _unitOfWork.IndustryAttributeRepository.AddIndustryAttributeDetails(industryVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return industryVM;
        }

        public async Task<IEnumerable<IndustryVM>> GetAllIndustryAttributeDetails()
        {
            IEnumerable<IndustryVM> industryAttributeVM;

           
            using (_unitOfWork)
            {


                try
                {
                industryAttributeVM = await  _unitOfWork.IndustryAttributeRepository.GetAllIndustryAttributeDetails();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return industryAttributeVM;
        }

        public async Task<IEnumerable<IndustryNameVM>> GetIndustryName()
        {
            IEnumerable<IndustryNameVM> industryNameVM;

            
            using (_unitOfWork)
            {


                try
                {
                industryNameVM = await  _unitOfWork.IndustryAttributeRepository.GetIndustryName();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            return industryNameVM;
        }

        public async Task<IndustryVM> UpdateIndustryAttributeDetails(IndustryVM industryVM)
        {
            IndustryVM industryVm = new IndustryVM();

          
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                industryVM = await  _unitOfWork.IndustryAttributeRepository.UpdateIndustryAttributeDetails(industryVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return industryVM;
        }

        
    }
}
