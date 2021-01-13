using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortener
{
	public class UrlKeyGenerator : IKeyGenerator
	{
		private static readonly char[] chars = "abcdefghijklmnopqrstvwxyz1234567".ToCharArray(); // Length = 32

		/// <summary>
		/// Generates a random string of the length provided.
		/// </summary>
		/// <param name="length">Number of chars to be in the key.</param>
		/// <returns>Key consisting of random characters.</returns>
		public string GetKey(int length)
		{
			byte[] data = new byte[length];

			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(data);
			}

			StringBuilder result = new StringBuilder(length);

			for (int i = 0; i < length; i++)
			{
				var idx = data[i] % chars.Length; // Byte max = 256, chars length = 32, therefore even distribution of characters.
				result.Append(chars[idx]);
			}

			return result.ToString();
		}
	}
}
