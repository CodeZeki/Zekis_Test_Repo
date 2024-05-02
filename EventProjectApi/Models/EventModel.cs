using System.ComponentModel.DataAnnotations;

namespace EventProjectApi.Models
{
    public class EventModel
    {
        [Key]
        public int Id { get; set; }
        public string Creator { get; set; } = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        public string Name { get; set; } = string.Empty;
        public string Info { get; set; } = string.Empty;
        public bool IsRecurring { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public string LocationAddress { get; set; } = string.Empty;
        public string LocationComment { get; set; } = string.Empty;
        public string LocationWebsite { get; set; } = string.Empty;
        public string LocationDestination { get; set; } = string.Empty;
    }
}
