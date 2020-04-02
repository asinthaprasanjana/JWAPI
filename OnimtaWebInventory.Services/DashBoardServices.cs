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
    public class DashBoardServices : IDashBoardServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public DashBoardServices(  IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<DashBoardVM>> GetAllDashBoardDetails(int TypeId)
        {
            IEnumerable<DashBoardVM> dashBoardVM;
            using (_unitOfWork)
            {

                try
                {
                    dashBoardVM = await  _unitOfWork.DashBoardRepository.GetAllDashBoardDetails(TypeId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return dashBoardVM;
        }

        public async Task<DashBoardVM> GetReportDetails(int reportTypeId, int branchId, DateTime fromDate, DateTime toDate)
        {
            DashBoardVM dashBoardVM = new DashBoardVM();

            using (_unitOfWork)
            {


                try
                {
                   dashBoardVM = await  _unitOfWork.DashBoardRepository.GetReportDetails(reportTypeId, branchId, fromDate, toDate);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

          

            return dashBoardVM;
        }
    }
}
