namespace BookNation.DTO
{
    public class AppAddressDto
    {
        public string ReceipientName { get; set; }
        public string Type { get; set; } // residential or business
        public string ReceipientNumber { get; set; }
        public string StreetAddress { get; set; }
        public string BuildingComplex { get; set; }
        public string Suburb { get; set; }
        public string CityTown { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public int AppUserId { get; set; }
    }
}