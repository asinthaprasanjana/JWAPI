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
    public class PrintHistoryDetailsServices : IPrintHistoryDetailsServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public PrintHistoryDetailsServices(IPrintHistoryDetailsRepository PrintHistoryDetailsRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PrintHistoryDetailsVM>> GetAllPrintHistoryDetails(int pageId)
        {
            IEnumerable<PrintHistoryDetailsVM> printHistoryDetailsVM;

           

            using (_unitOfWork)
            {


                try
                {
                printHistoryDetailsVM = await  _unitOfWork.PrintHistoryDetailsRepository.GetAllPrintHistoryDetails(pageId);

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }



            return printHistoryDetailsVM;
        }
    }
}
