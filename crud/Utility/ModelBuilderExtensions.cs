using crud.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Utility
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Email = "ganesh.kumar@gmail.com",  Age = 31,  FirstName = "Ganesh", LastName ="Kumar", Password ="1234er",Id=1 },
                new Employee { Email = "ramesh.kumar@gmail.com", Age = 32, FirstName = "ramesh", LastName = "Kumar", Password = "1234er", Id = 2 },
                new Employee { Email = "mahesh.kumar@gmail.com", Age = 33, FirstName = "mahesh", LastName = "Kumar", Password = "1234er", Id = 3 },
                new Employee { Email = "suresh.kumar@gmail.com", Age = 34, FirstName = "suresh", LastName = "Kumar", Password = "1234er", Id = 4 },
                new Employee { Email = "lokesh.kumar@gmail.com", Age = 31, FirstName = "lokesh", LastName = "Kumar", Password = "1234er", Id = 5 },
                new Employee { Email = "jignesh.kumar@gmail.com", Age = 34, FirstName = "jignesh", LastName = "Kumar", Password = "1234er", Id = 6 }
            );
        }
    }
}
