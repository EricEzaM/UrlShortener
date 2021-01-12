using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener
{
	public class ShortenedUrl
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public string Url { get; set; }
		[Required]
		[MaxLength(20)]
		public string Key { get; set; }
	}
}
