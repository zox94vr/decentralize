using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Dto;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DecentralizeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        // GET: api/<TransactionController>
        [HttpGet]
        public async Task< IEnumerable<TransactionDto>> Get()
        {
            return await _transactionService.GetAllUnpaidTransactions();
        }


        // GET api/<TransactionController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<VendorPaymentDto>> Get(int id)
        {
            DateTime from = DateTime.Parse("01-01-2019");
            DateTime to = DateTime.Parse("01-01-2021");
            return await _transactionService.GetAmountPaidPerVendorInTime(from, to);
        }

        // POST api/<TransactionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TransactionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
