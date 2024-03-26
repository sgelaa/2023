﻿namespace BookNation.DataAccess.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateAdded { get; set; }

    }
}