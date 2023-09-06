using _02_DataAccess.Interfaces;

namespace _02_DataAccess.Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly IClientsRepository clientsRepository;
        private readonly IAboutRepository aboutRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IGalleryRepository galleryRepository;
        private readonly IServicesRepository servicesRepository;


        public RepositoryManager(IClientsRepository clientsRepository, IAboutRepository aboutRepository, ICustomerRepository customerRepository, IGalleryRepository galleryRepository, IServicesRepository servicesRepository)
        {
            this.clientsRepository = clientsRepository;
            this.aboutRepository = aboutRepository;
            this.customerRepository = customerRepository;
            this.galleryRepository = galleryRepository;
            this.servicesRepository = servicesRepository;
        }

        public IClientsRepository Clients => clientsRepository;
        public IAboutRepository About => aboutRepository;

        public ICustomerRepository Customer => customerRepository;

        public IGalleryRepository Gallery => galleryRepository;

        public IServicesRepository Services => servicesRepository;
    }
}
