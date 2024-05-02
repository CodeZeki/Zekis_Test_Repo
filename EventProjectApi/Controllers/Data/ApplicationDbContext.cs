using EventProjectApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace EventProjectApi.Controllers.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions options)
			: base(options)
		{
		}

		public DbSet<EventModel> Events { get; set; }
	}
}
