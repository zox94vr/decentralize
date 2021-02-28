using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public Account Account { get; set; }
        public Consultant Consultant { get; set; }
        public Vendor Vendor { get; set; }
        public Project Project { get; set; }
    }
}
