namespace DAL.Entities
{
    public class Engineer : IEntity
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
