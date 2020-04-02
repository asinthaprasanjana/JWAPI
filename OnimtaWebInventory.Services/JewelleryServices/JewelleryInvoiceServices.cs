using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.Models.Jewellery;
using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Data;

using System.IO;
 
using Dapper;

namespace OnimtaWebInventory.Services.JewelleryServices
{
    public class JewelleryInvoiceServices : IJewelleryInvoiceServices
    {
        private readonly IUnitOfWork _unitOfWork;

        public JewelleryInvoiceServices(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        public async Task<InvoiceVM> AddJewelleryAdvance(InvoiceVM Advance)
        {
            InvoiceVM invoiceVM = new InvoiceVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.AddJewelleryAdvance(Advance);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVM;
        }

        public async Task<InvoiceVM> AddJewelleryInvoice(InvoiceVM Invoice)
        {
            InvoiceVM invoice = new InvoiceVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    invoice = await _unitOfWork.JewelleryInvoiceRepository.AddJewelleryInvoice(Invoice);

                    dsForReports dsr = new dsForReports();
                    DataSet dsInvoice = new DataSet();

                    DataTable dtInvoice = dsr.Tables["invoice"];
                    

                    DataRow dr = dtInvoice.NewRow();
                    dr["Name"] = invoice.Name;
                    dr["Address"] = invoice.Address;
                    dr["Contact"] = invoice.Contact;
                    dr["Total"] = invoice.Total;
                    dr["Advance"] = invoice.Advance;
                    dr["Cash"] = invoice.Cash;
                    dr["Cheque"] = invoice.Cheque;
                    dr["CreditCard"] = invoice.CreditCard;
                    dr["Gold"] = invoice.Gold;
                    dr["BalanceDue"] = invoice.Balance;
                    dtInvoice.Rows.Add(dr);

                    //dsInvoice.Tables.Add(dtInvoice);

                    DataTable dtProduct = dsr.Tables["products"];

                    foreach(InvoiceProductVM product in invoice.Products)
                    {
                        DataRow dr1 = dtProduct.NewRow();
                        dr1["Description"] = product.ProductObj.Description; 
                        dr1["ItemCode"] = product.ProductObj.ItemCode;
                        dr1["Standard"] = product.Standard;
                        dr1["ItemWeight"] = product.ItemWeight;
                        dr1["DiamondWeight"] = product.DiamondWeight;
                        dr1["StoneWeight"] = product.StoneWeight;
                        dr1["Amount"] = product.Amount;
                        dtProduct.Rows.Add(dr1);
                    }

                    //dsInvoice.Tables.Add(dtProduct);

                    //Print p = new Print();
                    //byte[] rpt_bytArr = p.CreateReport(dsr);

                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return invoice;
        }

        public async Task<RewardsVM> AddJewelleryReward(RewardsVM rewardsVM)
        {
            RewardsVM rewardsVm = new RewardsVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    rewardsVm = await _unitOfWork.JewelleryInvoiceRepository.AddJewelleryReward(rewardsVM);
                    _unitOfWork.CommitTransaction();

                } catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return rewardsVm;
        }

