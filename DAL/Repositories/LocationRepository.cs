using DAL.DbEngineerContext;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        public LocationRepository(EngineerDbContext context) : base(context)
        {
        }
    }
}
