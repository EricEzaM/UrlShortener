using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener
{
	public class ShortenerContext : DbContext
	{
		public ShortenerContext(DbContextOptions<ShortenerContext> options) : base(options) { }

		public DbSet<ShortenedUrl> ShortenedUrls { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ShortenedUrl>()
				.HasIndex(su => su.Key)
				.IsUnique();
		}
	}
}
