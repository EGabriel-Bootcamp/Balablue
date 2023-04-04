using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usermanagement_Domain.Interfaces;
using Usermanagement_Domain.Models;

namespace UserManagement_DataAccess.InterfacesImplementation
{
    public class UserRepository : Repository<Users>
    {
        private readonly IRepository<Users> _repository;

        public UserRepository(UserManagementContext context, IRepository<Users> repository) : base(context)
        {
            _repository = repository;
        }
    }
}
