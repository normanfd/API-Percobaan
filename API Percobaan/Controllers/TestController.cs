using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace API_Percobaan.Controllers
{
    [ApiController]
    [Route("api/v1/test")]
    public class TestController : ControllerBase
    {
        static long safeInstanceCount = 9999999998;
        [HttpGet]
        public IActionResult Test()
        {
            var now = DateTime.Now;
            Interlocked.Increment(ref safeInstanceCount);
            if (safeInstanceCount.ToString().Length > 10){
                Interlocked.Exchange(ref safeInstanceCount, 1);
            }
            string formattedString = "bficonnect-" + now.Year + safeInstanceCount.ToString("D10") + '-' + GenerateRandomString(6);
            return Ok(formattedString);
        }
        public static string GenerateRandomString(int length, string allowableChars = null)
        {
            if (string.IsNullOrEmpty(allowableChars))
                allowableChars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            // Generate random data
            var rnd = new byte[length];
            using (var rng = new RNGCryptoServiceProvider())
                rng.GetBytes(rnd);

            // Generate the output string
            var allowable = allowableChars.ToCharArray();
            var l = allowable.Length;
            var chars = new char[length];
            for (var i = 0; i < length; i++)
                chars[i] = allowable[rnd[i] % l];

            return new string(chars);
        }
    }
}
