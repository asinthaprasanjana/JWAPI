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
    public class PurchaseOrderReturnServices : IPurchaseOrderReturnServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public PurchaseOrderReturnServices(IPurchaseOrderReturnRepository IPurchaseOrderReturnRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<PurchaseOrderMasterVM> AddPurchaseOrderReturnDetails(PurchaseOrderMasterVM purchaseOrderMasterVM)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVm = new PurchaseOrderMasterVM();
            string PurchaseReturnId = "";

                   
            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                  PurchaseReturnId = await  _unitOfWork.PurchaseOrderReturnRepository.AddPurchaseOrderReturnDetails(purchaseOrderMasterVM);

                    for(int i=0;i<purchaseOrderMasterVM.purchaseOrderItemVM.Count();i++)
                    {   
                        await  _unitOfWork.PurchaseOrderReturnRepository.AddPurchaseOrderReturnItemDetails(purchaseOrderMasterVM.purchaseOrderItemVM.ElementAt(i),PurchaseReturnId);
                    }

                    _unitOfWork.RollbackTransaction();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
            return purchaseOrderMasterVm;
        }

        public async Task<IEnumerable<PurchaseOrderMasterVM>> GetAllPurchaseOrderReturnDetails(int companyId)
        {
            IEnumerable<PurchaseOrderMasterVM> purchaseOrderMasterVM;
           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderMasterVM = await  _unitOfWork.PurchaseOrderReturnRepository.GetAllPurchaseOrderReturnDetails(companyId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderMasterVM;
        }

        public async Task<IEnumerable<PurchaseOrderItemVM>> GetPurchaseOrderReturnItemDetailsById(int purchaseOrderReturnId)
        {
            IEnumerable<PurchaseOrderItemVM> purchaseOrderItemVM;
           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderItemVM = await  _unitOfWork.PurchaseOrderReturnRepository.GetPurchaseOrderReturnItemDetailsById(purchaseOrderReturnId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

            return purchaseOrderItemVM;
        }
    }
}
