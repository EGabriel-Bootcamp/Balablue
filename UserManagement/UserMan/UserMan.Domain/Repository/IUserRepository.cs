using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMan.Domain.Entities;

namespace UserMan.Domain.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
    }
}
