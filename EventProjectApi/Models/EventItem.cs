using System.ComponentModel.DataAnnotations;

namespace EventProjectApi.Models
{
	public class EventItem
	{
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string EventName { get; set; }
		public string EventDate { get; set; }

	}
}
