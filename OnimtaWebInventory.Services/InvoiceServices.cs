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
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public InvoiceServices(IInvoiceRepository InvoiceRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<PurchaseOrderMasterVM> AddNewInvoiceDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
          
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderMasterVM = await  _unitOfWork.InvoiceRepository.AddNewInvoiceDetails(purchaseOrderMasterVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderMasterVM;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllInvoiceDetails(int branchId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderMasterVM = await  _unitOfWork.InvoiceRepository.GetAllInvoiceDetails(branchId);

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> GetInvoiceDetailsById(int id)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderMasterVM = await  _unitOfWork.InvoiceRepository.GetInvoiceDetailsById(id);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderMasterVM;
        }

        public async Task<PurchaseOrderMasterVM> UpdateInvoiceDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderMasterVM = await  _unitOfWork.InvoiceRepository.UpdateInvoiceDetails(purchaseOrderMasterVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderMasterVM;
        }
    }
}
