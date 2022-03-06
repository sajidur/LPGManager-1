using LPGManager.Interfaces.SellsInterface;

namespace LPGManager.Data.Services.SellService
{
    public class SellService : ISellService
    {
        private readonly AppsDbContext _dbContext;

        public SellService(AppsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
