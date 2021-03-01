using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IPaymentProcessorService
    {
        Task<bool> ExecuteTransaction(string transactionId);
    }
}
