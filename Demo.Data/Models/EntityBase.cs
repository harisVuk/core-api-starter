using System;

namespace Demo.Data.Models
{
    public abstract class EntityBase
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}