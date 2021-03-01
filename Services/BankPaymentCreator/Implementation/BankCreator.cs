using Services.BankPaymentCreator;
using Services.Implementation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.BankPaymentCreator.Implementation
{
    public class BankCreator : IBankCreator
    {

        public IBankPaymentProcessor CreateBankPaymentProcessor(string bankName)
        {
            try
            {
                IBankPaymentProcessor bpp = null;
                if (bankName == "Bank1")
                {
                    bpp = new Bank1PaymentProcessor();
                }
                else if (bankName == "Bank2")
                {
                    bpp = new Bank2PaymentProcessor();
                }
                if (bankName == "Bank3")
                {
                    bpp = new Bank3PaymentProcessor();
                }
                else
                {
                    throw new Exception("That bank doesnt exist");
                }
                return bpp;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }
    }
}
