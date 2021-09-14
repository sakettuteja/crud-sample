using crud.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Repository.Abstraction
{
    public interface IRepositoryWrapper
    {
        IEmployeeRepository Employees { get; }
        void Save();
    }
}
