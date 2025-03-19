using Project.Data;
using Project.Models;

namespace Project.Repository
{
    public class CustomerRepository : GenericRepository<Customer> , ICustomerRepository
    {
        private readonly ProjectDbContext _dbContext;

        public CustomerRepository(ProjectDbContext dbcontext) : base(dbcontext)
        {
            _dbContext = dbcontext;
        }
    }
}
