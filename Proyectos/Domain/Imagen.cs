using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Imagen
    {
        [Key]
        public int ImagenId { get; set; }

        public int ProductoId { get; set; }

        public string Descripcion { get; set; }

        public string Ruta { get; set; }

        public Producto Producto { get; set; }
    }
}
