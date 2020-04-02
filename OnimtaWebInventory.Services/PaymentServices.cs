using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Models;
using OnimtaWebInventory.UnitOfWork;
using SignalRHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace OnimtaWebInventory.Services
{
    public class PaymentServices : IPaymentServices {

        private readonly INotificationServices _notificationServices;
        private readonly IUnitOfWork _unitOfWork;


        public PaymentServices( INotificationServices notificationServices, IUnitOfWork unitOfWork)
        {
            _notificationServices = notificationServices;
            _unitOfWork = unitOfWork;
        }

        public async Task<PaymentVM> AddNewPaymentDetails( IEnumerable< PaymentVM> paymentVM)
        {
            PaymentVM paymentVm = new PaymentVM();
            PaymentVM tempPaymentVm = new PaymentVM();
            int notificationTypeid = 0;


            using (_unitOfWork)
            {


                try
                {
                    _unitOfWork.BeginTransaction();
                    double totalPayment = 0;
                    int paymentType = 0;

                    paymentType = paymentVM.ElementAt(0).PaymentType;

                    for (int i = 0; i < paymentVM.Count(); i++)
                    {

                        totalPayment = totalPayment + paymentVM.ElementAt(i).TotalPaidAmount;

                    }
                    tempPaymentVm.TotalPaidAmount = totalPayment;
                    tempPaymentVm.UserId = paymentVM.ElementAt(0).UserId;
                    tempPaymentVm.PaymentType = paymentVM.ElementAt(0).PaymentType;
                    tempPaymentVm.BusinessPartnerId = paymentVM.ElementAt(0).BusinessPartnerId;
                    tempPaymentVm.ReferenceNo = paymentVM.ElementAt(0).ReferenceNo;


                    paymentVm = await  _unitOfWork.PaymentRepository.AddNewPaymentSummeryDetails(tempPaymentVm);

                    for (int i = 0; i < paymentVM.Count(); i++)
                    {
                        if (paymentVM.ElementAt(i).TotalPaidAmount > 0)
                        {
                            paymentVM.ElementAt(i).DocumentNo = paymentVm.DocumentNo;
                            paymentVM.ElementAt(i).PaymentType = paymentVM.ElementAt(i).PaymentType;
                            await  _unitOfWork.PaymentRepository.AddNewPaymentDetails(paymentVM.ElementAt(i));
                        }

                    }

                    _unitOfWork.CommitTransaction();


                    try
                    {
                        int supplierPaymentType = 8;
                        int customerPaymentType = 9;
                        int supplierPaymentNotificationType = 30;
                        int customerPaymentNotificationType = 30;
                        MessageVM messageVM = new MessageVM();

                        if (paymentVM.ElementAt(0).PaymentType == supplierPaymentType)
                        {
                            notificationTypeid = supplierPaymentNotificationType;

                        }
                        else if (paymentVM.ElementAt(0).PaymentType == customerPaymentType)
                        {
                            notificationTypeid = customerPaymentNotificationType;
                        }
                        else
                        {
                            notificationTypeid = 0;

                        }

                        messageVM.NotificationTypeId = notificationTypeid;
                        messageVM.ReferenceUserId = paymentVM.ElementAt(0).UserId;
                        messageVM.TransactionNo = paymentVm.DocumentNo;
                        await _notificationServices.SendNotification(messageVM);
                    }
                    catch (Exception ex)
                    {

                    }
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }
            

            
            return paymentVm;
        }

        public async Task<PaymentVM> GetPaymentDetailsByPaymentId(int id)
        {
            PaymentVM paymentVM = new PaymentVM();
           

            using (_unitOfWork)
            {


                try
                {
                paymentVM = await  _unitOfWork.PaymentRepository.GetPaymentDetailsByPaymentId(id);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }



            return paymentVM;
        }

        public async Task<IEnumerable<PaymentVM>> GetPymentDetailsByCompanyId(int pageId,int businessPartnerTypeId)
        {
            IEnumerable<PaymentVM> paymentVM;
            
            using (_unitOfWork)
            {


                try
                {
                paymentVM = await  _unitOfWork.PaymentRepository.GetPymentDetailsByCompanyId(pageId, businessPartnerTypeId);

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);

                }
            }



            return paymentVM;
        }

        public async Task<IEnumerable<PurchaseOrderBilledEventsVM>> GetBusinessPartnerPayableDetails(int pageId, int businessPartnerTypeId, int businessPartnerId)
        {
            IEnumerable<PurchaseOrderBilledEventsVM > paymentVm;
           

            using (_unitOfWork)
            {


                try
                {
               paymentVm = await  _unitOfWork.PaymentRepository.GetBusinessPartnerPayableDetails(pageId, businessPartnerTypeId, businessPartnerId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            return paymentVm;
        }

        public async Task<IEnumerable<PaymentVM>> GetPaymentHistoryDetails(int pageId, int businessPartnerId, int businessPartnerTypeId)
        {
            IEnumerable<PaymentVM> paymentVM;
           
                
            using (_unitOfWork)
            {


                try
                {
                paymentVM = await  _unitOfWork.PaymentRepository.GetPaymentHistoryDetails(pageId, businessPartnerId, businessPartnerTypeId);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            return paymentVM;
        }

        public async Task<IEnumerable<PaymentVM>> GetPaymentHistoryItemsDetailsByDocumentNo(int pageId, string documentNo)
        {
            IList<PaymentVM> paymentVM = new List<PaymentVM>();
            PaymentVM tempPaymentVM = new PaymentVM();
            

               
            using (_unitOfWork)
            {


                try
                {
                tempPaymentVM.paymentItemVM = await  _unitOfWork.PaymentRepository.GetPaymentHistoryDetailsByDocumentNo(documentNo);            
                paymentVM.Add(tempPaymentVM);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


            return paymentVM;
        }
    }
}
