using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Contracts.Infrastructure.Repository;
using Domain.Users;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public void AddUser(User user)
        {
            Add(user);
        }
    }
}