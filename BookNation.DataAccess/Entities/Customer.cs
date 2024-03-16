namespace BookNation.DataAccess.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public DateTime DateAdded { get; set; }
    }
}