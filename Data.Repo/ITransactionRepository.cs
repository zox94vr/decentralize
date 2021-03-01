using Data.Dto;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo
{
    public interface ITransactionRepository:IRepository<Transaction>
    {
        Task<List<TransactionDto>> GetAllUnpaidTransactions();
        Task<List<VendorPaymentDto>> GetAmountPerVendorInTime(DateTime from, DateTime to);
    }
}
