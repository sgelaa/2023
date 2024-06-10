namespace BookNation.DataAccess.Entities
{
    public class AppResource
    {
        public int Id { get; set; }

        public string ResourceType { get; set; } // what is the link? e.g UserInvoice
        

        public string ResourceHost { get; set; } // parent entity
        public int ResourceHostId { get; set; } // parent entity Id
        
        public string LinkId { get; set; } // child resource
    }
}
