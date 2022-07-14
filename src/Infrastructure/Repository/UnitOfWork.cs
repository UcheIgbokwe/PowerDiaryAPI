using Application.Contracts.Infrastructure.Repository;
using Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dbContext;
        private readonly ILogger _logger;
        public IChatEventRepository ChatEvents { get; set; }
        public IUserRepository UserEvents { get; set; }

        public UnitOfWork(DataContext dbContext, ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger("logs");

            ChatEvents = new ChatEventRepository(_dbContext, _logger);
            UserEvents = new UserRepository(_dbContext, _logger);
        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}