using Microsoft.EntityFrameworkCore;
using pet_shop_api.Entities;

namespace pet_shop_api.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
