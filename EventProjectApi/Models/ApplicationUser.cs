using Microsoft.AspNetCore.Identity;

namespace EventProjectApi.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
	}
}
