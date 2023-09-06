using _01_EntityLayer;
using _02_DataAccess.Interfaces;

namespace _02_DataAccess.Repository
{
    public class ServicesRepository : BaseRepository<Services>, IServicesRepository
    {
        public ServicesRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
