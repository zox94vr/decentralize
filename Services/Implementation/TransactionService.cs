using Data.Dto;
using Data.Repo;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class TransactionService : ITransactionService
    {
        ITransactionRepository _transactionRepository;
        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }
        public async Task<List<TransactionDto>> GetAllUnpaidTransactions()
        {
            return await _transactionRepository.GetAllUnpaidTransactions();
        }

        public async Task<List<VendorPaymentDto>> GetAmountPaidPerVendorInTime(DateTime from, DateTime to)
        {
            return await _transactionRepository.GetAmountPerVendorInTime(from, to);
        }
    }
}
