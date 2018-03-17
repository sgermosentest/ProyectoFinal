using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        public string Descripcion { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}
