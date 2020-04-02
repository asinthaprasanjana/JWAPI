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
    public class SalesInvoiceServices:ISalesInvoiceServices
    {
        private readonly IApprovalServices _approvalServices;
        private readonly INotificationServices _notificationServices;
        private readonly IUnitOfWork _unitOfWork;


        public SalesInvoiceServices( IUnitOfWork unitOfWork, IApprovalServices approvalServices, INotificationServices notificationServices)
        {
            _approvalServices = approvalServices;
            _notificationServices = notificationServices;
            _unitOfWork = unitOfWork;
        }
        public async Task<SalesInvoiceMasterVM> AddNewSalesInvoiceDetails(SalesInvoiceMasterVM salesInvoiceMasterVM)
        {
            SalesInvoiceMasterVM salesInvoiceMasterVm = new SalesInvoiceMasterVM();



            using (_unitOfWork)
            {


                try
                {
                        _unitOfWork.BeginTransaction();
                       if (salesInvoiceMasterVM.isProforma)
                    {
                        salesInvoiceMasterVm = await  _unitOfWork.SalesInvoiceRepository.AddNewProformaInvoiceSummaryDetails(salesInvoiceMasterVM);
                    }
                         else
                    {
                        salesInvoiceMasterVm = await  _unitOfWork.SalesInvoiceRepository.AddNewSalesInvoiceSummaryDetails(salesInvoiceMasterVM);
                    }

                    
                        if (salesInvoiceMasterVM.isProforma)
                        {
                            for (int i = 0; i < salesInvoiceMasterVM.salesOrderItemVM.Count(); i++)
                            {
                                await  _unitOfWork.SalesInvoiceRepository.AddNewProformaInvoiceItemDetails(salesInvoiceMasterVM.salesOrderItemVM.ElementAt(i), salesInvoiceMasterVm.DocumentNo, salesInvoiceMasterVM.CompanyId);
                            }
                        }
                        else
                        {
                            for (int i = 0; i < salesInvoiceMasterVM.salesOrderItemVM.Count(); i++)
                            {
                                await  _unitOfWork.SalesInvoiceRepository.AddNewSalesInvoiceItemDetails(salesInvoiceMasterVM.salesOrderItemVM.ElementAt(i), salesInvoiceMasterVm.DocumentNo, salesInvoiceMasterVM.CompanyId);
                            }
                        }
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

           
                    
                   
                  
            return salesInvoiceMasterVm;
        }

        public async Task<IEnumerable<SalesInvoiceSummaryVM>> GetAllInvoiceDetailsByCompanyId(int companyId)
        {
            IEnumerable<SalesInvoiceSummaryVM> salesInvoiceSummaryVM;

            
            using (_unitOfWork)
            {


                try
                {
                salesInvoiceSummaryVM = await  _unitOfWork.SalesInvoiceRepository.GetAllInvoiceDetailsByCompanyId(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return salesInvoiceSummaryVM;
        }

        public async Task<SalesInvoiceMasterVM> GetAllInvoiceDetailsByInvoiceNo(int InvoiceNo)
        {
            SalesInvoiceMasterVM salesInvoiceMasterVM = new SalesInvoiceMasterVM();
           

               
            using (_unitOfWork)
            {


                try
                {
                       salesInvoiceMasterVM = await  _unitOfWork.SalesInvoiceRepository.GetAllInvoiceSummaryDetailsByInvoiceNo(InvoiceNo);
                      salesInvoiceMasterVM.salesOrderItemVM = await  _unitOfWork.SalesInvoiceRepository.GetAllInvoicedItemDetailsByInvoiceNo(InvoiceNo);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            return salesInvoiceMasterVM;
        }
    }
}
