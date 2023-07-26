using System.Globalization;

namespace TMS.API.Models.Dto
{
    public class EventAddDto
    {
        public int EventId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual string EventTypeName { get; set; }

        public virtual string TicketCategoryDescription { get; set; }

        public virtual string VenueLocation { get; set; }
    }
}
