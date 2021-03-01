using Data.Repo;
using Data.Repo.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class Bank1PaymentProcessor : IBankPaymentProcessor
    {
        public Task<bool> ExecuteTransaction(string transactionId)
        {
            throw new NotImplementedException();
        }
    }
}
