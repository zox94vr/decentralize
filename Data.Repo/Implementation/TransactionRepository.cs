using Data.Dto;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return await DoQuery().Filter(m => m.TransactionId == id).SingleResultAsync();
        }

        public async Task<List<TransactionDto>> GetAllUnpaidTransactions()
        {
            try
            {
                var unpaidTXs = await DoQuery().Filter(m => m.IsPaid == false).JoinWith(m => m.Vendor).JoinWith(m => m.Account).JoinWith(m => m.Consultant).JoinWith(m => m.Project).AsListAsync();
                List<TransactionDto> unpaidTransactions = unpaidTXs
                .Select(m => new TransactionDto
                {
                    Amount = m.Amount,
                    AccountName = m.Account.Name,
                    AccountId = m.Account.AccountId,
                    ConsultantId = m.Consultant.ConsultantId,
                    ConsultantName = m.Consultant.Name,
                    IsPaid = m.IsPaid,
                    ProjectId = m.Project.ProjectId,
                    ProjectName = m.Project.Name,
                    TransactionId = m.TransactionId,
                    VendorId = m.Vendor.VendorId,
                    VendorName = m.Vendor.Name
                }).ToList();
                return unpaidTransactions;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }


        }

        public async  Task<List<VendorPaymentDto>> GetAmountPerVendorInTime(DateTime from, DateTime to)
        {
            try
            {
                var result = await DoQuery().JoinWith(m => m.Vendor).Filter(m => m.Date >= from && m.Date <= to).AsListAsync();
                List<VendorPaymentDto> vendors = result.GroupBy(m => m.Vendor.Name).Select(m => new VendorPaymentDto
                {
                    Amount = m.Sum(a => a.Amount),
                    VendorName = m.Key
                }).ToList();
                return vendors;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
    }
}
