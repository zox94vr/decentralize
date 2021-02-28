using System;

namespace Data.Dto
{
    public class TransactionDto
    {
        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public bool IsPaid { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string ConsultantId { get; set; }
        public string ConsultantName { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string ProjectId { get; set; }
        public string ProjectName { get; set; }
    }
}
