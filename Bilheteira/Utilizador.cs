using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilheteira
{
    public class Utilizador
    {public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        private string Pass { get; set; }
        public ICollection<Venda> Vendas { get; set; }
    }
}
