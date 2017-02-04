using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class Sha256Controller
    {
        /// <summary>
        /// Silly SHA256 function to simulate HTTP GET
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet("{text}")]
        public string Get(string text)
        {
            using (SHA256 algorithm = SHA256.Create())
            {
                byte[] hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(text));
                return hash.Aggregate(string.Empty, (current, x) => current + String.Format("{0:x2}", x));
            }
        }
    }
}