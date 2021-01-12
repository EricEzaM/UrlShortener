using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ShortenerController : ControllerBase
	{
		private readonly IKeyGenerator _keyGenerator;

		private static List<ShortenedUrl> shortenedUrls = new List<ShortenedUrl>();

		public ShortenerController(IKeyGenerator keyGenerator)
		{
			_keyGenerator = keyGenerator;
		}

		[HttpPost("shorten")]
		public ActionResult<string> Shorten([FromBody] string url)
		{
			string key = _keyGenerator.GetKey(6);

			shortenedUrls.Add(new ShortenedUrl() { Id = 1, Key = key, Url = url });

			return key;
		}

		[HttpGet("{key}")]
		public IActionResult GoTo([FromRoute]string key)
		{
			return Redirect(shortenedUrls.FirstOrDefault(su => su.Key == key).Url);
		}
	}
}
