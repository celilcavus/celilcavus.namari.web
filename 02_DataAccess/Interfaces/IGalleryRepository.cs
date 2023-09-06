using _01_EntityLayer;
using Microsoft.AspNetCore.Http;

namespace _02_DataAccess.Interfaces
{
    public interface IGalleryRepository:IRepository<Galery>
    {
        void Upload();
    }
}
