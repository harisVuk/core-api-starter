using System;

namespace Demo.Data.Models
{
    public class News : EntityBase
    {
        public string Title { get; set; }

        public string Desctiption { get; set; }

         public User User { get; set; }
    }
}