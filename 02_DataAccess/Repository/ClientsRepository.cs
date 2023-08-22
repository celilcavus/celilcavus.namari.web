using _01_EntityLayer;
using _02_DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccess.Repository
{
    public class ClientsRepository : BaseRepository<Clients>, IClientsRepository
    {
        public ClientsRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
