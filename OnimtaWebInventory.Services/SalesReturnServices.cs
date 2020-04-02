using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class SalesReturnServices : ISalesReturnServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public SalesReturnServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<SalesReturnVM> AddNewSalesReturnDetails(SalesReturnVM salesReturnVM)
        {
            SalesReturnVM salesReturnVm = new SalesReturnVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    salesReturnVm = await  _unitOfWork.SalesReturnRepository.AddNewSalesReturnDetails(salesReturnVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return salesReturnVm;
        }

        public async Task<SalesReturnVM> AddNewSalesReturnDetails(SalesOrderMasterVM salesReturnVM)
        {
            SalesReturnVM salesReturnVm = new SalesReturnVM();
            string salesReturnId;

           
                
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                        salesReturnId = await  _unitOfWork.SalesReturnRepository.AddNewSalesReturnDetails(salesReturnVM);

                                for (int i = 0; i < salesReturnVM.salesOrderItemVM.Count(); i++)
                                {
                                   await  _unitOfWork.SalesReturnRepository.AddNewSalesReturnItemDetails(salesReturnVM.salesOrderItemVM.ElementAt(i), salesReturnId, salesReturnVM.SaleNo,salesReturnVM.CompanyId);
                                }
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            return salesReturnVm;
        }

        public async  Task<PurchaseOrderMasterVM> AddSalesReturnDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();

          
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    purchaseOrderMasterVM = await  _unitOfWork.SalesReturnRepository.AddSalesReturnDetails(purchaseOrderMasterVM);

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

        public async Task<IEnumerable<SalesReturnVM>> GetAllSalesDetails(int orderId)
        {
           IEnumerable< SalesReturnVM> salesReturnVM;
           
            using (_unitOfWork)
            {


                try
                {
                    salesReturnVM = await  _unitOfWork.SalesReturnRepository.GetAllSalesDetails(orderId);

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return salesReturnVM;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllSalesReturnDetails(int branchId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM ;
           
            using (_unitOfWork)
            {


                try
                {
                    purchaseOrderMasterVM = await  _unitOfWork.SalesReturnRepository.GetAllSalesReturnDetails(branchId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderMasterVM; 
        }

        public async Task<PurchaseOrderMasterVM> GetSalesReturnDetailsById(int id)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
          

            using (_unitOfWork)
            {


                try
                {
                     purchaseOrderMasterVM = await  _unitOfWork.SalesReturnRepository.GetSalesReturnDetailsById(id);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderMasterVM;
        }

        public async Task<SalesReturnVM> GetSalesDetailsById(int orderId)
        {
            SalesReturnVM salesReturnVM = new SalesReturnVM();
            
            using (_unitOfWork)
            {


                try
                {
                salesReturnVM = await  _unitOfWork.SalesReturnRepository.GetSalesDetailsById(orderId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return salesReturnVM;
        }

        public async Task<SalesReturnVM> UpdateSalesReturnDetails(SalesReturnVM salesReturnVM)
        {
            SalesReturnVM salesReturnVm = new SalesReturnVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                      salesReturnVm = await  _unitOfWork.SalesReturnRepository.UpdateSalesReturnDetails(salesReturnVM);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            return salesReturnVm;
        }

        public async Task<PurchaseOrderMasterVM> UpdateSalesReturn(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
           
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                      purchaseOrderMasterVM = await  _unitOfWork.SalesReturnRepository.UpdateSalesReturn(purchaseOrderMasterVM);

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
