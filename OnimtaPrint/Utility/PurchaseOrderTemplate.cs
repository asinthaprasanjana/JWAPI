using Dapper;
using OnimtaPrint._0001_DataBase;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaPrint.Utility
{
    public class PurchaseOrderTemplate
    {

        public static string GetPurchaseOrderHTMLString(string referenceId)
        {
            DBContext dBContext = new DBContext();
            string connectionString = dBContext.GetConnectionString();
            PurchaseOrderMasterVM purchaseOrderMasterVM = new PurchaseOrderMasterVM();
            IEnumerable< PurchaseOrderItemVM> purchaseOrderItemVM;



            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                   
                    var dynamicParameterlist = new DynamicParameters();
                    dynamicParameterlist.Add("@PurchaseOrderId", referenceId);
                    dynamicParameterlist.Add("@CompanyId", 1);
                    purchaseOrderMasterVM =  sqlConnection.QuerySingleOrDefault<PurchaseOrderMasterVM>("stk.GetPurchaseOrderDetailsByPurchaseOrderId", dynamicParameterlist, commandType: CommandType.StoredProcedure);

                    var dynamicParameterlist1 = new DynamicParameters();
                    dynamicParameterlist1.Add("@PurchaseOrderId", referenceId);
                    purchaseOrderItemVM = sqlConnection.Query<PurchaseOrderItemVM>("stk.GetPurchaseOrderItemByPurchaseOrderID", dynamicParameterlist1, commandType: CommandType.StoredProcedure);

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var sb = new StringBuilder();
            sb.AppendFormat(@"
                        <html>
                            <head>
                            </head>
                            <body style='background - color:#e5e5e5;'>
                            </br>
                            </br>
	                        <div class='row col - md - 12' style='margin-top:20px'>
                                <div class='column' style='background-color:#33bb8b ; padding-top:10px;padding-left:20px'>
			                    <h3 style = 'color:white' > Purchase Order Ref No - {0}  </h3>
    			                <h3 style = 'color:white' > Bill To - {1}  </h3>
			                    <h3 style = 'color:white' > Ship To - {2}  </h3>
		                        </div>
	                        </div>", referenceId,purchaseOrderMasterVM.BillTo,purchaseOrderMasterVM.ShipTo);
                            

            sb.Append(@"
                              
                                </br>
                                </br>
                                <table class='table' style='width:100% '>
                                    <thead>

                                    <tr style='color:#707070;font-size:16px'>

                                       
                                        <th >Product Name</th>
                                        <th >Packsize Name</th>
                                        <th >Quantity</th>
                                        <th >Cost</th>
                                        <th >Tax</th>
                                        <th >Total Cost</th>

                                    </tr>

                                </thead>");


            foreach (var item in purchaseOrderItemVM)
            {

                sb.AppendFormat(@"<tbody style='width:100%;'>
                                              <tr style='color:#333333;font-size:16px; font-weight:light'>
                                                <td style='text-align:center'>{0}</td>
                                                <td style='text-align:center'>{1}</td>
                                                <td style='text-align:center'>{2}</td>
                                                <td style='text-align:center'>{3}</td>
                                                <td style='text-align:center'>{4}</td>
                                                <td style='text-align:center'>{5}</td>
   
                                              </tr>
                                        </tbody>", item.ProductName, item.PackSizeName, item.Quantity, item.ItemCost, item.Tax,item.TotalCost);

            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }
    }
}
