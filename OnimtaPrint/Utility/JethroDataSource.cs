using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace OnimtaPrint.Utility
{
    public class JethroDataSource
    {

        
        private static string jethroConnectionString = "Data Source=AGC-WEBSERVER\\;Initial Catalog=Jethro;Persist Security Info=True;User ID=sa;Password=it@onimta1+;MultipleActiveResultSets=True";

        private static string connectionString = "Data Source=SERVER\\ONIMTA;Initial Catalog=Jethro;Persist Security Info=True;User ID=sa;Password=it@onimta1+;MultipleActiveResultSets=True";
        public static SqlConnection sqlConnection;

        public async static  Task <IEnumerable< DonationVM>>  getRecieptDetails(string refNo)
        {
            IEnumerable<DonationVM> donationVMs;

            try
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var dynamicParameters = new DynamicParameters();
                    dynamicParameters.Add("@RefNo", Convert.ToInt32(refNo));


                    donationVMs = await sqlConnection.QueryAsync<DonationVM>("[dbo].[GetPrintDonationDetails]", dynamicParameters, commandType: CommandType.StoredProcedure);
                    return donationVMs;

                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
           
        }
    }


    public class DonationVM
    {
      
        public string MemberName { get; set; }
        public int Credit { get; set; }
        public string Month { get; set; }
        public string Date { get; set; }

        public string Region { get; set; }

        public string Pin { get; set; }
        public string Type { get; set; }
        public string Details { get; set; }
        public string RecieptNo { get; set; }

        public string Address { get; set; }

        public string ChequeNo { get; set; }

        public string PaymentMethod { get; set; }


    }


}
