using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilheteira
{
    public class Venda
    {public int Id { get; set; }
        public int? BilheteId { get; set; }
        public int? UtilizadorID { get; set; }
        public Bilhete Bilhete { get; set; }
        public Utilizador Utilizador { get; set; }

    }
}
