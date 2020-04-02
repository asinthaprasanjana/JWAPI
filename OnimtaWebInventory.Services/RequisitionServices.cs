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
    public class RequisitionServices : IRequisitionServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public RequisitionServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<RequisitionVM> AddRequisitionDetails(RequisitionVM requisitionVM)
        {
            RequisitionVM requisitionVm = new RequisitionVM();
           
                 using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                                      requisitionVM = await  _unitOfWork.RequisitionRepository.AddRequisitionDetails(requisitionVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
           
            return requisitionVM;
        }
    }
}
