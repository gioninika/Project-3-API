using Project.Data;
using Project.Models;

namespace Project.Repository
{
    public class OrderRepository : GenericRepository<Order> , IOrderRepository
    {
        private readonly ProjectDbContext _dbContext;

        public OrderRepository(ProjectDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
