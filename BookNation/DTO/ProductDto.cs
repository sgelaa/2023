namespace BookNation.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Volume { get; set; }
        public ICollection<AuthorDto> Author { get; set; }
        public string Format { get; set; }
        public string Edition { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string PageCount { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ApplicableFieldDto> ApplicableField { get; set; }
    }
}