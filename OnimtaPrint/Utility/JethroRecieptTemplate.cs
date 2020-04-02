using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaPrint.Utility
{
    public class JethroRecieptTemplate
    {
        public static string GetHTMLString(string refNo)
        {
            try
            {


                IEnumerable<DonationVM> donationVM;
                donationVM = JethroDataSource.getRecieptDetails(refNo).Result;
                string to = donationVM.ElementAt(0).MemberName; ;
                string address = donationVM.ElementAt(0).Address;
                string paymentMethod = donationVM.ElementAt(0).PaymentMethod;
                string ChequeNo = donationVM.ElementAt(0).ChequeNo;
                string date = donationVM.ElementAt(0).Date;
                string reciptNo = donationVM.ElementAt(0).RecieptNo;
                int totalPaid = 0;
                

                for(int i =0; i<donationVM.Count();i++)
                {
                    totalPaid = totalPaid + donationVM.ElementAt(i).Credit;
                }








                var sb = new StringBuilder();
                sb.Append(@"
                        <html>
                            <head>
                                      
                            </head>
                            <body style='background-color:white;'>
                            </br>
                            </br>
                                <div class='row' style='margin-top:2px ; text-align:center'>                                                                                                 
                                         <h1>Assemblies of God of Ceylon</h1> 
                                          <h4>Administrative  Head Office  <br> 
                                             No 248, Negambo Road, Ja Ela.<h4>
	                            </div>	                        

                                <div class='row' style='margin-top:5px ; text-align:center'>                                                                                                 
                                         <h2>Official Reciept </h2>                                   
	                            </div> ");


                sb.AppendFormat(@"
                              <div class='row' style='margin-top:10px'>                              
                                    
                                          <h3> To :  <span style='padding-left:47px' ><span>  {0}</h3>
                                          <h3>Address :  <span style='padding-left:5px' ><span>
                                                {1}</h3>
                                    
                                   
	                           </div>

                                 <div class='row' style='margin-top:5em'>                                                                  
                                          <h3> 
                                            <span> Reciept # : {2}</span>                                          
                                            <span style='padding-left:20em' > Date : {3}<span>
                                            </h3>                                                                                                                                                                                    
	                            </div>   ", to, address, reciptNo, date);


                sb.Append(@"
                                </br>
                                </br>
                              <div class='row' style='margin-top:2px ; margin-left:200px; text-align:center'>  
                                <table class='table' style='width:70% ;  border: 1px solid black  ; min-height:300px'>
                                    <thead>

                                    <tr style='color:#707070;font-size:20px'>
                                        <th>Details</ th>
                                        <th>Amount</th>                                     
                                    </tr>

                                </thead>");




                foreach (var donation in donationVM)
                {

                    sb.AppendFormat(@"<tbody style='width:100%;'>
                                              <tr style='color:#333333;font-size:14px; font-weight:light'>
                                                <td style='text-align:center'>{0}</td>
                                                <td style='text-align:center'>{1}</td>
                                               
                                              </tr>
                                        
                                          ", donation.Details, donation.Credit );

                }

                sb.Append(@"</tbody> 
                                       </table>
                                     
                                     </div> ");
                sb.Append(@"   <div style='text-align:center ; padding:0px' > <h5>Recieved with thanks<h5> </div>");

                sb.AppendFormat(@" <div> <h4> Total Paid : RS. {0}<h4> <div> ", totalPaid);

                sb.AppendFormat(@"
                                

                                    <div class='row'>                                      
                                          <h4>Payment Method - {0} <h4>                                   
                                     </div>

                                <div class='row' style='padding-top:0px' >
                                     <h4>Cheque No. - {1} <h4>  

                                  </div>
                                <div class='row' style='text-align:center' >
                                       <h4>This is a system generated receipt and a signature is not required </h4>
                                  </div>
                            </body>
                        </html>", paymentMethod, ChequeNo);

                return sb.ToString();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
