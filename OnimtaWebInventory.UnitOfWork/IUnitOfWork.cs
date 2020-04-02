using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IRepository.IJewelleryRepository;
//using OnimtaWebInventory.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OnimtaWebInventory.UnitOfWork
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
    

        IProductRepository ProductRepository { get; }

        IPaymentRepository PaymentRepository { get; }

        IPurchaseOrderRecieveRepository PurchaseOrderRecieveRepository { get; }

        IPurchaseOrderBillRepository PurchaseOrderBillRepository { get; }

        IAdvancePaymentRepository AdvancePaymentRepository { get; }

        IAdvanceSearchRepository AdvanceSearchRepository { get; }

        IAdavanceSettingRepository AdavanceSettingRepository { get; }

        IApplicationUserRepository ApplicationUserRepository { get; }

        IApprovalRepository ApprovalRepository { get; }

        IAuditRepository AuditRepository { get; }

        IBranchRepository BranchRepository { get; }
        IBusinessPartnerRepository BusinessPartnerRepository { get; }

        ICancellationRepository CancellationRepository { get; }

        ICashierRepository CashierRepository { get; }

        IChatBotRepository ChatBotRepository { get; }   
        ICurrencyRepository CurrencyRepository { get; }
        ICustomerRepository CustomerRepository { get; }

        IDashBoardRepository DashBoardRepository { get; }

        IDispatchRepository DispatchRepository { get; }

        IDocumentTypeRepository DocumentTypeRepository { get; }


        IGeneralSettingRepository GeneralSettingRepository { get; }

        IInvoiceRepository InvoiceRepository { get; }

        ILogsRepository LogsRepository { get; }

        IMenuRepository MenuRepository { get; }

        INotificationRepository NotificationRepository { get; }

        IOrganizationSettingRepository OrganizationSettingRepository { get; }


        IPrintHistoryDetailsRepository PrintHistoryDetailsRepository { get; }

        IProductSettingRepository ProductSettingRepository { get; }

        IPurchaseOrderInteligenceRepository PurchaseOrderInteligenceRepository { get; }

        IPurchaseOrderReportRepository PurchaseOrderReportRepository { get; }

        IPurchaseOrderRequestRepository PurchaseOrderRequestRepository { get; }

        IPurchaseOrderReturnRepository PurchaseOrderReturnRepository { get; }

        IQuotationRepository QuotationRepository { get; }

        IReportRepository ReportRepository { get; }

        IRequisitionRepository RequisitionRepository { get; }

        ISalesInvoiceRepository SalesInvoiceRepository { get; }

        ISalesRepository SalesRepository { get; }

        ISalesReturnRepository SalesReturnRepository { get; }

        ISeasonRepository SeasonRepository { get; }

        IStockAdjusmentRepository StockAdjusmentRepository { get; }

        IPurchaseOrderRepository PurchaseOrderRepository { get; }

        IStockRepository StockRepository { get; }

        IStockTransferRepository StockTransferRepository { get; }

        ITaxRepository TaxRepository { get; }

        IUserRoleRepository UserRoleRepository { get; }

        IPageSettingRepository PageSettingRepository { get; }

        IIndustryAttributeRepository IndustryAttributeRepository  { get; }

        IJewelleryProductRepository JewelleryProductRepository { get; }

        IDropDownRepository DropDownRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IJewelleryInvoiceRepository JewelleryInvoiceRepository { get; }

        ICustomerJWRepository CustomerJWRepository { get; }
    }
}
