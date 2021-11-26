using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;

namespace WitWebAPI.Services
{
    /// <summary>
    /// Provides functions to allow for One Way string encryption. Usually passwords
    /// <para>Note: this class differs from the Security class as Security allows 2 way encryption</para>
    /// </summary>
    public class Password : IPassword
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit
        private const int Iterations = 10000;
        public Password(IOptions<HashingOptions> options)
        {
            Options = options.Value;
        }

        private HashingOptions Options { get; }

        public string Hash(string password)
        {
            using var algorithm = new Rfc2898DeriveBytes(
              password,
              SaltSize,
              Options.Iterations,
              HashAlgorithmName.SHA512);

            return FormatHash(
                Convert.ToBase64String(algorithm.Salt),
                Convert.ToBase64String(algorithm.GetBytes(KeySize)
                )
            );
        }

        private string FormatHash(string salt, string value)
        {
            while (salt.EndsWith("="))
            {
                salt = salt.Remove(salt.LastIndexOf("="));
            }

            value = value.Insert(17, salt);

            return Scramble(value);
        }

        private (string Salt, string Value) DeFormatHash(string password)
        {
            password = UnScramble(password);
            //Ok, we put the salt at position 17 in the key, but we don't know how long the salt is. Let's figure that out.
            int len = password.Length - 44;

            //We now have to undo do what we did in the FormatPassword function
            string salt = password.Substring(17, len);

            string value = password.Replace(salt, "");

            //Now we need to tack the == back on the salt
            while (salt.Length < 24)
            {
                salt += "=";
            };

            return (salt, value);
        }

        static string Scramble(string value)
        {
            char[] chars = value.ToArray();
            Random r = new Random(259);
            for (int i = 0; i < chars.Length; i++)
            {
                int randomIndex = r.Next(0, chars.Length);
                char temp = chars[randomIndex];
                chars[randomIndex] = chars[i];
                chars[i] = temp;
            }

            //And now lets makye this string into a base64 string.
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(new string(chars)));
        }

        static string UnScramble(string value)
        {
            value = Encoding.UTF8.GetString(Convert.FromBase64String(value));

            Random r = new Random(259);
            char[] scramChars = value.ToArray();
            List<int> swaps = new List<int>();
            for (int i = 0; i < scramChars.Length; i++)
            {
                swaps.Add(r.Next(0, scramChars.Length));
            }
            for (int i = scramChars.Length - 1; i >= 0; i--)
            {
                char temp = scramChars[swaps[i]];
                scramChars[swaps[i]] = scramChars[i];
                scramChars[i] = temp;
            }

            return new string(scramChars);
        }

        public bool Check(string hash, string password)
        {
            var (Salt, Key) = DeFormatHash(hash);

            var salt = Convert.FromBase64String(Salt);
            var key = Convert.FromBase64String(Key);

            using var algorithm = new Rfc2898DeriveBytes(
              password,
              salt,
              Iterations,
              HashAlgorithmName.SHA512);

            var keyToCheck = algorithm.GetBytes(KeySize);
            var verified = keyToCheck.SequenceEqual(key);

            return verified;
        }
    }

    public interface IHashingOptions
    {
        int Iterations { get; set; }
    }

    public sealed class HashingOptions : IHashingOptions
    {
        public int Iterations { get; set; } = 10000;
    }
}
