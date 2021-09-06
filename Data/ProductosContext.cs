using Microsoft.EntityFrameworkCore;
using WebAppMVC.Models;

namespace WebAppMVC.Data
{
    public class ProductosContext: DbContext
    {
        public ProductosContext(DbContextOptions<ProductosContext> options)
        :base(options)
        {
            
        }
        public DbSet<Producto> productos {get; set;}
        public DbSet<Usuario> usuarios {get; set;}

    }
}