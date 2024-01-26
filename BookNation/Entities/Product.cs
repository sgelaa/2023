using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookNation.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Format { get; set; }
        public ICollection<Author> Author { get; set; }
        public string Volume { get; set; }
        public string Edition { get; set; }
        // public ICollection<string> Languages { get; set; }
        public string Language { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string PageCount { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public ICollection<ApplicableField> ApplicableField { get; set; }
    }
}