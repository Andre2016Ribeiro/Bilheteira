using System;
using System.Collections.Generic;

namespace Bilheteira
{
    public class Espetaculo
    {public int Id { get; set; }
        public string Name { get; set; }
        public string Descricao { get; set; }   
        public string Elenco { get; set; }
        public int? TipoEspetaculoId { get; set; }
        public TipoEspetaculo TipoEspetaculo { get; set; }
        public ICollection<Bilhete> Bilhetes { get; set; }
    }

   
}
