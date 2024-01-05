using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CasinoSystem.Services.Interfaces;

namespace CasinoSystem.Services.Services
{
    public sealed class Rng : IRng
    {
        private static readonly string[] SpecialChars = new[] { "/", "\\", "=", "+", "?", ":", "&" };

        public string Generate(int length = 50, bool removeSpecialChars = true)
        {
            var bytes = RandomNumberGenerator.GetBytes(length);
            var result = Convert.ToBase64String(bytes);

            return removeSpecialChars
                ? SpecialChars.Aggregate(result, (current, chars) => current.Replace(chars, string.Empty))
                : result;
        }
    }
}
