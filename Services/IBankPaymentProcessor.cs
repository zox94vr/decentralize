using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBankPaymentProcessor
    {
         Task<bool> ExecuteTransaction(string transactionId);
    }
}
