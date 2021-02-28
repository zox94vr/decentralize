using Data.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ITransactionService
    {
        Task<List<TransactionDto>> GetAllUnpaidTransactions();
        Task<List<VendorPaymentDto>> GetAmountPaidPerVendorInTime();
    }
}
