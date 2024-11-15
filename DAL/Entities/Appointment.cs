using DAL.Enums;

namespace DAL.Entities
{
    public class Appointment : IEntity
    {
        public int Id { get; set; }
        public int EngineerId { get; set; }
        public virtual Engineer EngineerEntity { get; set; }
        public int LocationId { get; set; }
        public virtual Location LocationEntity { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatusType Status { get; set; }
    }
}