        public async Task<IEnumerable<InvoiceVM>> GetAdvanceDetailsByDateRange(DateTime From, DateTime To)
        {
            IEnumerable<InvoiceVM> invoiceVM;
            using (_unitOfWork)
            {
                try
                {
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.GetAdvanceDetailsByDateRange(From, To);

                }catch(Exception ex){
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVM;
        }

        public async Task<InvoiceVM> GetAdvanceDetailsById(int id)
        {
            InvoiceVM advance = new InvoiceVM();

            using (_unitOfWork)
            {
                try
                {
                    advance = await _unitOfWork.JewelleryInvoiceRepository.GetAdvanceDetailsById(id);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return advance;    
        }

        public async Task<IEnumerable<InvoiceVM>> GetAllAdvanceDetails(FilterVM filter)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            using (_unitOfWork)
            {
                try
                {
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.GetAllAdvanceDetails(filter);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVM;
        }

        public async Task<IEnumerable<InvoiceVM>> GetAllInvoices(FilterVM filter)
        {
            IEnumerable<InvoiceVM> Invoices;

            using (_unitOfWork)
            {
                try
                {
                    Invoices = await _unitOfWork.JewelleryInvoiceRepository.GetAllInvoices(filter);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return Invoices;
        }


        public async Task<InvoiceVM> GetInvoiceById(int Id)
        {
            InvoiceVM Invoice = new InvoiceVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    Invoice = await _unitOfWork.JewelleryInvoiceRepository.GetInvoiceById(Id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return Invoice;
        }

        public async Task<IEnumerable<InvoiceVM>> GetInvoiceDetailsByDateRange(DateTime From, DateTime To)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            using (_unitOfWork)
            {
                try
                {
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.GetInvoiceDetailsByDateRange(From, To);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVM;
        }

        public async Task<IEnumerable<InvoiceVM>> GetJewelleryInvoiceUploaded()
        {
            IEnumerable<InvoiceVM> invoiceVM;
            using (_unitOfWork)
            {
                try
                {
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.GetJewelleryInvoiceUploaded();

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVM;
        }

        public async Task<InvoiceVM> InvoiceCancellation(InvoiceVM invoiceVM)
        {
            InvoiceVM invoice = new InvoiceVM();

            using(_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    invoice = await _unitOfWork.JewelleryInvoiceRepository.InvoiceCancellation(invoiceVM);
                    _unitOfWork.CommitTransaction();

                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return invoice;
        }

        public async Task<InvoiceVM> InvoiceReturn(InvoiceVM invoiceVM)
        {
            InvoiceVM invoice = new InvoiceVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    invoice = await _unitOfWork.JewelleryInvoiceRepository.InvoiceReturn(invoiceVM);
                    _unitOfWork.CommitTransaction();

                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return invoice;
        }

        public async Task<IEnumerable<InvoiceVM>> JewelleryDailySummary(InvoiceVM invoiceVM)
        {
            IEnumerable<InvoiceVM> invoiceVm;

            using (_unitOfWork)
            {
                try
                {
                    invoiceVm = await _unitOfWork.JewelleryInvoiceRepository.JewelleryDailySummary(invoiceVM);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVm;
        }

        public async Task<IEnumerable<InvoiceVM>> SearchAdvanceDetails(string Keyword)
        {
           IEnumerable <InvoiceVM> invoiceVM;

            using (_unitOfWork)
            {
                try
                {
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.SearchAdvanceDetails(Keyword);

                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVM;
        }

        public async Task<IEnumerable<InvoiceVM>> SearchInvoiceDetails(string Keyword, int PageId)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            using (_unitOfWork)
            {
                try
                {
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.SearchInvoiceDetails(Keyword,PageId);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVM;
        }

        public async Task<InvoiceVM> UpdateInvoice(InvoiceVM invoiceVM)
        {
            InvoiceVM invoiceVm = new InvoiceVM();
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    invoiceVm = await _unitOfWork.JewelleryInvoiceRepository.UpdateInvoice(invoiceVM);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception();
                }
            }
            return invoiceVm;
        }

        public async Task<InvoiceVM> UpdateInvoiceUploadInfo(Boolean state, int invoiceId)
        {
            InvoiceVM invoiceVm = new InvoiceVM();
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    invoiceVm = await _unitOfWork.JewelleryInvoiceRepository.UpdateInvoiceUploadInfo(state,invoiceId);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception();
                }
            }
            return invoiceVm;
        }

        public async Task<IEnumerable<InvoiceVM>> GetAllInvoiceReturns(FilterVM filter)
        {
            IEnumerable<InvoiceVM> Invoices;

            using (_unitOfWork)
            {
                try
                {
                    Invoices = await _unitOfWork.JewelleryInvoiceRepository.GetAllInvoiceReturns(filter);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return Invoices;
        }

        public async Task<InvoiceVM> GetInvoiceReturnsById(int Id)
        {
            InvoiceVM Invoice = new InvoiceVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    Invoice = await _unitOfWork.JewelleryInvoiceRepository.GetInvoiceReturnsById(Id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return Invoice;
        }

        public async Task<IEnumerable<InvoiceVM>> SearchJewelleryInvoiceReturnDetails( string keyWord)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            using (_unitOfWork)
            {
                try
                {
                    invoiceVM = await
                        _unitOfWork.JewelleryInvoiceRepository.SearchJewelleryInvoiceReturnDetails( keyWord);
                }catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return invoiceVM;
        }

        public async Task<PettyCashVM> AddJewelleryPettyCash(PettyCashVM cash)
        {
            PettyCashVM Cash = new PettyCashVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    Cash = await _unitOfWork.JewelleryInvoiceRepository.AddJewelleryPettyCash(cash);
                    _unitOfWork.CommitTransaction();

                }catch(Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return Cash;
        }

        public async Task<PettyCashVM> UpdateJewelleryPettyCash(PettyCashVM cash)
        {
            PettyCashVM Cash = new PettyCashVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    Cash = await _unitOfWork.JewelleryInvoiceRepository.UpdateJewelleryPettyCash(cash);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }
            return Cash;
        }

        public async Task<InvoiceVM> DeleteJewelleryPettyCash(int id)
        {
            InvoiceVM invoiceVM = new InvoiceVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.DeleteJewelleryPettyCash(id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return invoiceVM;
        }

        public async Task<IEnumerable<InvoiceVM>> GetAllJewelleryPettyCashDetails()
        {
            IEnumerable<InvoiceVM> invoiceVM ;

            using (_unitOfWork)
            {
                try
                {
                    invoiceVM = await _unitOfWork.JewelleryInvoiceRepository.GetAllJewelleryPettyCashDetails();

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            return invoiceVM;
        }

        public async Task<IEnumerable<PettyCashVM>> GetJewelleryPettyCashDetailsByDate(PettyCashVM cash)
        {
            IEnumerable<PettyCashVM> cashVMs; 

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    cashVMs = await _unitOfWork.JewelleryInvoiceRepository.GetJewelleryPettyCashDetailsByDate(cash);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return cashVMs;
        }

        public async Task<RefundVM> AddRefund(RefundVM Refund)
        {
            RefundVM refund = new RefundVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    refund = await _unitOfWork.JewelleryInvoiceRepository.AddRefund(Refund);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return refund;
        }

        public async Task<RefundVM> CancelRefund(RefundVM Refund)
        {
            RefundVM refund = new RefundVM();

            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    refund = await _unitOfWork.JewelleryInvoiceRepository.CancelRefund(Refund);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return refund;
        }

        public async Task<IEnumerable<RefundVM>> GetRefundsByReturnId(int Id)
        {
            IEnumerable<RefundVM> refunds;
            using (_unitOfWork)
            {
                try
                {
                    _unitOfWork.BeginTransaction();
                    refunds = await _unitOfWork.JewelleryInvoiceRepository.GetRefundsByReturnId(Id);
                    _unitOfWork.CommitTransaction();
                }
                catch (Exception ex)
                {
                    _unitOfWork.RollbackTransaction();
                    throw new Exception(ex.Message);
                }
            }

            return refunds;
        }
    }
}
