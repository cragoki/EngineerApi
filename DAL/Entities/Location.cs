using Microsoft.EntityFrameworkCore;

namespace DAL.Entities
{
    public class Location : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        [Precision(11, 8)]
        public decimal? Xordinate { get; set; }
        [Precision(11, 8)]
        public decimal? Yordinate { get; set; }
    }
}
