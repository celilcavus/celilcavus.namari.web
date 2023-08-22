using _02_DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_DataAccess.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class,new()
    {
        private readonly ApplicationContext _context;

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(T item)
        {
            _context.Set<T>().Add(item);
        }

        public IEnumerable<T> GetAll(bool trackChnages = false)
        {
            if (trackChnages == false)
            {
                return _context.Set<T>().ToList();
            }
            else
                return _context.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int? id)
        {
            if (id.HasValue)
            {
                return _context.Set<T>().Find(id.Value)!;
            }
            return null!;
        }

        public void Remove(T item)
        {
            _context.Set<T>().Remove(item);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
        }
    }
}
