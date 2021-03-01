using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo.Implementation
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(Context context):base(context)
        {

        }
        public override async Task<Account> FindById(string id)
        {
            return await DoQuery().Filter(m=>m.AccountId==id).SingleResultAsync();
        }
        //public async  Task<Account> FindAccountById(int t)
        //{
        //    return await Where(m => m.AccountId == t).FirstOrDefaultAsync();
        //}

        //public async Task<List<Account>> GetAllAccounts()
        //{
        //    return await GetAll().ToListAsync();
        //}
    }
}
