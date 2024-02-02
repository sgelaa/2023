namespace BookNation.DTO
{
    public class OrderDto
    {
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
        public string Status { get; set; }
        public double TotalAmount { get; set; }
        public int AppUserId { get; set; }
    }
}