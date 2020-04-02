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
    public class PurchaseOrderReportServices : IPurchaseOrderReportServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public PurchaseOrderReportServices (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PurchaseOrderReportVM>> GetAllPurchaseOrderReportDetails()
        {
           IEnumerable< PurchaseOrderReportVM >purchaseOrderReportVM ;
            
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderReportVM = await  _unitOfWork.PurchaseOrderReportRepository.GetAllPurchaseOrderReportDetails();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderReportVM;
        }

        public async Task<IEnumerable<ReportVM>> GetNetTotalOfSalesNPurchase(int companyId)
        {
            IEnumerable<ReportVM> ReportVm;

           
            using (_unitOfWork)
            {


                try
                {
                ReportVm = await  _unitOfWork.PurchaseOrderReportRepository.GetNetTotalOfSalesNPurchase(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return ReportVm;
        }

        public async Task<IEnumerable<PurchaseOrderReportVM>> GetPurchaseOrderReportDetailsGroupByApprovalStatus(int companyId)
        {
            IEnumerable<PurchaseOrderReportVM> purchaseOrderReportVM ;
            
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderReportVM = await  _unitOfWork.PurchaseOrderReportRepository.GetPurchaseOrderReportDetailsGroupByApprovalStatus(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderReportVM;
        }

        public async Task<IEnumerable<PurchaseOrderReportVM>> GetTopReportDetailsOrderByBranchId(int isSalesOrder)
        {
            IEnumerable<PurchaseOrderReportVM> purchaseOrderReportVM ;
            using (_unitOfWork)
            {


                try
                {
                    if (isSalesOrder == 1)
                                    {
                                        purchaseOrderReportVM = await  _unitOfWork.PurchaseOrderReportRepository.GetTopSaleReportDetailsOrderByBranchId( );
                                    }
                                    else
                                    {
                                        purchaseOrderReportVM = await  _unitOfWork.PurchaseOrderReportRepository.GetTopPurchaseReportDetailsOrderByBranchId();

                                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            

           
            return purchaseOrderReportVM;
        }

        public async Task<IEnumerable<ReportVM>> GetTopSalesNPurchaseBranches(int companyId)
        {
            IEnumerable<ReportVM> ReportVm;

            using (_unitOfWork)
            {


                try
                {
                    ReportVm = await  _unitOfWork.PurchaseOrderReportRepository.GetTopSalesNPurchaseBranches(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            

            return ReportVm;
        }

        public async Task<IEnumerable<ReportVM>> GetTopSaleProducts(int companyId)
        {
            IEnumerable<ReportVM> ReportVm;

            using (_unitOfWork)
            {


                try
                {
                      ReportVm = await  _unitOfWork.PurchaseOrderReportRepository.GetTopSaleProducts(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            

            return ReportVm;
        }
    }
}
