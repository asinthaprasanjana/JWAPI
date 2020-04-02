using OnimtaPrint.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnimtaPrint.Utility
{
    public static class DataStorage
    {
        public static List<Employee> GetAllEmployess()
        {
            return new List<Employee>
            {
                new Employee { Name="Mike", LastName="Turner", Age=35, Gender="Male"},
                
            };
        }
    }
}
