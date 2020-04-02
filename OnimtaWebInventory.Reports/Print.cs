using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.Reports
{
    public class Print
    {
        public Byte[] CreateReport(DataSet ds)
        {

            // ReportDocument cryRpt = new ReportDocument();
             ReportDocument cryRpt = new ReportDocument();


            cryRpt.Load("E:\\Reports\\Invoice.rpt");


            //Result = JsonConvert.SerializeObject(objDbCon.Inventory_Common_Execute_withResult(ref strRturnRes, CommonData.SpName, CommonData.Parameters), Formatting.None);

            cryRpt.SetDataSource(ds);
            Stream pdfStream = null;


            pdfStream = cryRpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);


            byte[] buffer = new byte[0];

            MemoryStream ms = new MemoryStream();
            pdfStream.CopyTo(ms);
            buffer = ms.ToArray();

            return buffer;
        }
    }
}
