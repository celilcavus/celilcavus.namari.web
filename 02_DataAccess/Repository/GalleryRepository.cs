using _01_EntityLayer;
using _02_DataAccess.Interfaces;
using Microsoft.AspNetCore.Http;

namespace _02_DataAccess.Repository
{
    public class GalleryRepository : BaseRepository<Galery>, IGalleryRepository
    {
        public GalleryRepository(ApplicationContext context) : base(context)
        {
        }

        public void Upload()
        {
            //var tempFile = Path.GetTempFileName();
            //using var stream = File.OpenWrite(tempFile);
            //file.CopyToAsync(stream);

            string kaynak = @"C:\Users\Celil Çavuş\Desktop\WhatsApp Image 2023-08-05 at 23.34.26.jpeg";
            string hedef = @"D:\Software\WinMvc\celilcavus.namari.web\Namari\wwwroot\Image\";
            File.Copy(kaynak, hedef, true);
        }
    }
}
