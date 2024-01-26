namespace BookNation.Entities
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPhone { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<AppAddress> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Wishlist> Wishlists { get; set; }
        public Cart Cart { get; set; }
    }
}
