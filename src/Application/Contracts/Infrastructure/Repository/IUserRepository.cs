using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Users;

namespace Application.Contracts.Infrastructure.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        void AddUser(User user);
    }
}