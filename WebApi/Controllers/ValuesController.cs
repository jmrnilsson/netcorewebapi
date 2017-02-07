using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet("{value}")]
        public async Task<string[]> GetAsync(int value)
        {
            var tasks = new List<Task<string>>();
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < 1000; i++)
                {
                    tasks.Add(GetSha256Async(client, $"{value+i++}"));
                }
                return await Task.WhenAll(tasks);
            }
        }

        [HttpGet("{value}/sync")]
        public IEnumerable<string> Get(int value)
        {
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < 1000; i++)
                {
                    yield return GetSha256Async(client, $"{value+i++}").Result;
                }
            }
        }

        [HttpGet("{value}/await")]
        public async Task<string[]> GetAwaitingAsync(int value)
        {
            var tasks = new List<string>();
            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < 1000; i++)
                {
                    tasks.Add(await GetSha256Async(client, $"{value+i++}"));
                }
                return tasks.ToArray();
            }
        }

        private async Task<string> GetSha256Async(HttpClient client, string text)
        {
            var page = $"http://localhost:5000/api/sha256/{text}";
            using (HttpResponseMessage response = await client.GetAsync(page))
            using (HttpContent content = response.Content)
            {
                response.EnsureSuccessStatusCode();
                Console.WriteLine(content);
                return await content.ReadAsStringAsync();
            }
        }
    }
}