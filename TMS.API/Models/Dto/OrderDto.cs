namespace TMS.API.Models.Dto
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime? OrderedAt { get; set; }
        public int? NumberOfTickets { get; set; }
        public int? TotalPrice { get; set; }

    }
}
