namespace TMS.API.Models.Dto
{
    public class OrderAddDto
    {
        public int? CustomerId { get; set; } = 0;

        public int? TicketCategoryId { get; set; } = 0;

        public DateTime? OrderedAt { get; set; }

        public int? NumberOfTickets { get; set; }

    }
}
