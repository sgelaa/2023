namespace BookNation.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
        public int AppUserId { get; set; }
    }
}