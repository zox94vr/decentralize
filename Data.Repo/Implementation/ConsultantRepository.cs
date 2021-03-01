using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo.Implementation
{
    public class ConsultantRepository : Repository<Consultant>, IConsultantRepository
    {
        public ConsultantRepository(Context context):base(context)
        {

        }
        public override async Task<Consultant> FindById(string id)
        {
            return await DoQuery().Filter(m => m.ConsultantId == id).SingleResultAsync();
        }

    }
}
