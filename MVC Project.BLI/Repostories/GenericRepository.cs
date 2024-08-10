using Microsoft.EntityFrameworkCore;
using MVC_Project.BLI.Interfaces;
using MVC_Project.DAL.Data;
using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.BLI.Repostories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private AppDBContext _contxt;

        public GenericRepository(AppDBContext contxt)
        {
            _contxt = contxt;
        }

        public void Add(T item)
        {
            _contxt.Set<T>().Add(item);
           
        }

        public void Delete(T item)
        {
            _contxt.Set<T>().Remove(item);
           
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
            {
                return (IEnumerable<T>) _contxt.Employees.Include(E=>E.Department).ToList();
            }
            else
            {
                return _contxt.Set<T>().ToList();
            }
        }

         
        

        public T GetById(int id)
         => _contxt.Set<T>().Find(id);

        public void Update(T item)
        {
            _contxt.Set<T>().Update(item);
           
        }
    }
}
