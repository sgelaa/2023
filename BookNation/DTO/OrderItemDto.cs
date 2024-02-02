namespace BookNation.DTO
{
    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double Subtotal { get; set; }
        public int OrderId { get; set; }
    }
}
