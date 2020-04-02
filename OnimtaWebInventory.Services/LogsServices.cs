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
    public class LogsServices : ILogsServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public LogsServices(ILogsRepository LogsRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<LogsVM>> GetAllLogDetailsByPageId(int pageId)
        {
            IEnumerable<LogsVM> logsVM;

           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                logsVM = await  _unitOfWork.LogsRepository.GetAllLogDetailsByPageId(pageId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return logsVM;
        }

        public async Task<IEnumerable<LogsVM>> GetLogsDetailsByLevel(string level)
        {
            IEnumerable<LogsVM> logsVM;

            
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                logsVM = await  _unitOfWork.LogsRepository.GetLogsDetailsByLevel(level);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }


            return logsVM;
        }
    }
}
