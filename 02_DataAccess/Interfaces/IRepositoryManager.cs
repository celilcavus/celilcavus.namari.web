using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccess.Interfaces
{
    public interface IRepositoryManager
    {
        public IClientsRepository Clients { get; }

        public IAboutRepository About { get; }

        public ICustomerRepository Customer { get; }

    }
}
