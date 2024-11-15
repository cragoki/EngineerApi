using DAL.DbEngineerContext;
using DAL.Entities;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class EngineerRepository : Repository<Engineer>, IEngineerRepository
    {
        public EngineerRepository(EngineerDbContext context) : base(context)
        {
        }
    }
}
