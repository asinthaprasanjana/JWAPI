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
   public  class ReportServices : IReportServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public ReportServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ReportVM> GetReportDetailsByReportID(int reportId,int companyId)
        {
            ReportVM reportVM = new ReportVM();
           
            using (_unitOfWork)
            {
                try
                {   
                   reportVM = await  _unitOfWork.ReportRepository.GetReportDetailsByReportID(reportId, companyId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return reportVM;
        }
    }
}
