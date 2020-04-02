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
    public class CashierServices : ICashierServices
    {
        private readonly IUnitOfWork _unitOfWork;


        public CashierServices( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<PurchaseOrderBilledEventsVM> addNewBillPayment(PurchaseOrderBilledEventsFinalVM purchaseOrderBilledEventsFinalVMs)
        {
            List<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVms = new List<PurchaseOrderBilledEventsVM>();
            purchaseOrderBilledEventsVms = purchaseOrderBilledEventsFinalVMs.purchaseOrderBilledEventsVM.ToList();
            PurchaseOrderBilledEventsVM purchaseOrderBilledEventsVm = new PurchaseOrderBilledEventsVM();

            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                     for (int i = 0; i < purchaseOrderBilledEventsVms.Count(); i++)
                                        {
                                            purchaseOrderBilledEventsVm = await  _unitOfWork.CashierRepository.addNewBillPayment(
                                                purchaseOrderBilledEventsVms.ElementAt(i),
                                                purchaseOrderBilledEventsFinalVMs.isBalanceToAdvance,
                                                purchaseOrderBilledEventsFinalVMs.balanceAmount,
                                                purchaseOrderBilledEventsFinalVMs.isAdvancePayments,
                                                purchaseOrderBilledEventsFinalVMs.advancePaymentAmount
                                                );
                                            if (purchaseOrderBilledEventsFinalVMs.isAdvancePayments == 1)
                                            {
                                                purchaseOrderBilledEventsFinalVMs.isAdvancePayments = 0;
                                            }
                                            if (purchaseOrderBilledEventsFinalVMs.isBalanceToAdvance == 1)
                                            {
                                                purchaseOrderBilledEventsFinalVMs.isBalanceToAdvance = 0;
                                            }
                                        }

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           
                  

            return purchaseOrderBilledEventsVm;

        }

        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> getBillPaymentEventsByBusinessPartnerIdAndBillID(string BillIds)
        {
            List<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM = new List<PurchaseOrderBilledEventsVM>();
            List<PurchaseOrderBilledEventsVM> tempPurchaseOrderBilledEventsVM = new List<PurchaseOrderBilledEventsVM>();
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVm;

            using (_unitOfWork)
            {


                try
                {
                         purchaseOrderBilledEventsVm = await  _unitOfWork.CashierRepository.getBillPaymentEventsByBusinessPartnerIdAndBillID(BillIds);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }


            
            

            return purchaseOrderBilledEventsVm;

        }

        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> getAllBillPaymentDetails()
        {
            
            IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVm;
           
            using (_unitOfWork)
            {


                try
                {
                purchaseOrderBilledEventsVm = await  _unitOfWork.CashierRepository.getAllBillPaymentDetails();

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }




            return purchaseOrderBilledEventsVm;

        }

        public async Task<IEnumerable<BillPaymentVM>> getBillPaymentDetailsById(int billId)
        {

            IEnumerable<BillPaymentVM> billPaymentVM;
            using (_unitOfWork)
            {


                try
                {
                    billPaymentVM = await  _unitOfWork.CashierRepository.getBillPaymentDetailsById(billId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }


          


            return billPaymentVM;

        }

        public async Task<AdvancePaymentVM> getTotalAdvacePaymentsByBusinessPartnerId(string businessPartnerId)
        {
            AdvancePaymentVM advancePaymentVM = new AdvancePaymentVM();
            using (_unitOfWork)
            {


                try
                {
                advancePaymentVM = await  _unitOfWork.CashierRepository.getTotalAdvacePaymentsByBusinessPartnerId(businessPartnerId);

                }
                catch (Exception ex)
                {

                    throw new Exception(ex.Message);
                }
            }

           

            return advancePaymentVM;
        }
    }
}
