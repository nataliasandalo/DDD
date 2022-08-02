using Domain.Entities;
using Infrastructure.DBConfiguration.EFCore;
using Infrastructure.Interface.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DDDContext context) : base(context)
        {
        }
    }
}
