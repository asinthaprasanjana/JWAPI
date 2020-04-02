using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Dapper;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnimtaPrint._0001_DataBase;
using OnimtaPrint.Utility;
using OnimtaWebInventory.Models;

namespace OnimtaPrint.Controllers
{
    [Route("api/[controller]/[action]")]
    public class PrintDocumentController : Controller
    {
        private IConverter _converter;




        public PrintDocumentController(IConverter converter)
        {
            _converter = converter;
        }

        [HttpGet("{printTypeId},{referenceId}")]
        public async Task<string> GetPrintDetailsByPrintTypeId(int printTypeId, string referenceId)
        {
            string ReturnValue = "0";
            string htmlTemplate = "";

            DBContext dBContext = new DBContext();
            string connectionString = dBContext.GetConnectionString();

            int purchaseOrderPrintTypeId = 1;

            var root = @"E:\DocumentPrint\";
            PrintVM printVM = new PrintVM();  

            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@PrintTypeId", printTypeId);
                    dynamicParameterlist.Add("@ReferenceId", referenceId);
                    printVM = await sqlConnection.QuerySingleOrDefaultAsync<PrintVM>("pnt.AddPrintDetails", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                }


                    if (!Directory.Exists(root))
                {
                    Directory.CreateDirectory(root);
                }


                CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();

                var path = @"C:\Repos\Onimta\DevApi\OnimtaPrint\libwkhtmltox.dll";
                var path1 = @"G:\Onimta\OnimtaDevApi\OnimtaPrint\libwkhtmltox.dll";


                context.LoadUnmanagedLibrary(path);

                var pdfId = referenceId;
                string location = @"E:\DocumentPrint\" + pdfId + " Purchase Order Document.pdf";


                if (printTypeId == purchaseOrderPrintTypeId)
                {
                    htmlTemplate = PurchaseOrderTemplate.GetPurchaseOrderHTMLString(referenceId);
                }

                var objectSettings = new ObjectSettings
                {
                    PagesCount = true,
                    HtmlContent = htmlTemplate,
                    WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                    HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                    FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
                };

                var globalSettings = new GlobalSettings
                {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4,
                    Margins = new MarginSettings { Top = 10 },
                    DocumentTitle = "PDF Report",
                    Out = location
                };

                var pdf = new HtmlToPdfDocument()
                {
                    GlobalSettings = globalSettings,
                    Objects = { objectSettings }
                };

                _converter.Convert(pdf);

                string a = @"F:\print\A.Pdf";
                var response = new HttpResponseMessage();
                response.Content = new StringContent("fg  r fg fgf fg gf");
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
                var printJob = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = a,
                            UseShellExecute = true,
                            Verb = "print",
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden,
                            WorkingDirectory = Path.GetDirectoryName(a)
                        }
                    };

                    printJob.Start();
                

                ReturnValue = "1";
            } catch (Exception ex)
            {
                ReturnValue = ex.Message;
            }


            return ReturnValue;

        }


    }
}