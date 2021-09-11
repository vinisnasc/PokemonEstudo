using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Sincronizador.ViewModels
{
    public class PokeDetailsViewModel
    {
        public int id { get; set; }
        public List<Type> types { get; set; }
        public Species species { get; set; }
    }

    public class Type
    {
        public int slot { get; set; }
        public Type2 type { get; set; }
    }

    public class Type2
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
