using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   public  class DataContext : System.Data.Entity.DbContext
    {
        public DataContext() : base ("ProduccionConnection")
        {
                
        }
    }
}
