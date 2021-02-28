using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo.Implementation
{
    public class TransactionRepository : Repository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(Context context):base(context)
        {

        }
        public override async Task<Transaction> FindById(string id)
        {
            return await Where(m => m.TransactionId == id).FirstOrDefaultAsync();
        }
    }
}
