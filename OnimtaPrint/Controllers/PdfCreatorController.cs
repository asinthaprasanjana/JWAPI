using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Loader;
using System.Threading.Tasks;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnimtaPrint.Utility;

namespace OnimtaPrint.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [DisableCors]
    public class PdfCreatorController : ControllerBase
    {
        private IConverter _converter;


        public PdfCreatorController(IConverter converter)
        {
            _converter = converter;
        }


        [HttpGet]
        public IActionResult CreatePDF()
        {
           

            CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
           // var path = @"F:\ONIMTA IT API\OnimtaPrint\libwkhtmltox.dll";
            var path = @"C:\Repos\Onimta\DevApi\OnimtaPrint\libwkhtmltox.dll";

            context.LoadUnmanagedLibrary(path);

            var pdfId = Guid.NewGuid().ToString();
            string location = @"F:\print\" + pdfId + "Employee_Report.pdf";


            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report",
                Out = location
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = TemplateGenerator.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
            };

            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            _converter.Convert(pdf);

            return Ok("Successfully created PDF document.");
        }


        [HttpGet("{res}")]
        public string CreateJethroPDF(string res)
        {
            string returnNo = "0";
            string[] nos = res.Split(",");

            int iteration = nos.Count();


            try
            {
                for (int i = 0; i < iteration; i++)
                {
                    string refNo = nos[i];


                    CustomAssemblyLoadContext context = new CustomAssemblyLoadContext();
                    var path = @"C:\Repos\Onimta\DevApi\OnimtaPrint\libwkhtmltox.dll";
                    context.LoadUnmanagedLibrary(path);

                    var root = @"E:\Reciept Print\";
                    var pdfId = refNo;
                    if (!Directory.Exists(root))
                    {
                        Directory.CreateDirectory(root);
                    }
                    string location = @"E:\Reciept Print\" + pdfId + "-" + "Reciept.pdf";


                    var globalSettings = new GlobalSettings
                    {
                        ColorMode = ColorMode.Color,
                        Orientation = Orientation.Portrait,
                        PaperSize = PaperKind.A4,
                        Margins = new MarginSettings { Top = 10 },
                        DocumentTitle = "PDF Report",
                        Out = location
                    };

                    var objectSettings = new ObjectSettings
                    {
                        PagesCount = true,
                        HtmlContent = JethroRecieptTemplate.GetHTMLString(refNo),
                        WebSettings = { DefaultEncoding = "utf-8", UserStyleSheet = Path.Combine(Directory.GetCurrentDirectory(), "assets", "styles.css") },
                        HeaderSettings = { FontName = "Arial", FontSize = 9, Right = "Page [page] of [toPage]", Line = true },
                        FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Center = "Report Footer" }
                    };

                    var pdf = new HtmlToPdfDocument()
                    {
                        GlobalSettings = globalSettings,
                        Objects = { objectSettings }
                    };

                    _converter.Convert(pdf);

                }

                returnNo = "1";
            }
            catch (Exception ex)
            {

                returnNo = ex.Message;
            }
            return returnNo;

        }




    }
}

