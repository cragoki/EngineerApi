using DAL.DbEngineerContext;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(EngineerDbContext context) : base(context)
        {
        }
    }
}
