using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Controllers
{
	[ApiController]
	public class ShortenerController : ControllerBase
	{
		private readonly IKeyGenerator _keyGenerator;
		private readonly ShortenerContext _shortenerContext;

		public ShortenerController(ShortenerContext shortenerContext, IKeyGenerator keyGenerator)
		{
			_shortenerContext = shortenerContext;
			_keyGenerator = keyGenerator;
		}

		[HttpPost("shorten")]
		public async Task<ActionResult<string>> Shorten([FromBody] string url)
		{
			// TODO: Move validation somewhere else
			if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri) && 
				uri.IsWellFormedOriginalString() && 
				(uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp))
			{
				string key = _keyGenerator.GetKey(6);

				_shortenerContext.Add(new ShortenedUrl() { Key = key, Url = url });
				await _shortenerContext.SaveChangesAsync();

				return key;
			}

			return BadRequest("Invalid URL");
		}

		[HttpGet("{key}")]
		public IActionResult GoTo([FromRoute]string key)
		{
			var shortenedUrl = _shortenerContext.ShortenedUrls.FirstOrDefault(su => su.Key == key);

			if (shortenedUrl != null)
			{
				return Redirect(shortenedUrl.Url);
			}

			return BadRequest("Invalid Key");
		}
	}
}
