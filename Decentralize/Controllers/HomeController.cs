using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Decentralize.Models;
using Services;
using System.Net.Http;
using Data.Dto;
using Newtonsoft.Json;
using System.Text;

namespace Decentralize.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ITransactionService _transactionService;


        public HomeController(ILogger<HomeController> logger,ITransactionService transactionService)
        {
            _logger = logger;
            _transactionService = transactionService;
        }

        public  IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Transactions()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage message = await client.GetAsync("https://localhost:44313/api/transaction/");
                    if (message.IsSuccessStatusCode)
                    {
                        var response = await message.Content.ReadAsStringAsync();
                        List<TransactionDto> transactions = JsonConvert.DeserializeObject<List<TransactionDto>>(response);
                        Console.Write("Success");
                        return View("Transactions", transactions);

                    }
                    else
                    {
                        Console.Write("Failure");
                    }
                }
                return View();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task<IActionResult> Execute(string id)
        {

            return await this.Transactions();
        }
        [HttpGet]
        public async Task<IActionResult> PaidPerVendor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PaidPerVendor(PaidPerVendor ppv)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string body = JsonConvert.SerializeObject(ppv);
                    HttpResponseMessage message = await client.PostAsync("https://localhost:44313/api/vendor/",new StringContent(body, Encoding.UTF8, "application/json"));
                    if (message.IsSuccessStatusCode)
                    {
                        var response = await message.Content.ReadAsStringAsync();
                        List<VendorPaymentDto> vendors = JsonConvert.DeserializeObject<List<VendorPaymentDto>>(response);
                        return View("VendorAmount", vendors);

                    }
                    else
                    {
                    }
                }
                return View();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
