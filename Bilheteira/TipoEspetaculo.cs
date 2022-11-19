using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilheteira
{
    public class TipoEspetaculo
    {public int Id { get; set; }
        public string Tipo { get; set; }  
        public ICollection<Espetaculo> Espetaculos { get; set; }
    }
}
