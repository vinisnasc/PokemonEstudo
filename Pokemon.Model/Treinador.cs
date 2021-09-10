using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model
{
    public class Treinador
    {
        public int IdTreinador { get; set; }
        public string Nome { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
