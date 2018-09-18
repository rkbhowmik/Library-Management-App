using LibraryManagement.Data.Model;
using LibraryManagement.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class DbSeeder
    {
        public static void Seed(IApplicationBuilder app)
        {
            /// Registering LibraryDbContext as a scoped service and then attempting to access it outside of a scope.
            /// In order to create a scope using the following solution
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LibraryDbContext>();

                // Add Customers
                var john = new Customer { Name = " John Doe" };

                var anna = new Customer { Name = "Anna Doe" };

                var david = new Customer { Name = "David Doe" };

                context.Customers.Add(john);
                context.Customers.Add(anna);
                context.Customers.Add(david);

                // Add Author
                var authorDeMarco = new Author
                {
                    Name = "M J DeMarco",
                    Books = new List<Book>()
                {
                    new Book { Title = "The Millionaire Fastlane" },
                    new Book { Title = "Unscripted" }
                }
                };

                var authorCardone = new Author
                {
                    Name = "Grant Cardone",
                    Books = new List<Book>()
                {
                    new Book { Title = "The 10X Rule"},
                    new Book { Title = "If You're Not First, You're Last"},
                    new Book { Title = "Sell To Survive"}
                }
                };

                context.Authors.Add(authorDeMarco);
                context.Authors.Add(authorCardone);

                context.SaveChanges();
            }
        }
    }
}
