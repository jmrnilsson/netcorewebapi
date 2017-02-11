using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiExample.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly HttpClientFactory _httpClientFactory;

        public ValuesController(HttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("{value}")]
        public async Task<string> GetAsync(int value)
        {
            using (HttpClient client = _httpClientFactory())
            {
                return await GetSha256Async(client, value.ToString());
            }
        }

        [HttpGet("bench/{value}")]
        public async Task<string[]> GetBenchAsync(int value)
        {
            var tasks = new List<Task<string>>();
            using (HttpClient client = _httpClientFactory())
            {
                for (int i = 0; i < 1000; i++)
                {
                    tasks.Add(GetSha256Async(client, $"{value+i++}"));
                }
                return await Task.WhenAll(tasks);
            }
        }

        [HttpGet("bench/{value}/sync")]
        public IEnumerable<string> GetBench(int value)
        {
            using (HttpClient client = _httpClientFactory())
            {
                for (int i = 0; i < 1000; i++)
                {
                    yield return GetSha256Async(client, $"{value+i++}").Result;
                }
            }
        }

        [HttpGet("bench/{value}/await")]
        public async Task<string[]> GetBenchAwaitingAsync(int value)
        {
            var tasks = new List<string>();
            using (HttpClient client = _httpClientFactory())
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