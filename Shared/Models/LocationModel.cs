namespace Shared.Models
{
    public class LocationModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal? Xordinate { get; set; }
        public decimal? Yordinate { get; set; }
    }
}
