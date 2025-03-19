using Project.Data;
using Project.Models;

namespace Project.Repository
{
    public class ShopingCartRepository : GenericRepository<ShopingCart> , IShopingCartRepository
    {
        private readonly ProjectDbContext _dbContext;

        public ShopingCartRepository(ProjectDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
