using LibraryManagement.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly LibraryDbContext _context;

        public Repository(LibraryDbContext context)
        {
            _context = context;
        }
        protected void Save() => _context.SaveChanges();

        // count the elements like book or authors it will pass and delegate from outside
        // and predicate will determine which elements to be searched and 
        // then count them
        public int Count(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate).Count();
        }

        // For creating pass the entity and Add method will add this object to the context
        // Then save it
        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }


        // It will delete the object from the context and then save it
        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        // It will pass the delegate from outside and in search with this delegate
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }

        // Get a set of entities and return it
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        // Go to the current set and find this. Find method search it my id.
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        // Change the state of the object and save it again
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
    }
}
