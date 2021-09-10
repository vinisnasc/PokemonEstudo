using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Sincronizador.ViewModels
{
    class PokeDetailsViewModel
    {
        public IReadOnlyList<string> Types { get; set; }
        public string Url { get; set; }
        public string Location_area_encounters { get; set; }
    }
}
