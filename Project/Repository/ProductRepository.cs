using Project.Data;
using Project.Models;

namespace Project.Repository
{
    public class ProductRepository : GenericRepository<Product> , IProductRepository
    {
        private readonly ProjectDbContext _dbContext;

        public ProductRepository(ProjectDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
