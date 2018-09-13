using LibraryManagement.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        // constructor

        protected readonly LibraryDbContext _context;

        public CustomerRepository (LibraryDbContext context)
        {
            _context = context;
        }

    }
}
