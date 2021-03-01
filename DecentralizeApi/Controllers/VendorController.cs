using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Dto;
using Decentralize.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DecentralizeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        ITransactionService _transactionService;
        public VendorController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
        // GET: api/<VendorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<VendorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VendorController>
        [HttpPost]
        public async Task<List <VendorPaymentDto>> Post([FromBody] PaidPerVendor ppv)
        {
            return await _transactionService.GetAmountPaidPerVendorInTime(ppv.From, ppv.To);

        }

        // PUT api/<VendorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VendorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
