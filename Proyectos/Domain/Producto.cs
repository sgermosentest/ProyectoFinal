using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        public string Descripcion { get; set; }

        public decimal Precio { get; set; }

        public int Cantidad { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria  { get; set; }
        public ICollection<Imagen> Imagenes { get; set; }
    }
}
