namespace BookNation.Entities
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WishlistId { get; set; }
    }
}