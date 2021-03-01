using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repo.Implementation
{
    public class VendorRepository:Repository<Vendor>,IVendorRepository
    {
        public VendorRepository(Context context):base(context)
        {

        }
        public override async Task<Vendor> FindById(string id)
        {
            return await DoQuery().Filter(m => m.VendorId == id).SingleResultAsync();
        }
    }
}
