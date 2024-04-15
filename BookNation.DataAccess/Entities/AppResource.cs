namespace BookNation.DataAccess.Entities
{
    public class AppResource
    {
        public int Id { get; set; }
        public string ResourceType { get; set; } // what is the link?
        public string ResourceHost { get; set; }
        public int ResourceHostId { get; set; }
        public string LinkId { get; set; }
        public int AppUserId { get; set; }
    }
}
