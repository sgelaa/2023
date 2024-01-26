using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookNation.Entities
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AppUserId { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}