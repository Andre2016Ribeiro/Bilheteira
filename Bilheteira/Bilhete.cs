using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilheteira
{
    public class Bilhete
    {
        public int Id { get; set; }
        public int? EspetaculoId { get; set; }
        public int? SalaId { get; set; }
        public DateTime? DataEspetaculo { get; set; }
        public int NumBilhetes { get; set; }
        public int Preco { get; set; }
        public Espetaculo Espetaculo { get; set; }
        public Sala Sala { get; set; }

        public ICollection<Venda> Vendas { get; set; }

    }

   
}
