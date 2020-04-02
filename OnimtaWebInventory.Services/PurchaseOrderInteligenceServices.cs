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
    public class PurchaseOrderInteligenceServices : IPurchaseOrderInteligenceServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public PurchaseOrderInteligenceServices(IPurchaseOrderInteligenceRepository PurchaseOrderInteligenceRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PurchaseAndSalesSummaryVM> GetPurchaseorderAndSalesOrderSummaryDeails(int companyId)
        {
            PurchaseAndSalesSummaryVM purchaseAndSalesSummaryVM = new PurchaseAndSalesSummaryVM();
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
            purchaseAndSalesSummaryVM = await  _unitOfWork.PurchaseOrderInteligenceRepository.GetPurchaseorderAndSalesOrderSummaryDeails(companyId);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }

            
            return purchaseAndSalesSummaryVM;
        }
    }
}
