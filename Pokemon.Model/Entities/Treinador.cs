using PocketMonster.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Entities
{
    public class Treinador : IEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public List<PokemonTreinador> PokemonCapturados { get; set; } 
    }
}
