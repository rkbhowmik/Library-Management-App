using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
       

        public AuthorRepository (LibraryDbContext context) : base(context)
        {
          
        }
        public IEnumerable<Author> GetAllWithBooks()
        {
            // Include method will return all the entities from the Author class
            return _context.Authors.Include(a => a.Books);
        }

        // First it will search Author by its id and then returns associated books
        // and load it
        public Author GetWithBooks(int id)
        {
            return _context.Authors.Where(a => a.AuthorId == id)
                .Include(a => a.Books)
                .FirstOrDefault();
        }
    }
}
