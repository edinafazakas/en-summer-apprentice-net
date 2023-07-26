namespace TMS.API.Models.Dto
{
    public class EventDto
    {
        public int EventId { get; set; }

        public int? VenueId { get; set; }

        public int? EventTypeId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

    }
}
