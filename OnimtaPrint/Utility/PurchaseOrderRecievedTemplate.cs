using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaPrint.Utility
{
    public class PurchaseOrderRecievedTemplate
    {
        public static string GetPurchaseOrderHTMLString(string referenceId)
        {
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();


            //try
            //{
            //    using (var sqlConnection = new SqlConnection(connectionString))
            //    {
            //        var dynamicParameters = new DynamicParameters();
            //        dynamicParameters.Add("@RefNo", Convert.ToInt32(refNo));


            //        donationVMs = await sqlConnection.QueryAsync<DonationVM>("[dbo].[GetPrintDonationDetails]", dynamicParameters, commandType: CommandType.StoredProcedure);
            //        return donationVMs;

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception(ex.Message);
            //}


            var sb = new StringBuilder();
            sb.Append(@"
                        <html>
                            <head>
                            </head>
                            <body style='background - color:#e5e5e5;'>
                            </br>
                            </br>
	                        <div class='row col - md - 12' style='margin-top:20px'>
                                <div class='column' style='background-color:#33bb8b ; padding-top:10px;padding-left:20px'>
			                    <h3 style = 'color:white' > Purchase Order Recieved Ref No - </h3>
			                    </br>
    
		                        </div>
	                        </div>");

            return sb.ToString();
        }
    }
}
