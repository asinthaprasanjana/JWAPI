using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class StockTransferSummeryVM
    {
        public string TransferId { get; set; }
        public int Id { get; set; }
        public int SourceLocationId { get; set; }
        public int DestinationLocationId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int CreatedUserId { get; set; }
        public int CompanyId { get; set; }
        public string SourceLocationName { get; set; }
        public string DestinationLocationName { get; set; }
        public int ReceivedUserId { get; set; }
        public int Status { get; set; }
        public string statusType { get; set; }
        public string ReceivedUserName { get; set; }
        public string Remarks { get; set; }
        public int isCancelled { get; set; }
        public int transferCount { get; set; }
        public int StockTransferId { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public int Destination { get; set; }
	    public int Source { get; set; }
    }
}
