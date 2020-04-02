using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class DashBoardVM
    {
        public int Id { get; set; }
        public string StoredProcedureType { get; set; }
        public IEnumerable<Items>  Items1 { get; set; }
        public IEnumerable<Items> Items2 { get; set; }
        public IEnumerable<Items> Items3 { get; set; }
        public IEnumerable<Items> Items4 { get; set; }
        public IEnumerable<Items> Items5 { get; set; }
        public IEnumerable<Items> Items6 { get; set; }
        public IEnumerable<Items> Items7 { get; set; }
        public IEnumerable<Items> Items8 { get; set; }
      


    }
}

public class Items
{

  public int reference1 { get; set; }
  public string reference2 { get; set; }
  public string reference3 { get; set; }
  public string reference4 { get; set; }
  public string reference5 { get; set; }
  public int percentage { get; set; }
  public  int totalCount { get; set; }

    
}