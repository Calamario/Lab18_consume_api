using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoApp.Controllers
{
    public class ApiController : Controller
    {
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            using (var client = new HttpClient())
            {
                // add the appropriate properties on top of the client base address.
                client.BaseAddress = new Uri("http://mariotodoapi.azurewebsites.net");

                //the .Result is important for us to extract the result of the response from the call
                var response = client.GetAsync("/api/todo").Result;

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {
                    var stringResult = await response.Content.ReadAsStringAsync();

                    var obj = JsonConvert.DeserializeObject<List<TodoItem>>(stringResult);
                    return View(obj);
                }

                return View();
            }
        }
    }
}
