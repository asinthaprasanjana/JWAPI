using Dapper;
using DBConnect;
using OnimtaWebInventory.Core.IRepository.IJewelleryRepository;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Repository.JewelleryRepository
{
   public  class JewelleryInvoiceRepository : DBContext, IJewelleryInvoiceRepository
    {

        public async Task<InvoiceVM> AddJewelleryInvoice(InvoiceVM Invoice)
        {
            InvoiceVM invoice = new InvoiceVM();
            RewardsVM rewards = new RewardsVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", Invoice.Name);
                dynamicParameterlist.Add("@Address", Invoice.Address);
                dynamicParameterlist.Add("@Contact", Invoice.Contact);
                dynamicParameterlist.Add("@Total", Invoice.Total);
                dynamicParameterlist.Add("@Advance", Invoice.Advance);
                dynamicParameterlist.Add("@Cash", Invoice.Cash);
                dynamicParameterlist.Add("@Cheque", Invoice.Cheque);
                dynamicParameterlist.Add("@CreditCard", Invoice.CreditCard);
                dynamicParameterlist.Add("@Voucher", Invoice.Voucher);
                dynamicParameterlist.Add("@Gold", Invoice.Gold);
                dynamicParameterlist.Add("@BalanceDue", Invoice.BalanceDue);
                dynamicParameterlist.Add("@CreatedUserId", Invoice.CreatedUserId);
                dynamicParameterlist.Add("@Country", Invoice.Country);
                dynamicParameterlist.Add("@Reference", Invoice.Reference);
                dynamicParameterlist.Add("@Remark", Invoice.Remark);
                dynamicParameterlist.Add("@setOff", Invoice.SetOff);
                dynamicParameterlist.Add("@Customer", Invoice.Customer);
                dynamicParameterlist.Add("@Salesman", Invoice.Salesman);
                dynamicParameterlist.Add("@TransNo", Invoice.TransNo);
                invoice = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddJewelleryInvoice]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                Invoice.Id = invoice.Id;
                Invoice.BatchCode = invoice.BatchCode;
                Invoice.CreatedDateTime = invoice.CreatedDateTime;
                Invoice.CreatedDateTimeUTC = invoice.CreatedDateTimeUTC;
                Invoice.DocumentNumber = invoice.DocumentNumber;
                Invoice.ReceiptNumber = invoice.ReceiptNumber;
                foreach (InvoiceProductVM product in Invoice.Products)
                {
                    var dynamicProduct = new DynamicParameters();
                    dynamicProduct.Add("@InvoiceId", invoice.Id);
                    dynamicProduct.Add("@productId", product.ProductId);
                    dynamicProduct.Add("@Standard", product.Standard);
                    dynamicProduct.Add("@DiamondWeight", product.DiamondWeight);
                    dynamicProduct.Add("@ItemWeight", product.ItemWeight);
                    dynamicProduct.Add("@StoneWeight", product.StoneWeight);
                    dynamicProduct.Add("@Amount", product.Amount);
                    dynamicProduct.Add("@UserId", Invoice.CreatedUserId);

                    await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddJewelleryInvoiceProducts]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);

                }

                int paymentDocNumber = new int();
                string DocumentNumber = "";

                if(Invoice.Payments.Count() > 0)
                {
                    var dynamicProduct = new DynamicParameters();
                    DocumentNumber = await dbConnection.QuerySingleOrDefaultAsync<string>("[inv].[GetPaymentDocNumber]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);
                }
              
                foreach (CreditVM payment in Invoice.Payments)
                {
                    var dynamicPayment = new DynamicParameters();
                    dynamicPayment.Add("@InvoiceId", invoice.Id);
                    dynamicPayment.Add("@Amount", payment.Amount);
                    dynamicPayment.Add("@PayMethod", payment.PayMethod);
                    dynamicPayment.Add("@Bank", payment.Bank);
                    dynamicPayment.Add("@Branch", payment.Branch);
                    dynamicPayment.Add("@ChequeNumber", payment.ChequeNumber);
                    dynamicPayment.Add("@UserId", Invoice.CreatedUserId);
                    dynamicPayment.Add("@DocumentNumber", DocumentNumber);

                    await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddJewelleryInvoicePayments]", dynamicPayment, _transaction, commandType: CommandType.StoredProcedure);
                }

                foreach (InvoiceVM advance in Invoice.Advances)
                {
                    var dynamicProduct = new DynamicParameters();
                    dynamicProduct.Add("@InvoiceId", invoice.Id);
                    dynamicProduct.Add("@AdvanceId", advance.Id);
                    dynamicProduct.Add("@Amount", advance.ApplyAmount);
                    dynamicProduct.Add("@UserId", Invoice.CreatedUserId);

                    await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddAdvancePaymentLog]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);

                }

                if (Invoice.SetOffs.Count() > 0)
                {
                    var dynamicProduct = new DynamicParameters();
                    DocumentNumber = await dbConnection.QuerySingleOrDefaultAsync<string>("[inv].[GetSetOffDocNumber]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);
                }

                foreach (InvoiceVM set in Invoice.SetOffs)
                {
                    var dynamicProduct = new DynamicParameters();
                    dynamicProduct.Add("@InvoiceId", invoice.Id);
                    dynamicProduct.Add("@ReturnId", set.Id);
                    dynamicProduct.Add("@Amount", set.ApplyAmount);
                    dynamicProduct.Add("@UserId", Invoice.CreatedUserId);
                    dynamicProduct.Add("@DocumentNumber", DocumentNumber);
                    await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddSetoffPaymentsLog]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);

                }

                {
                    var dynamicVoucher = new DynamicParameters();
                    dynamicVoucher.Add("@RefReceipt", Invoice.VoucherObj.RefReceipt);
                    dynamicVoucher.Add("@Name", Invoice.Name);
                    dynamicVoucher.Add("@Contact", Invoice.Contact);
                    dynamicVoucher.Add("@InvoiceId", invoice.Id);

                    await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[UpdateJewelleryRewards]", dynamicVoucher, _transaction, commandType: CommandType.StoredProcedure);
                }

                //if(Invoice.VoucherObj != null)
                //{

                //    {
                //        var dynamicVoucher = new DynamicParameters();
                //        dynamicVoucher.Add("@InvoiceId", Invoice.Id);
                //        dynamicVoucher.Add("@PostId", Invoice.VoucherObj.PosId);
                //        dynamicVoucher.Add("@ReceiptDateTime", Invoice.VoucherObj.ReceiptDateTime);
                //        dynamicVoucher.Add("@ReceiptNumber", Invoice.VoucherObj.ReceiptNumber);
                //        dynamicVoucher.Add("@TotalAmount", Invoice.VoucherObj.TotalAmount);
                //        dynamicVoucher.Add("@TotalReward", Invoice.VoucherObj.TotalReward);
                //        dynamicVoucher.Add("@UserId", Invoice.VoucherObj.UserId);

                //       rewards =  await dbConnection.QuerySingleOrDefaultAsync<RewardsVM>("[inv].[AddJewelleryReward]", dynamicVoucher, _transaction, commandType: CommandType.StoredProcedure);
                //    }

                //    foreach(RewardTransactionVM transaction in Invoice.VoucherObj.RewardTransactions)
                //    {
                //        var dynamicTransaction = new DynamicParameters();
                //        dynamicTransaction.Add("@RewardRef", rewards.Id);
                //        dynamicTransaction.Add("@RewardName", transaction.RewardName);
                //        dynamicTransaction.Add("@RewardValue", transaction.RewardValue);
                //        dynamicTransaction.Add("@SerialNumber", transaction.SerialNumber);
                    
                //       await dbConnection.QuerySingleOrDefaultAsync<RewardsVM>("[inv].[AddJewelleryRewardTransaction]", dynamicTransaction, _transaction, commandType: CommandType.StoredProcedure);

                //    }
                //}


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Invoice;
        }

        public async Task<InvoiceVM> AddJewelleryAdvance(InvoiceVM Advance)
        {
            InvoiceVM advance = new InvoiceVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", Advance.Name);
                dynamicParameterlist.Add("@Address", Advance.Address);
                dynamicParameterlist.Add("@Contact", Advance.Contact);
                dynamicParameterlist.Add("@Description", Advance.Description);
                dynamicParameterlist.Add("@Total", Advance.Total);
                dynamicParameterlist.Add("@Balance", Advance.Total);
                dynamicParameterlist.Add("@Cash", Advance.Cash);
                dynamicParameterlist.Add("@Cheque", Advance.Cheque);
                dynamicParameterlist.Add("@Customer", Advance.Customer);
                dynamicParameterlist.Add("@CreditCard", Advance.CreditCard);
                dynamicParameterlist.Add("@CreatedUserId", Advance.CreatedUserId);

                advance = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddJewelleryAdvanceDetails]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                foreach (CreditVM payment in Advance.Payments)
                {
                    var dynamicPayment = new DynamicParameters();
                    dynamicPayment.Add("@AdvanceId", advance.Id);
                    dynamicPayment.Add("@Amount", payment.Amount);
                    dynamicPayment.Add("@PayMethod", payment.PayMethod);
                    dynamicPayment.Add("@Bank", payment.Bank);
                    dynamicPayment.Add("@Branch", payment.Branch);
                    dynamicPayment.Add("@ChequeNumber", payment.ChequeNumber);
                    dynamicPayment.Add("@UserId", Advance.CreatedUserId);

                    await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddJewelleryAdvancePayments]", dynamicPayment, _transaction, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return advance;
        }

        public async Task<IEnumerable<InvoiceVM>> GetAllInvoices(FilterVM filter)
        {
            IEnumerable<InvoiceVM> Invoices;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", filter.pageId);
                dynamicParameterlist.Add("@Keyword", filter.keyword);
                dynamicParameterlist.Add("@SortDirection", filter.sortDirection);
                dynamicParameterlist.Add("@SortActive", filter.sortActive);
                dynamicParameterlist.Add("@Limit", filter.limit);
                dynamicParameterlist.Add("@FilterActive", filter.FilterActive);
                dynamicParameterlist.Add("@FilterValue", filter.FilterValue);
                dynamicParameterlist.Add("@From", filter.from);
                dynamicParameterlist.Add("@to", filter.to);
                Invoices = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetJewelleryInvoices]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Invoices;
        }

        public async Task<InvoiceVM> GetInvoiceById(int Id)
        {
            {
                InvoiceVM Invoice = new InvoiceVM();

                try
                {
                    //AddJewelleryInvoiceProducts
                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@InvoiceId", Id);
                    Invoice = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[GetJewelleryInvoiceById]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);
                    Invoice.Products = await dbConnection.QueryAsync<InvoiceProductVM>("[inv].[GetJewelleryInvoiceProducts]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);
                    Invoice.Payments = await dbConnection.QueryAsync<CreditVM>("[inv].[GetJewelleryInvoicePaymentsByInvoiceId]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);
                    Invoice.Advances = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetAdvancePaymentLogsByInvoiceId]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);
                    Invoice.VoucherObj = await dbConnection.QuerySingleOrDefaultAsync<RewardsVM>("[inv].[GetJewelleryRewardsByInvoiceId]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);
                    Invoice.SetOffs = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetSetOffsPaymentsLogsByInvoice]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

                    var Rewards = new DynamicParameters();
                    if (Invoice.VoucherObj != null)
                    {
                        Rewards.Add("@RewardReference", Invoice.VoucherObj.Id);
                        Invoice.VoucherObj.RewardTransactions = await dbConnection.QueryAsync<RewardTransactionVM>("[inv].[GetJewelleryRewardTransactionByRewardReference]", Rewards,_transaction ,commandType: CommandType.StoredProcedure);

                    }
                    for (int i =0; i< Invoice.Advances.Count(); i++)
                    {
                        //Invoice.Advances.ElementAt(i).AdvanceObj = await GetAdvanceDetailsById(Invoice.Advances.ElementAt(i).AdvanceId);
                        var dynamicParameterlist1 = new DynamicParameters();
                        dynamicParameterlist1.Add("@Id", Invoice.Advances.ElementAt(i).AdvanceId);
                        Invoice.Advances.ElementAt(i).AdvanceObj = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[GetAdvanceDetailsById]", dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);
                        Invoice.Advances.ElementAt(i).AdvanceObj.Payments = await dbConnection.QueryAsync<CreditVM>("[inv].[GetJewelleryAdvancePaymentsByAdvanceId]", dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);
                    }

                    {
                        var dynamicParameterlist1 = new DynamicParameters();
                        dynamicParameterlist1.Add("@Id", Invoice.Salesman);
                        Invoice.SalesmanObj = await dbConnection.QuerySingleOrDefaultAsync<CustomerJw>("[msd].[GetSalesManDetailsById]", dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);
                    }

                    for (var i = 0; i < Invoice.Products.Count(); i++)
                    {
                        JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();
                        //Jew = await GetJewelleryProductDetailsById(Invoice.Products.ElementAt(i).ProductId);

                        var dynamicPara = new DynamicParameters();
                        dynamicPara.Add("@Id", Invoice.Products.ElementAt(i).ProductId);
                        jewelleryProductVM = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[GetJewelleryProductDetailsById]", dynamicPara,_transaction, commandType: CommandType.StoredProcedure);

                        //var subCategoryId = new DynamicParameters();
                        //subCategoryId.Add("@Id", jewelleryProductVM.SubCategory);
                        //jewelleryProductVM.SubCategoryObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_design]", subCategoryId, commandType: CommandType.StoredProcedure);

                        //var categoryId = new DynamicParameters();
                        //categoryId.Add("@Id", jewelleryProductVM.Category);
                        //jewelleryProductVM.CategoryObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_item]", categoryId, commandType: CommandType.StoredProcedure);

                        //var materialId = new DynamicParameters();
                        //materialId.Add("@Id", jewelleryProductVM.Material);
                        //jewelleryProductVM.MaterialObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_material]", materialId, commandType: CommandType.StoredProcedure);

                        //var gemId = new DynamicParameters();
                        //materialId.Add("@Id", jewelleryProductVM.Gem);
                        //jewelleryProductVM.GemObj = await dbConnection.QuerySingleOrDefaultAsync<CategoryVM>("[msd].[GetJewelleryCategoryById_gem]", categoryId, commandType: CommandType.StoredProcedure);


                        //var sectionId = new DynamicParameters();
                        //sectionId.Add("@Id", jewelleryProductVM.Section);
                        //jewelleryProductVM.SectionObj = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[GetSectionDetailsById]", sectionId, commandType: CommandType.StoredProcedure);

                        //var trayId = new DynamicParameters();
                        //trayId.Add("@Id", jewelleryProductVM.Tray);
                        //jewelleryProductVM.TrayObj = await dbConnection.QuerySingleOrDefaultAsync<DropDownVM>("[msd].[GetTrayDetailsById]", trayId, commandType: CommandType.StoredProcedure);

                        Invoice.Products.ElementAt(i).ProductObj = jewelleryProductVM;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return Invoice;
            }

        }
        public async Task<IEnumerable<InvoiceVM>> GetAllAdvanceDetails(FilterVM filter)
        {
            IEnumerable<InvoiceVM> advances;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", filter.pageId);
                dynamicParameterlist.Add("@Keyword", filter.keyword);
                dynamicParameterlist.Add("@SortDirection", filter.sortDirection);
                dynamicParameterlist.Add("@SortActive", filter.sortActive);
                dynamicParameterlist.Add("@Limit", filter.limit);
                dynamicParameterlist.Add("@FilterActive", filter.FilterActive);
                dynamicParameterlist.Add("@FilterValue", filter.FilterValue);
                dynamicParameterlist.Add("@From", filter.from);
                dynamicParameterlist.Add("@to", filter.to);
                advances = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetAllAdvanceDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return advances;
        }

        public async Task<InvoiceVM> GetAdvanceDetailsById(int id)
        {
            InvoiceVM advance = new InvoiceVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                advance = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[GetAdvanceDetailsById]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                advance.Payments = await dbConnection.QueryAsync<CreditVM>("[inv].[GetJewelleryAdvancePaymentsByAdvanceId]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return advance;
        }

        public async  Task<IEnumerable<InvoiceVM>> SearchAdvanceDetails(string keyword)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Keyword", keyword);
                invoiceVM = await dbConnection.QueryAsync<InvoiceVM>("[inv].[SearchAdvanceDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
           
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceVM;
        }

        public async Task<IEnumerable<InvoiceVM>> SearchInvoiceDetails(string Keyword, int PageId)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@KeyWord", Keyword);
                dynamicParameterlist.Add("@PageId", PageId);

                invoiceVM = await dbConnection.QueryAsync<InvoiceVM>("[inv].[SearchInvoiceDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceVM;
        }

        public async Task<RewardsVM> AddJewelleryReward(RewardsVM rewardsVM)
        {
            RewardsVM rewardsVm = new RewardsVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PosId", rewardsVM.PosId);
                dynamicParameterlist.Add("@ReceiptDateTime", rewardsVM.ReceiptDateTime);
                dynamicParameterlist.Add("@ReceiptNumber", rewardsVM.ReceiptNumber);
                dynamicParameterlist.Add("@TotalAmount", rewardsVM.TotalAmount);
                dynamicParameterlist.Add("@TotalReward", rewardsVM.TotalReward);
                dynamicParameterlist.Add("@UserId", rewardsVM.UserId);
                dynamicParameterlist.Add("@RefReceipt", rewardsVM.RefReceipt);
                dynamicParameterlist.Add("@Name", rewardsVM.Name);
                dynamicParameterlist.Add("@Contact", rewardsVM.Contact);

                rewardsVm = await dbConnection.QuerySingleOrDefaultAsync<RewardsVM>("[inv].[AddJewelleryReward]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                foreach(RewardTransactionVM transaction in rewardsVM.RewardTransactions)
                {
                   var dynamicTransaction1 = new DynamicParameters();
                   dynamicTransaction1.Add("@RewardRef", rewardsVm.Id);
                   dynamicTransaction1.Add("@RewardName", transaction.RewardName);
                   dynamicTransaction1.Add("@RewardValue", transaction.RewardValue);
                   dynamicTransaction1.Add("@SerialNumber", transaction.SerialNumber);

                   await dbConnection.QuerySingleOrDefaultAsync<RewardsVM>("[inv].[AddJewelleryRewardTransaction]", dynamicTransaction1, _transaction, commandType: CommandType.StoredProcedure);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return rewardsVm;
        }

        public async Task<InvoiceVM> UpdateInvoice(InvoiceVM invoiceVM)
        {
            InvoiceVM invoiceVm = new InvoiceVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", invoiceVM.Id);
                dynamicParameterlist.Add("@Advance", invoiceVM.Advance);
                dynamicParameterlist.Add("@Cash", invoiceVM.Cash);
                dynamicParameterlist.Add("@Cheque", invoiceVM.Cheque);
                dynamicParameterlist.Add("@CreditCard", invoiceVM.CreditCard);
                dynamicParameterlist.Add("@Voucher", invoiceVM.Voucher);
                dynamicParameterlist.Add("@Gold", invoiceVM.Gold);
                dynamicParameterlist.Add("@SetOff", invoiceVM.SetOff);
                dynamicParameterlist.Add("@BalanceDue", invoiceVM.BalanceDue);
                dynamicParameterlist.Add("@LastModifiedUserId ", invoiceVM.CreatedUserId);
                dynamicParameterlist.Add("@TransNo ", invoiceVM.TransNo);

                invoiceVm = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[UpdateInvoice]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

      
                string DocumentNumber = "";

                if (invoiceVM.Payments.Count() > 0)
                {
                    var dynamicProduct = new DynamicParameters();
                    DocumentNumber = await dbConnection.QuerySingleOrDefaultAsync<string>("[inv].[GetPaymentDocNumber]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);
                }

                foreach (CreditVM payment in invoiceVM.Payments)
                {
                    if(payment.Id == 0)
                    {
                        var dynamicPayment = new DynamicParameters();
                        dynamicPayment.Add("@InvoiceId", invoiceVM.Id);
                        dynamicPayment.Add("@Amount", payment.Amount);
                        dynamicPayment.Add("@PayMethod", payment.PayMethod);
                        dynamicPayment.Add("@Bank", payment.Bank);
                        dynamicPayment.Add("@Branch", payment.Branch);
                        dynamicPayment.Add("@ChequeNumber", payment.ChequeNumber);
                        dynamicPayment.Add("@UserId", invoiceVM.CreatedUserId);
                        dynamicPayment.Add("@DocumentNumber", DocumentNumber);

                        await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddJewelleryInvoicePayments]", dynamicPayment, _transaction, commandType: CommandType.StoredProcedure);
                    }
                }

                if (invoiceVM.SetOffs.Count() > 0)
                {
                    var dynamicProduct = new DynamicParameters();
                    DocumentNumber = await dbConnection.QuerySingleOrDefaultAsync<string>("[inv].[GetSetOffDocNumber]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);
                }

                foreach (InvoiceVM set in invoiceVM.SetOffs)
                {
                    var dynamicProduct = new DynamicParameters();
                    dynamicProduct.Add("@InvoiceId", invoiceVM.Id);
                    dynamicProduct.Add("@ReturnId", set.Id);
                    dynamicProduct.Add("@Amount", set.ApplyAmount);
                    dynamicProduct.Add("@UserId", invoiceVM.CreatedUserId);
                    dynamicProduct.Add("@DocumentNumber", DocumentNumber);
                    await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddSetoffPaymentsLog]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);

                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceVm;
        }

        public async Task<InvoiceVM> UpdateInvoiceUploadInfo(Boolean state, int invoiceId)
        {
            InvoiceVM invoiceVm = new InvoiceVM();

            try
            {
               
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@invoiceID", invoiceId);
                dynamicParameterlist.Add("@State", state);
                await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[UpdateInvoiceUploadInfo]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceVm;
        }

        public async Task<IEnumerable<InvoiceVM>> JewelleryDailySummary(InvoiceVM invoiceVM)
        {
            IEnumerable<InvoiceVM> invoiceVm;
            IEnumerable<InvoiceVM> invoice;
            List<InvoiceVM> response = new List<InvoiceVM>();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Date", invoiceVM.CreatedDateTime);
                invoiceVm = await dbConnection.QueryAsync<InvoiceVM>("[inv].[JewelleryDailySummary]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
                //invoice = await dbConnection.QueryAsync<InvoiceVM>("inv.PettyCashDailySummary", dynamicParameterlist, commandType: CommandType.StoredProcedure);
           
                //foreach(InvoiceVM inv in invoiceVm)
                //{
                //    response.Add(inv);
                //}
                //for(int i = 0; i < invoice.Count(); i++)
                //{
                //    if(invoice.ElementAt(i).PayMethod == "Cash Receive")
                //    {
                //        response.Insert(0, invoice.ElementAt(i));
                //    }
                //    else
                //    {
                //        invoice.ElementAt(i).Amount = -invoice.ElementAt(i).Amount;
                //        response.Add(invoice.ElementAt(i));
                //    }
                //}

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return invoiceVm;
        }

        public async Task<IEnumerable<InvoiceVM>> GetJewelleryInvoiceUploaded()
        {
            IEnumerable<InvoiceVM> invoices;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                invoices = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetJewelleryInvoiceUploaded]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                for(int i = 0; i < invoices.Count(); i++)
                {
                    var invoice = new DynamicParameters();
                    invoice.Add("@InvoiceId", invoices.ElementAt(i).Id);
                    invoices.ElementAt(i).Products = await dbConnection.QueryAsync<InvoiceProductVM>("[inv].[GetJewelleryInvoiceProducts]", invoice, commandType: CommandType.StoredProcedure);
                    for(int j = 0; j < invoices.ElementAt(i).Products.Count(); j++)
                    {
              
                        var dynamicPara = new DynamicParameters();
                        dynamicPara.Add("@Id", invoices.ElementAt(i).Products.ElementAt(j).ProductId);
                        invoices.ElementAt(i).Products.ElementAt(j).ProductObj = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[GetJewelleryProductDetailsById]", dynamicPara, commandType: CommandType.StoredProcedure);
                    }
                }

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoices;
        }

        public async Task<IEnumerable<InvoiceVM>> GetInvoiceDetailsByDateRange(DateTime From, DateTime To)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@From", From);
                dynamicParameterlist.Add("@To", To);
                invoiceVM = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetInvoiceDetailsByDateRange]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return invoiceVM;
        }

        public async Task<IEnumerable<InvoiceVM>> GetAdvanceDetailsByDateRange(DateTime From, DateTime To)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@From", From);
                dynamicParameterlist.Add("@To", To);
                invoiceVM = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetAdvanceDetailsByDateRange]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceVM;
        }

        public async Task<InvoiceVM> InvoiceCancellation(InvoiceVM invoiceVM)
        {
            InvoiceVM invoice = new InvoiceVM();
            InvoiceVM Cancelledinvoice = new InvoiceVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@InvoiceId", invoiceVM.Id);
                Cancelledinvoice = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[CancelJewelleryInvoice]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

                invoice = await GetInvoiceById(invoiceVM.Id);
                invoice.BatchCode = Cancelledinvoice.CancellationBatchCode;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoice;
        }

        public async Task<InvoiceVM> InvoiceReturn(InvoiceVM Invoice)
        {
            InvoiceVM ReturnedInvoice = new InvoiceVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Name", Invoice.Name);
                dynamicParameterlist.Add("@InvoiceId", Invoice.Id);
                dynamicParameterlist.Add("@Address", Invoice.Address);
                dynamicParameterlist.Add("@Contact", Invoice.Contact);
                dynamicParameterlist.Add("@Total", Invoice.Total);
                dynamicParameterlist.Add("@Advance", Invoice.Advance);
                dynamicParameterlist.Add("@Cash", Invoice.Cash);
                dynamicParameterlist.Add("@Cheque", Invoice.Cheque);
                dynamicParameterlist.Add("@CreditCard", Invoice.CreditCard);
                dynamicParameterlist.Add("@Voucher", Invoice.Voucher);
                dynamicParameterlist.Add("@Gold", Invoice.Gold);
                dynamicParameterlist.Add("@BalanceDue", Invoice.Total);
                dynamicParameterlist.Add("@CreatedUserId", Invoice.CreatedUserId);
                dynamicParameterlist.Add("@Country", Invoice.Country);
                dynamicParameterlist.Add("@InvoiceDocNumber", Invoice.DocumentNumber);
                dynamicParameterlist.Add("@Customer", Invoice.Customer);
                dynamicParameterlist.Add("@Salesman", Invoice.Salesman);
                dynamicParameterlist.Add("@Remark", Invoice.Remark);

                ReturnedInvoice = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddJewelleryReturnInvoice]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

                foreach(InvoiceProductVM product in Invoice.Products)
                {
                    var dynamicProduct = new DynamicParameters();
                    dynamicProduct.Add("@InvoiceId", Invoice.Id);
                    dynamicProduct.Add("@ReturnId", ReturnedInvoice.Id);
                    dynamicProduct.Add("@productId", product.ProductId);
                    dynamicProduct.Add("@Standard", product.Standard);
                    dynamicProduct.Add("@DiamondWeight", product.DiamondWeight);
                    dynamicProduct.Add("@ItemWeight", product.ItemWeight);
                    dynamicProduct.Add("@StoneWeight", product.StoneWeight);
                    dynamicProduct.Add("@Amount", product.Amount);
                    dynamicProduct.Add("@UserId", Invoice.CreatedUserId);

                    await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[AddJewelleryInvoiceReturnProducts]", dynamicProduct, _transaction, commandType: CommandType.StoredProcedure);
                }


                //invoice = await GetInvoiceById(Invoice.Id);
                Invoice.BatchCode = ReturnedInvoice.BatchCode;
                Invoice.CreatedDateTime = ReturnedInvoice.CreatedDateTime;
                Invoice.DocumentNumber = ReturnedInvoice.DocumentNumber;
                Invoice.CreatedDateTimeUTC = ReturnedInvoice.CreatedDateTimeUTC;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Invoice;
        }

        public async Task<IEnumerable<InvoiceVM>> GetAllInvoiceReturns(FilterVM filter)
       {
            IEnumerable<InvoiceVM> Invoices;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@PageId", filter.pageId);
                dynamicParameterlist.Add("@Keyword", filter.keyword);
                dynamicParameterlist.Add("@SortDirection", filter.sortDirection);
                dynamicParameterlist.Add("@SortActive", filter.sortActive);
                dynamicParameterlist.Add("@Limit", filter.limit);
                dynamicParameterlist.Add("@FilterActive", filter.FilterActive);
                dynamicParameterlist.Add("@FilterValue", filter.FilterValue);
                dynamicParameterlist.Add("@From", filter.from);
                dynamicParameterlist.Add("@to", filter.to);
                Invoices = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetJewelleryReturnedInvoices]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Invoices;
        }

        public async Task<InvoiceVM> GetInvoiceReturnsById(int Id)
        {
            {
                InvoiceVM Invoice = new InvoiceVM();

                try
                {
                    //AddJewelleryInvoiceProducts
                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@ReturnId", Id);
                    Invoice = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[GetJewelleryInvoiceReturnsById]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
                    Invoice.Products = await dbConnection.QueryAsync<InvoiceProductVM>("[inv].[GetJewelleryInvoiceReturnsProducts]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);


                    {
                        var dynamicParameterlist1 = new DynamicParameters();
                        dynamicParameterlist1.Add("@Id", Invoice.Salesman);
                        Invoice.SalesmanObj = await dbConnection.QuerySingleOrDefaultAsync<CustomerJw>("[msd].[GetSalesManDetailsById]", dynamicParameterlist1, _transaction, commandType: CommandType.StoredProcedure);
                    }

                    for (var i = 0; i < Invoice.Products.Count(); i++)
                    {
                        JewelleryProductVM jewelleryProductVM = new JewelleryProductVM();
                        //Jew = await GetJewelleryProductDetailsById(Invoice.Products.ElementAt(i).ProductId);

                        var dynamicPara = new DynamicParameters();
                        dynamicPara.Add("@Id", Invoice.Products.ElementAt(i).ProductId);
                        jewelleryProductVM = await dbConnection.QuerySingleOrDefaultAsync<JewelleryProductVM>("[msd].[GetJewelleryProductDetailsById]", dynamicPara, _transaction, commandType: CommandType.StoredProcedure);
                        Invoice.Products.ElementAt(i).ProductObj = jewelleryProductVM;
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return Invoice;
            }

        }

        public async Task<IEnumerable<InvoiceVM>> SearchJewelleryInvoiceReturnDetails(string keyWord)
        {
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@KeyWord", keyWord);
                invoiceVM = await dbConnection.QueryAsync<InvoiceVM>("[inv].[SearchJewelleryInvoiceReturnDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceVM;
        }

        public async  Task<PettyCashVM> AddJewelleryPettyCash(PettyCashVM cash)
        {
            PettyCashVM Cash = new PettyCashVM();

            try{
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Type", cash.type);
                dynamicParameterlist.Add("@Amount", cash.Amount);
                dynamicParameterlist.Add("@Description", cash.Description);
                Cash = await dbConnection.QuerySingleOrDefaultAsync<PettyCashVM>("[inv].[AddJewelleryPettyCash]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Cash;
        }

        public async Task<PettyCashVM> UpdateJewelleryPettyCash(PettyCashVM cash)
        {
            PettyCashVM Cash = new PettyCashVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", cash.Id);
                dynamicParameterlist.Add("@Type", cash.type);
                dynamicParameterlist.Add("@Amount", cash.Amount);
                dynamicParameterlist.Add("@Description", cash.Description);
                Cash = await dbConnection.QuerySingleOrDefaultAsync<PettyCashVM>("[inv].[UpdateJewelleryPettyCash]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Cash;
        }

        public async Task<InvoiceVM> DeleteJewelleryPettyCash(int id)
        {
            InvoiceVM invoiceVM = new InvoiceVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", id);
                invoiceVM = await dbConnection.QuerySingleOrDefaultAsync<InvoiceVM>("[inv].[DeleteJewelleryPettyCash]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceVM;
        }

        public async Task<IEnumerable<InvoiceVM>> GetAllJewelleryPettyCashDetails()
        {
            IEnumerable<InvoiceVM> invoiceVM;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                invoiceVM = await dbConnection.QueryAsync<InvoiceVM>("[inv].[GetAllJewelleryPettyCashDetails]", dynamicParameterlist, commandType: CommandType.StoredProcedure);

            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return invoiceVM;
        }

        public async Task<IEnumerable<PettyCashVM>> GetJewelleryPettyCashDetailsByDate(PettyCashVM cash)
        {

            IEnumerable<PettyCashVM> pettyCashVMs;

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Date", cash.CreatedDateTime);
                pettyCashVMs = await dbConnection.QueryAsync<PettyCashVM>("[inv].[GetJewelleryPettyCashDetailsByDate]", dynamicParameterlist,_transaction, commandType: CommandType.StoredProcedure);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return pettyCashVMs;
        }

        public async Task<RefundVM> AddRefund(RefundVM Refund)
        {
            RefundVM refund = new RefundVM();

            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ReturnId", Refund.ReturnId);
                dynamicParameterlist.Add("@Remarks", Refund.Remarks);
                dynamicParameterlist.Add("@Amount", Refund.Amount);
                dynamicParameterlist.Add("@User", 1);
                refund = await dbConnection.QuerySingleOrDefaultAsync<RefundVM>("[inv].[AddRefund]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return refund;
        }

        public async Task<RefundVM> CancelRefund(RefundVM Refund)
        {
            RefundVM refund = new RefundVM();
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@ReturnId", Refund.ReturnId);
                dynamicParameterlist.Add("@Id", Refund.Id);
                dynamicParameterlist.Add("@Amount", Refund.Amount);
                dynamicParameterlist.Add("@User", Refund.CancelledUser);
                refund = await dbConnection.QuerySingleOrDefaultAsync<RefundVM>("[inv].[CancelRefund]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return refund;
        }

        public async Task<IEnumerable<RefundVM>> GetRefundsByReturnId(int Id)
        {
            IEnumerable<RefundVM> refunds;
            try
            {
                var dynamicParameterlist = new DynamicParameters();
                dynamicParameterlist.Add("@Id", Id);
                refunds = await dbConnection.QueryAsync<RefundVM>("[inv].[GetRefundsByReturnId]", dynamicParameterlist, _transaction, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return refunds;
        }
    }
}
