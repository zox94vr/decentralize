using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.BankPaymentCreator
{
    public interface IBankCreator
    {
        public IBankPaymentProcessor CreateBankPaymentProcessor(string bankName);
    }
}
