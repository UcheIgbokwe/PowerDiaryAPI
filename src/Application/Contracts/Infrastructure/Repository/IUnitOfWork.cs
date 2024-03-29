using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Contracts.Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        IChatEventRepository ChatEvents { get; }
        IUserRepository UserEvents { get; }
        Task CompleteAsync();
    }
}