using _02_DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccess.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IClientsRepository clientsRepository;
        private readonly IAboutRepository aboutRepository;

        public RepositoryManager(IClientsRepository clientsRepository, IAboutRepository aboutRepository)
        {
            this.clientsRepository = clientsRepository;
            this.aboutRepository = aboutRepository;
        }

        public IClientsRepository Clients => clientsRepository;
        public IAboutRepository About => aboutRepository;
    }
}
