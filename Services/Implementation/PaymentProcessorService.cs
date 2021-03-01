using Data.Repo;
using Services.BankPaymentCreator.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class PaymentProcessorService : IPaymentProcessorService
    {
        private ITransactionRepository _transactionRepository;
        public PaymentProcessorService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;

        }
        public async Task<bool> ExecuteTransaction(string transactionId)
        {
            var tx =await _transactionRepository.DoQuery().JoinWith(m=>m.Account).Filter(m => m.TransactionId == transactionId).SingleResultAsync();
            IBankPaymentProcessor bpp = new BankCreator().CreateBankPaymentProcessor(tx.Account.BankName);
            return await bpp.ExecuteTransaction(transactionId);
        }
    }
}
