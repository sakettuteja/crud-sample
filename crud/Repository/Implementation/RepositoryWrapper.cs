using crud.Context;
using crud.Repository.Abstraction;
using crud.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private ApplicationDBContext _repoContext;
        private IEmployeeRepository _owner;

        public RepositoryWrapper(ApplicationDBContext applicationDBContext)
        {
            this._repoContext = applicationDBContext;
        }

        public IEmployeeRepository Employees
        {
            get
            {
                if (_owner == null)
                {
                    _owner = new EmployeeRepository(_repoContext);
                }
                return _owner;
            }
        }

        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
