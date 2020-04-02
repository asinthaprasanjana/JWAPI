using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBConnect;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OnimtaWebApi.Authorize;
using OnimtaWebApi.ExceptionHandler;
using OnimtaWebInventory.Core.IRepository;
using OnimtaWebInventory.Core.IRepository.IJewelleryRepository;
using OnimtaWebInventory.Core.IServices;
using OnimtaWebInventory.Core.IServices.IJewelleryService;
using OnimtaWebInventory.Repository;
using OnimtaWebInventory.Repository.JewelleryRepository;
using OnimtaWebInventory.Services;
using OnimtaWebInventory.Services.JewelleryServices;
using OnimtaWebInventory.UnitOfWork;
using Serilog.Core;
using Swashbuckle.AspNetCore.Swagger;

namespace OnimtaWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region Dependancy Injection

            var connectionString = Configuration.GetConnectionString("OnimtaDB");

            services.AddTransient<IDbConnection>((sp) =>
            new SqlConnection(this.Configuration.GetConnectionString("OnimtaDB"))
            );

            //  services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IDBContext, DBContext>();
            

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDisposable, UnitOfWork>();



            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IStockServices, StockServices>();

            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IUserRoleServices, UserRoleServices>();

            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IReportServices, ReportServices>();

            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerServices, CustomerServices>();

            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<INotificationServices, NotificationServices>();

            services.AddTransient<IApplicationUserRepository, ApplicationUserRepository>();
            services.AddTransient<IApplicationUserServices, ApplicationUserServices>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductServices, ProductServices>();

            services.AddTransient<ITaxRepository, TaxRepository>();
            services.AddTransient<ITaxServices, TaxServices>();

            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IMenuServices, MenuServices>();

            services.AddTransient<IApprovalRepository, ApprovalRepository>();
            services.AddTransient<IApprovalServices, ApprovalServices>();

            services.AddTransient<IOrganizationSettingRepository, OrganizationSettingRepository>();
            services.AddTransient<IOrganizationSettingServices, OrganizationSettingServices>();

            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IBranchServices, BranchServices>();

            services.AddTransient<IBusinessPartnerRepository, BusinessPartnerRepository>();
            services.AddTransient<IBusinessPartnerServices, BusinessPartnerServices>();

            services.AddTransient<IStockAdjusmentRepository, StockAdjusmentRepository>();
            services.AddTransient<IStockAdjusmentServices, StockAdjusmentServices>();

            services.AddTransient<IPurchaseOrderRepository, StockPurchaseOrderRepository>();
            services.AddTransient<IPurchaseOrderServices, StockPurchaseOrderServices>();

            services.AddTransient<IStockTransferRepository, StockTransferRepository>();
            services.AddTransient<IStockTransferServices, StockTransferServices>();

            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ICurrencyServices, CurrencyServices>();

            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<ISeasonServices, SeasonServices>();

            services.AddTransient<ISalesReturnRepository, SalesReturnRepository>();
            services.AddTransient<ISalesReturnServices, SalesReturnServices>();

            services.AddTransient<IPurchaseOrderReportRepository, PurchaseOrderReportRepository>();
            services.AddTransient<IPurchaseOrderReportServices, PurchaseOrderReportServices>();

            services.AddTransient<IPurchaseOrderRequestRepository, PurchaseOrderRequestRepository>();
            services.AddTransient<IPurchaseOrderRequestServices, PurchaseOrderRequestServices>();
            
            services.AddTransient<IPurchaseOrderBillRepository, PurchaseOrderBillRepository>();
            services.AddTransient<IPurchaseOrderBillServices, PurchaseOrderBillServices>();

            services.AddTransient<IPurchaseOrderRecieveRepository, PurchaseOrderRecieveRepository>();
            services.AddTransient<IPurchaseOrderRecieveServices, PurchaseOrderRecieveServices>();

            services.AddTransient<ISalesRepository, SalesRepository>();
            services.AddTransient<ISalesServices, SalesServices>();

            services.AddTransient<IPurchaseOrderReturnRepository, PurchaseOrderReturnRepository>();
            services.AddTransient<IPurchaseOrderReturnServices, PurchaseOrderReturnServices>();

            services.AddTransient<IRequisitionRepository, RequisitionRepository>();
            services.AddTransient<IRequisitionServices, RequisitionServices>();

            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IEmailServices, EmailServices>();

            services.AddTransient<IGeneralSettingRepository, GeneralSettingRepository>();
            services.AddTransient<IGeneralSettingServices, GeneralSettingServices>();

            services.AddTransient<IChatBotRepository, ChatBotRepository>();
            services.AddTransient<IChatBotServices, ChatBotServices>();

            services.AddTransient<IAdvancePaymentRepository, AdvancePaymentRepository>();
            services.AddTransient<IAdvancePaymentServices, AdvancePaymentServices>();

            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentServices, PaymentServices>();

            services.AddTransient<IPurchaseOrderInteligenceRepository, PurchaseOrderInteligenceRepository>();
            services.AddTransient<IPurchaseOrderInteligenceServices, PurchaseOrderInteligenceServices>();

            services.AddTransient<ICashierRepository, CashierRepository>();
            services.AddTransient<ICashierServices, CashierServices>();

            services.AddTransient<IPageSettingRepository, PageSettingRepository>();
            services.AddTransient<IPageSettingServices, PageSettingServices>();

            services.AddTransient<IAdvanceSearchRepository, AdvanceSearchRepository>();
            services.AddTransient<IAdvanceSearchServices, AdvanceSearchServices>();

            services.AddTransient<IQuotationRepository, QuotationRepository>();
            services.AddTransient<IQuotationServices, QuotationServices>();

            services.AddTransient<IInvoiceRepository, InvoiceRepository>();
            services.AddTransient<IInvoiceServices, InvoiceServices>();

            services.AddTransient<ICancellationRepository, CancellationRepository>();
            services.AddTransient<ICancellationServices, CancellationServices>();

            services.AddTransient<IProductSettingRepository, ProductSettingRepository>();
            services.AddTransient<IProductSettingServices, ProductSettingServices>();

            services.AddTransient<ISalesInvoiceRepository, SalesInvoiceRepository>();
            services.AddTransient<ISalesInvoiceServices, SalesInvoiceServices>();

            services.AddTransient<IDashBoardRepository, DashBoardRepository>();
            services.AddTransient<IDashBoardServices, DashBoardServices>();

            services.AddTransient<IDocumentTypeServices, DocumentTypeServices>();
            services.AddTransient<IDocumentTypeRepository, DocumentTypeRepository>();

            services.AddTransient<IDispatchRepository, DispatchRepository>();
            services.AddTransient<IDispatchServices, DispatchServices>();

            services.AddTransient<IAdavanceSettingRepository, AdvanceSettingRepository>();
            services.AddTransient<IAdvanceSettingServices, AdvanceSettingServices>();

            services.AddTransient<IAuditRepository, AuditRepository>();
            services.AddTransient<IAuditServices, AuditServices>();

            services.AddTransient<ILogsRepository, LogsRepository>();
            services.AddTransient<ILogsServices, LogsServices>();

            services.AddTransient<IPrintHistoryDetailsRepository, PrintHistoryDetailsRepository>();
            services.AddTransient<IPrintHistoryDetailsServices, PrintHistoryDetailsServices>();

            services.AddTransient<IIndustryAttributeRepository, IndustryAttributeRepository>();
            services.AddTransient<IIndustryAttributeServices, IndustryAttributeServices>();

            services.AddTransient<IJewelleryProductRepository, JewelleryProductRepository>();
            services.AddTransient<IJewelleryProductServices, JewelleryProductServices>();

            services.AddTransient<IDropDownRepository, DropDownRepository>();
            services.AddTransient<IDropDownServices, DropDownServices>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryServices, CategoryServices>();

            services.AddTransient<IJewelleryInvoiceRepository, JewelleryInvoiceRepository>();
            services.AddTransient<IJewelleryInvoiceServices, JewelleryInvoiceServices>();

            services.AddTransient<ICustomerJWRepository, CustomerJWRepository>();
            services.AddTransient<ICustomerJWServices, CustomerJWServices>();

            #endregion Dependancy Injection

            #region CorsPolicy
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>{
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
               .WithOrigins("http://192.168.1.60:4213", "http://192.168.1.60:4210", "http://localhost:4200", "http://onimtaweb:4210", "http://onimtait.dyndns.info:4210", "http://inventory.onimtaitsl.com");
            }));
            #endregion CorsPolicy

            #region Authentecation
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = false,

                    ValidIssuer = "Onimta-IT",
                    ValidAudience = "http://192.168.163.39:4210",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@OnimtaIt"))
                };
            });

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy();
            //});

            #endregion Authentecation

            services.DatabaseConfiguration(Configuration);

            services.AddSingleton<IConfiguration>(Configuration);

            services.AddMvc();

              #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Onimta Web Api", Version = "0.0.1" });
            });

            #endregion Swagger

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, ILogger<Startup> logger)
        {
       

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

          


            app.UseAuthentication();

          
            app.UseCors("CorsPolicy");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            // app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

            });
        }
    }

    public static class ApiGlobalExceptionHandlerExtension
    {
        public static IApplicationBuilder UseWebApiExceptionHandler(this IApplicationBuilder app)
        {
            var loggerFactory = app.ApplicationServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;

            return app.UseExceptionHandler(HandleApiException(loggerFactory));
        }

        public static Action<IApplicationBuilder> HandleApiException(ILoggerFactory loggerFactory)
        {
            return appBuilder =>
            {
                appBuilder.Run(async context =>
                {
                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (exceptionHandlerFeature != null)
                    {
                        var logger = loggerFactory.CreateLogger("Serilog Global exception logger");
                        logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                    }

                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync("An unexpected fault happened. Try again later.");

                });
            };
        }
    }

   
}
