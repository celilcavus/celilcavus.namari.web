using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccess.Interfaces
{
    public interface IRepository<T> where T : class,new()
    {
        void Add(T item);
        void Remove(T item);
        void Update(T item);
        T GetById(int? id);
        IEnumerable<T> GetAll(bool trackChnages = false);
        int SaveChanges();
    }
}
