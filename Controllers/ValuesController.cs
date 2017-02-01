using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        // curl -i -H "Accept: application/json" -H "Content-Type: application/json" -X GET http://localh0/api/values/2
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            string page = "http://www.vecka.nu/";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine(content);
                //return "some";
                return await content.ReadAsStringAsync();
            }
        }
    }
}