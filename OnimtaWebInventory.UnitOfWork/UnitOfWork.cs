using Microsoft.Extensions.Configuration;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IRepository.IJewelleryRepository;
using OnimtaWebInventory.Repository;
using OnimtaWebInventory.Repository.JewelleryRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OnimtaWebInventory.UnitOfWork
{

    public sealed class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {

      //  public IDbConnection _connection = null;
     //   public IDbTransaction _transaction = null;
        Guid _id = Guid.Empty;


        private ProductRepository _productRepository;
        private PurchaseOrderBillRepository _purchaseOrderBillRepository;
        public AdvancePaymentRepository _AdvancePaymentRepository;
        public AdvanceSearchRepository _AdvanceSearchRepository;
        public AdvanceSettingRepository _AdvanceSettingRepository;
        public ApplicationUserRepository _ApplicationUserRepository;
        public ApprovalRepository _ApprovalRepository;
        public AuditRepository _AuditRepository;
        public BranchRepository _BranchRepository;
        public BusinessPartnerRepository _BusinessPartnerRepository;
        public CancellationRepository _CancellationRepository;
        public CashierRepository _CashierRepository;
        public ChatBotRepository _ChatBotRepository;
        public CurrencyRepository _CurrencyRepository;
        public CustomerRepository _CustomerRepository;
        public DashBoardRepository _DashBoardRepository;
        public DispatchRepository _DispatchRepository;
        public DocumentTypeRepository _DocumentTypeRepository;
        public EmailRepository _EmailRepository;
        public GeneralSettingRepository _GeneralSettingRepository;
        public InvoiceRepository _InvoiceRepository;
        public LogsRepository _LogsRepository;
        public MenuRepository _MenuRepository;
        public NotificationRepository _NotificationRepository;
        public OrganizationSettingRepository _OrganizationSettingRepository;
        public PageSettingRepository _PageSettingRepository;
        public PaymentRepository _PaymentRepository;
        public PrintHistoryDetailsRepository _PrintHistoryDetailsRepository;
        public ProductSettingRepository _ProductSettingRepository;
        public PurchaseOrderBillRepository _PurchaseOrderBillRepository;
        public PurchaseOrderInteligenceRepository _PurchaseOrderInteligenceRepository;
        public PurchaseOrderRecieveRepository _PurchaseOrderRecieveRepository;
        public PurchaseOrderReportRepository _PurchaseOrderReportRepository;
        public PurchaseOrderRequestRepository _PurchaseOrderRequestRepository;
        public PurchaseOrderReturnRepository _PurchaseOrderReturnRepository;
        public QuotationRepository _QuotationRepository;
        public ReportRepository _ReportRepository;
        public RequisitionRepository _RequisitionRepository;
        public SalesInvoiceRepository _SalesInvoiceRepository;
        public SalesRepository _SalesRepository;
        public SalesReturnRepository _SalesReturnRepository;
        public SeasonRepository _SeasonRepository;
        public StockAdjusmentRepository _StockAdjusmentRepository;
        public StockPurchaseOrderRepository _StockPurchaseOrderRepository;
        public StockRepository _StockRepository;
        public StockTransferRepository _StockTransferRepository;
        public TaxRepository _TaxRepository;
        public UserRoleRepository _UserRoleRepository;
        public IndustryAttributeRepository _IndustryAttributeRepository;
        public JewelleryProductRepository _JewelleryProductRepository;
        public DropDownRepository _DropDownRepository;
        public CategoryRepository _CategoryRepository;
        public JewelleryInvoiceRepository _JewelleryInvoiceRepository;
        public CustomerJWRepository _CustomerJWRepository;

        public UnitOfWork(IConfiguration configuration)
        {
            _id = Guid.NewGuid();
            _connection = new SqlConnection(configuration.GetConnectionString("OnimtaDB"));
            try
            {
                _connection.Open();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

      
        public IProductRepository ProductRepository
        {
            get
            {
                if(_productRepository!=null)
                {return _productRepository;}else{
                    _productRepository = new ProductRepository();
                    _productRepository._transaction = _transaction;
                    _productRepository.dbConnection = _connection;
                    return _productRepository;
                }
            }
        }

        public IPurchaseOrderRecieveRepository PurchaseOrderRecieveRepository
        {
            get
            {
                if (_PurchaseOrderRecieveRepository != null)
                { return _PurchaseOrderRecieveRepository; }
                else
                {
                    _PurchaseOrderRecieveRepository = new PurchaseOrderRecieveRepository();
                    _PurchaseOrderRecieveRepository._transaction = _transaction;
                    _PurchaseOrderRecieveRepository.dbConnection = _connection;

                    return _PurchaseOrderRecieveRepository;
                }
            }

        }

        public IPurchaseOrderBillRepository PurchaseOrderBillRepository 
        {
            get
            {
                if (_purchaseOrderBillRepository != null)
                { return _purchaseOrderBillRepository; }
                else
                {
                    _purchaseOrderBillRepository = new PurchaseOrderBillRepository();
                    _purchaseOrderBillRepository._transaction = _transaction;
                    _purchaseOrderBillRepository.dbConnection = _connection;

                    return _purchaseOrderBillRepository;
                }
            }

        }

        public IAdvancePaymentRepository AdvancePaymentRepository 
        {
            get
            {
                if (_AdvancePaymentRepository != null)
                { return _AdvancePaymentRepository; }
                else
                {
                    _AdvancePaymentRepository = new AdvancePaymentRepository();
                    _AdvancePaymentRepository._transaction = _transaction;
                    _AdvancePaymentRepository.dbConnection = _connection;

                    return _AdvancePaymentRepository;
                }
            }

        }

        public IAdvanceSearchRepository AdvanceSearchRepository 
        {
            get
            {
                if (_AdvanceSearchRepository != null)
                { return _AdvanceSearchRepository; }
                else
                {
                    _AdvanceSearchRepository = new AdvanceSearchRepository();
                    _AdvanceSearchRepository._transaction = _transaction;
                    _AdvanceSearchRepository.dbConnection = _connection;

                    return _AdvanceSearchRepository;
                }
            }

        }

        public IAdavanceSettingRepository AdavanceSettingRepository 
        {
            get
            {
                if (_AdvanceSettingRepository != null)
                { return _AdvanceSettingRepository; }
                else
                {
                    _AdvanceSettingRepository = new AdvanceSettingRepository();
                    _AdvanceSettingRepository._transaction = _transaction;
                    _AdvanceSettingRepository.dbConnection = _connection;

                    return _AdvanceSettingRepository;
                }
            }

        }

        public IApplicationUserRepository ApplicationUserRepository 
        {
            get
            {
                if (_ApplicationUserRepository != null)
                { return _ApplicationUserRepository; }
                else
                {
                    _ApplicationUserRepository = new ApplicationUserRepository();
                    _ApplicationUserRepository._transaction = _transaction;
                    _ApplicationUserRepository.dbConnection = _connection;

                    return _ApplicationUserRepository;
                }
            }

        }

        public IApprovalRepository ApprovalRepository 
        {
            get
            {
                if (_ApprovalRepository != null)
                { return _ApprovalRepository; }
                else
                {
                    _ApprovalRepository = new ApprovalRepository();
                    _ApprovalRepository._transaction = _transaction;
                    _ApprovalRepository.dbConnection = _connection;

                    return _ApprovalRepository;
                }
            }

        }

        public IAuditRepository AuditRepository 
        {
            get
            {
                if (_AuditRepository != null)
                { return _AuditRepository; }
                else
                {
                    _AuditRepository = new AuditRepository();
                    _AuditRepository._transaction = _transaction;
                    _AuditRepository.dbConnection = _connection;

                    return _AuditRepository;
                }
            }

        }

        public IBranchRepository BranchRepository 
        {
            get
            {
                if (_BranchRepository != null)
                { return _BranchRepository; }
                else
                {
                    _BranchRepository = new BranchRepository();
                    _BranchRepository._transaction = _transaction;
                    _BranchRepository.dbConnection = _connection;

                    return _BranchRepository;
                }
            }

        }

        public IBusinessPartnerRepository BusinessPartnerRepository 
        {
            get
            {
                if (_BusinessPartnerRepository != null)
                { return _BusinessPartnerRepository; }
                else
                {
                    _BusinessPartnerRepository = new BusinessPartnerRepository();
                    _BusinessPartnerRepository._transaction = _transaction;
                    _BusinessPartnerRepository.dbConnection = _connection;

                    return _BusinessPartnerRepository;
                }
            }

        }

        public ICancellationRepository CancellationRepository 
        {
            get
            {
                if (_CancellationRepository != null)
                { return _CancellationRepository; }
                else
                {
                    _CancellationRepository = new CancellationRepository();
                    _CancellationRepository._transaction = _transaction;
                    _CancellationRepository.dbConnection = _connection;

                    return _CancellationRepository;
                }
            }

        }

        public ICashierRepository CashierRepository 
        {
            get
            {
                if (_CashierRepository != null)
                { return _CashierRepository; }
                else
                {
                    _CashierRepository = new CashierRepository();
                    _CashierRepository._transaction = _transaction;
                    _CashierRepository.dbConnection = _connection;

                    return _CashierRepository;
                }
            }

        }

        public IChatBotRepository ChatBotRepository 
        {
            get
            {
                if (_ChatBotRepository != null)
                { return _ChatBotRepository; }
                else
                {
                    _ChatBotRepository = new ChatBotRepository();
                    _ChatBotRepository._transaction = _transaction;
                    _ChatBotRepository.dbConnection = _connection;

                    return _ChatBotRepository;
                }
            }

        }

        public ICurrencyRepository CurrencyRepository 
        {
            get
            {
                if (_CurrencyRepository != null)
                { return _CurrencyRepository; }
                else
                {
                    _CurrencyRepository = new CurrencyRepository();
                    _CurrencyRepository._transaction = _transaction;
                    _CurrencyRepository.dbConnection = _connection;

                    return _CurrencyRepository;
                }
            }

        }

        public ICustomerRepository CustomerRepository 
        {
            get
            {
                if (_CustomerRepository != null)
                { return _CustomerRepository; }
                else
                {
                    _CustomerRepository = new CustomerRepository();
                    _CustomerRepository._transaction = _transaction;
                    _CustomerRepository.dbConnection = _connection;

                    return _CustomerRepository;
                }
            }

        }

        public IDashBoardRepository DashBoardRepository 
        {
            get
            {
                if (_DashBoardRepository != null)
                { return _DashBoardRepository; }
                else
                {
                    _DashBoardRepository = new DashBoardRepository();
                    _DashBoardRepository._transaction = _transaction;
                    _DashBoardRepository.dbConnection = _connection;

                    return _DashBoardRepository;
                }
            }

        }

        public IDispatchRepository DispatchRepository 
        {
            get
            {
                if (_DispatchRepository != null)
                { return _DispatchRepository; }
                else
                {
                    _DispatchRepository = new DispatchRepository();
                    _DispatchRepository._transaction = _transaction;
                    _DispatchRepository.dbConnection = _connection;

                    return _DispatchRepository;
                }
            }

        }


        public IDocumentTypeRepository DocumentTypeRepository 
        {
            get
            {
                if (_DocumentTypeRepository != null)
                { return _DocumentTypeRepository; }
                else
                {
                    _DocumentTypeRepository = new DocumentTypeRepository();
                    _DocumentTypeRepository._transaction = _transaction;
                    _DocumentTypeRepository.dbConnection = _connection;

                    return _DocumentTypeRepository;
                }
            }

        }

        public EmailRepository EmailRepository 
        {
            get
            {
                if (_EmailRepository != null)
                { return _EmailRepository; }
                else
                {
                    

                    return _EmailRepository;
                }
            }

        }

        public IGeneralSettingRepository GeneralSettingRepository 
        {
            get
            {
                if (_GeneralSettingRepository != null)
                { return _GeneralSettingRepository; }
                else
                {
                    _GeneralSettingRepository = new GeneralSettingRepository();
                    _GeneralSettingRepository._transaction = _transaction;
                    _GeneralSettingRepository.dbConnection = _connection;

                    return _GeneralSettingRepository;
                }
            }

        }

        public IInvoiceRepository InvoiceRepository 
        {
            get
            {
                if (_InvoiceRepository != null)
                { return _InvoiceRepository; }
                else
                {
                    _InvoiceRepository = new InvoiceRepository();
                    _InvoiceRepository._transaction = _transaction;
                    _InvoiceRepository.dbConnection = _connection;

                    return _InvoiceRepository;
                }
            }

        }

        public ILogsRepository LogsRepository 
        {
            get
            {
                if (_LogsRepository != null)
                { return _LogsRepository; }
                else
                {
                    _LogsRepository = new LogsRepository();
                    _LogsRepository._transaction = _transaction;
                    _LogsRepository.dbConnection = _connection;

                    return _LogsRepository;
                }
            }

        }

        public IMenuRepository MenuRepository 
        {
            get
            {
                if (_MenuRepository != null)
                { return _MenuRepository; }
                else
                {
                    _MenuRepository = new MenuRepository();
                    _MenuRepository._transaction = _transaction;
                    _MenuRepository.dbConnection = _connection;

                    return _MenuRepository;
                }
            }

        }

        public INotificationRepository NotificationRepository 
        {
            get
            {
                if (_NotificationRepository != null)
                { return _NotificationRepository; }
                else
                {
                    _NotificationRepository = new NotificationRepository();
                    _NotificationRepository._transaction = _transaction;
                    _NotificationRepository.dbConnection = _connection;

                    return _NotificationRepository;
                }
            }

        }

        public IOrganizationSettingRepository OrganizationSettingRepository 
        {
            get
            {
                if (_OrganizationSettingRepository != null)
                { return _OrganizationSettingRepository; }
                else
                {
                    _OrganizationSettingRepository = new OrganizationSettingRepository();
                    _OrganizationSettingRepository._transaction = _transaction;
                    _OrganizationSettingRepository.dbConnection = _connection;

                    return _OrganizationSettingRepository;
                }
            }

        }

        public IPageSettingRepository PageSettingRepository 
        {
            get
            {
                if (_PageSettingRepository != null)
                { return _PageSettingRepository; }
                else
                {
                    _PageSettingRepository = new PageSettingRepository();
                    _PageSettingRepository._transaction = _transaction;
                    _PageSettingRepository.dbConnection = _connection;

                    return _PageSettingRepository;
                }
            }

        }
        public IPaymentRepository PaymentRepository 
        {
            get
            {
                if (_PaymentRepository != null)
                { return _PaymentRepository; }
                else
                {
                    _PaymentRepository = new PaymentRepository();
                    _PaymentRepository._transaction = _transaction;
                    _PaymentRepository.dbConnection = _connection;

                    return _PaymentRepository;
                }
            }

        }
        public IPrintHistoryDetailsRepository PrintHistoryDetailsRepository 
        {
            get
            {
                if (_PrintHistoryDetailsRepository != null)
                { return _PrintHistoryDetailsRepository; }
                else
                {
                    _PrintHistoryDetailsRepository = new PrintHistoryDetailsRepository();
                    _PrintHistoryDetailsRepository._transaction = _transaction;
                    _PrintHistoryDetailsRepository.dbConnection = _connection;

                    return _PrintHistoryDetailsRepository;
                }
            }

        }
        //public IProductRepository ProductRepository 
        //{
        //    get
        //    {
        //        if (_productRepository != null)
        //        { return _productRepository; }
        //        else
        //        {
        //            //_productRepository = new ProductRepository();
        //            //_productRepository._transaction = _transaction;
        //            //_productRepository.dbConnection = _connection;

        //            return _productRepository;
        //        }
        //    }

        //}

        public IProductSettingRepository ProductSettingRepository 
        {
            get
            {
                if (_ProductSettingRepository != null)
                { return _ProductSettingRepository; }
                else
                {
                    _ProductSettingRepository = new ProductSettingRepository();
                    _ProductSettingRepository._transaction = _transaction;
                    _ProductSettingRepository.dbConnection = _connection;

                    return _ProductSettingRepository;
                }
            }

        }

      

        public IPurchaseOrderInteligenceRepository PurchaseOrderInteligenceRepository 
        {
            get
            {
                if (_PurchaseOrderInteligenceRepository != null)
                { return _PurchaseOrderInteligenceRepository; }
                else
                {
                    _PurchaseOrderInteligenceRepository = new PurchaseOrderInteligenceRepository();
                    _PurchaseOrderInteligenceRepository._transaction = _transaction;
                    _PurchaseOrderInteligenceRepository.dbConnection = _connection;

                    return _PurchaseOrderInteligenceRepository;
                }
            }

        }

        public IPurchaseOrderReportRepository PurchaseOrderReportRepository 
        {
            get
            {
                if (_PurchaseOrderReportRepository  != null)
                { return _PurchaseOrderReportRepository; }
                else
                {
                    _PurchaseOrderReportRepository = new PurchaseOrderReportRepository();
                    _PurchaseOrderReportRepository._transaction = _transaction;
                    _PurchaseOrderReportRepository.dbConnection = _connection;

                    return _PurchaseOrderReportRepository;
                }
            }

        }

        public IPurchaseOrderRequestRepository PurchaseOrderRequestRepository 
        {
            get
            {
                if (_PurchaseOrderRequestRepository != null)
                { return _PurchaseOrderRequestRepository; }
                else
                {
                    _PurchaseOrderRequestRepository = new PurchaseOrderRequestRepository();
                    _PurchaseOrderRequestRepository._transaction = _transaction;
                    _PurchaseOrderRequestRepository.dbConnection = _connection;

                    return _PurchaseOrderRequestRepository;
                }
            }

        }

        public IPurchaseOrderReturnRepository PurchaseOrderReturnRepository 
        {
            get
            {
                if (_PurchaseOrderReturnRepository != null)
                { return _PurchaseOrderReturnRepository; }
                else
                {
                    _PurchaseOrderReturnRepository = new PurchaseOrderReturnRepository();
                    _PurchaseOrderReturnRepository._transaction = _transaction;
                    _PurchaseOrderReturnRepository.dbConnection = _connection;

                    return _PurchaseOrderReturnRepository;
                }
            }

        }

        public IQuotationRepository QuotationRepository 
        {
            get
            {
                if (_QuotationRepository != null)
                { return _QuotationRepository; }
                else
                {
                    _QuotationRepository = new QuotationRepository();
                    _QuotationRepository._transaction = _transaction;
                    _QuotationRepository.dbConnection = _connection;

                    return _QuotationRepository;
                }
            }

        }
        public IReportRepository ReportRepository 
        {
            get
            {
                if (_ReportRepository != null)
                { return _ReportRepository; }
                else
                {
                    _ReportRepository = new ReportRepository();
                    _ReportRepository._transaction = _transaction;
                    _ReportRepository.dbConnection = _connection;

                    return _ReportRepository;
                }
            }

        }
        public IRequisitionRepository RequisitionRepository 
        {
            get
            {
                if (_RequisitionRepository != null)
                { return _RequisitionRepository; }
                else
                {
                    _RequisitionRepository = new RequisitionRepository();
                    _RequisitionRepository._transaction = _transaction;
                    _RequisitionRepository.dbConnection = _connection;

                    return _RequisitionRepository;
                }
            }

        }

        public ISalesInvoiceRepository SalesInvoiceRepository 
        {
            get
            {
                if (_SalesInvoiceRepository != null)
                { return _SalesInvoiceRepository; }
                else
                {
                    _SalesInvoiceRepository = new SalesInvoiceRepository();
                    _SalesInvoiceRepository._transaction = _transaction;
                    _SalesInvoiceRepository.dbConnection = _connection;

                    return _SalesInvoiceRepository;
                }
            }

        }

        public ISalesRepository SalesRepository 
        {
            get
            {
                if (_SalesRepository != null)
                { return _SalesRepository; }
                else
                {
                    _SalesRepository = new SalesRepository();
                    _SalesRepository._transaction = _transaction;
                    _SalesRepository.dbConnection = _connection;

                    return _SalesRepository;
                }
            }

        }

        public ISalesReturnRepository SalesReturnRepository 
        {
            get
            {
                if (_SalesReturnRepository != null)
                { return _SalesReturnRepository; }
                else
                {
                    _SalesReturnRepository = new SalesReturnRepository();
                    _SalesReturnRepository._transaction = _transaction;
                    _SalesReturnRepository.dbConnection = _connection;

                    return _SalesReturnRepository;
                }
            }

        }

        public ISeasonRepository SeasonRepository 
        {
            get
            {
                if (_SeasonRepository != null)
                { return _SeasonRepository; }
                else
                {
                    _SeasonRepository = new SeasonRepository();
                    _SeasonRepository._transaction = _transaction;
                    _SeasonRepository.dbConnection = _connection;

                    return _SeasonRepository;
                }
            }

        }

        public IStockAdjusmentRepository StockAdjusmentRepository 
        {
            get
            {
                if (_StockAdjusmentRepository != null)
                { return _StockAdjusmentRepository; }
                else
                {
                    _StockAdjusmentRepository = new StockAdjusmentRepository();
                    _StockAdjusmentRepository._transaction = _transaction;
                    _StockAdjusmentRepository.dbConnection = _connection;

                    return _StockAdjusmentRepository;
                }
            }

        }

        public IPurchaseOrderRepository PurchaseOrderRepository 
        {
            get
            {
                if (_StockPurchaseOrderRepository != null)
                { return _StockPurchaseOrderRepository; }
                else
                {
                    _StockPurchaseOrderRepository = new StockPurchaseOrderRepository();
                    _StockPurchaseOrderRepository._transaction = _transaction;
                    _StockPurchaseOrderRepository.dbConnection = _connection;

                    return _StockPurchaseOrderRepository;
                }
            }

        }

        public IStockRepository StockRepository 
        {
            get
            {
                if (_StockRepository != null)
                { return _StockRepository; }
                else
                {
                    _StockRepository = new StockRepository();
                    _StockRepository._transaction = _transaction;
                    _StockRepository.dbConnection = _connection;

                    return _StockRepository;
                }
            }

        }
        public IStockTransferRepository StockTransferRepository 
        {
            get
            {
                if (_StockTransferRepository != null)
                { return _StockTransferRepository; }
                else
                {
                    _StockTransferRepository = new StockTransferRepository();
                    _StockTransferRepository._transaction = _transaction;
                    _StockTransferRepository.dbConnection = _connection;

                    return _StockTransferRepository;
                }
            }

        }
        public ITaxRepository TaxRepository 
        {
            get
            {
                if (_TaxRepository != null)
                { return _TaxRepository; }
                else
                {
                    _TaxRepository = new TaxRepository();
                    _TaxRepository._transaction = _transaction;
                    _TaxRepository.dbConnection = _connection;

                    return _TaxRepository;
                }
            }

        }

        public IUserRoleRepository UserRoleRepository 
        {
            get
            {
                if (_UserRoleRepository != null)
                { return _UserRoleRepository; }
                else
                {
                    _UserRoleRepository = new UserRoleRepository();
                    _UserRoleRepository._transaction = _transaction;
                    _UserRoleRepository.dbConnection = _connection;

                    return _UserRoleRepository;
                }
            }

        }

        public IIndustryAttributeRepository IndustryAttributeRepository 
        {
            get
            {
                if (_IndustryAttributeRepository != null)
                { return _IndustryAttributeRepository; }
                else
                {
                    _IndustryAttributeRepository = new IndustryAttributeRepository();
                    _IndustryAttributeRepository._transaction = _transaction;
                    _IndustryAttributeRepository.dbConnection = _connection;

                    return _IndustryAttributeRepository;
                }
            }

        }


        public IJewelleryProductRepository JewelleryProductRepository
        {
            get
            {
                if(_JewelleryProductRepository != null)
                {
                    return _JewelleryProductRepository;
                }
                else
                {
                    _JewelleryProductRepository = new JewelleryProductRepository();
                    _JewelleryProductRepository._transaction = _transaction;
                    _JewelleryProductRepository.dbConnection = _connection;

                    return _JewelleryProductRepository;
                }
            }
        }

        public IDropDownRepository DropDownRepository
        {
            get
            {
                if(_DropDownRepository != null)
                {
                    return _DropDownRepository;
                }
                else
                {
                    _DropDownRepository = new DropDownRepository();
                    _DropDownRepository._transaction = _transaction;
                    _DropDownRepository.dbConnection = _connection;

                    return _DropDownRepository;
                }
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                if(_CategoryRepository != null)
                {
                    return _CategoryRepository;
                }
                else
                {
                    _CategoryRepository = new CategoryRepository();
                    _CategoryRepository._transaction = _transaction;
                    _CategoryRepository.dbConnection = _connection;

                    return _CategoryRepository;
                }
            }
        }


        public IJewelleryInvoiceRepository JewelleryInvoiceRepository
        {
            get
            {
                if (_JewelleryInvoiceRepository != null)
                {
                    return _JewelleryInvoiceRepository;
                }
                else
                {
                    _JewelleryInvoiceRepository = new JewelleryInvoiceRepository();
                    _JewelleryInvoiceRepository._transaction = _transaction;
                    _JewelleryInvoiceRepository.dbConnection = _connection;

                    return _JewelleryInvoiceRepository;
                }
            }
        }

        public ICustomerJWRepository CustomerJWRepository
        {
            get
            {
                if(_CustomerJWRepository != null)
                {
                    return _CustomerJWRepository;
                }else
                {
                    _CustomerJWRepository = new CustomerJWRepository();
                    _CustomerJWRepository._transaction = _transaction;
                    _CustomerJWRepository.dbConnection = _connection;

                    return _CustomerJWRepository;
                }
            }
        }
    }
    

}
