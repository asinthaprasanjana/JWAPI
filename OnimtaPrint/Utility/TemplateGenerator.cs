using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaPrint.Utility
{
    public static class TemplateGenerator
    {
        public static string GetHTMLString()
        {
            var employees = DataStorage.GetAllEmployess();
            User user = new User();
            user.ComapnyName = "Onimta IT";
            user.UserName = "Ruchika Perera";

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
			                    <h3 style = 'color:white' > Purchase Order Ref No - </h3>
			                    </br>
    
		                        </div>
	                        </div>");

            sb.AppendFormat(@"</br></br>User Name - {0} </br> 
                              Company -{1}  <br> <br>", user.UserName,user.ComapnyName);




                                sb.Append(@"
                                
                                <table class='table' style='width:100% '>
                                    <thead>

                                    <tr style='color:#707070;font-size:14px'>

                                       
                                        <th >Item Cost</th>
                                        <th >Quantity</th>
                                        <th >Total Cost</th>
                                        <th >Tax</th>
                                        <th >Discount</th>

                                    </tr>

                                </thead>");




            foreach (var emp in employees)
            {

                sb.AppendFormat(@"<tbody style='width:100%;'>
                                              <tr style='color:#333333;font-size:14px; font-weight:light'>
                                                <td style='text-align:center'>{0}</td>
                                                <td style='text-align:center'>{1}</td>
                                                <td style='text-align:center'>{2}</td>
                                                <td style='text-align:center'>{3}</td>
                                                <td style='text-align:center'>{2}</td>
                                                
                                              </tr>
                                        </tbody>", emp.LastName, emp.Age, emp.Gender, emp.Age, emp.Gender);

            }

            sb.Append(@"
                                </table>
                            </body>
                        </html>");

            return sb.ToString();
        }


        public class User
        {
            public string UserName { get; set; }
            public string ComapnyName { get; set; }
        }
    }
}
