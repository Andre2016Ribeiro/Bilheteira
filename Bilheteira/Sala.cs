using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bilheteira
{
    public class Sala
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int NumLugares { get; set; }
        public string Endereco { get; set; }

        public ICollection<Bilhete> Bilhetes { get; set; }
    }

    
}
