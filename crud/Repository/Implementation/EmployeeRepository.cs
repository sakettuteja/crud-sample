using crud.Context;
using crud.Model;
using crud.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace crud.Repository.Implementation
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDBContext repositoryContext)
             : base(repositoryContext)
        {
        }
    }
}
