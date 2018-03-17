using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class DataContext : System.Data.Entity.DbContext
    {
        public DataContext() : base("ProduccionConnection")
        {
        }

        public System.Data.Entity.DbSet<Domain.Categoria> Categorias { get; set; }

        public System.Data.Entity.DbSet<Domain.Producto> Productos { get; set; }
        
        public System.Data.Entity.DbSet<Domain.Imagen> Imagenes { get; set; }
    }
}

