using PocketMonster.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Entities
{
    public class PokemonTreinador : IEntity
    {
        public Guid Id { get; set; }
        public Pokemon Pokemon { get; set; }
        public Guid IdPokemon { get; set; }
        public Treinador Treinador { get; set; }
        public Guid IdTreinador { get; set; }
    }
}
