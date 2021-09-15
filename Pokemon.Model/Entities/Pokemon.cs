using PocketMonster.Model.Entities;
using PocketMonster.Model.Interfaces;
using System;
using System.Collections.Generic;

namespace PocketMonster.Model.Entities
{
    public class Pokemon : IEntity
    {
        public Guid Id { get; set; }
        public int RegistroPokedex { get; set; }
        public string Nome { get; set; }
        public string Tipo1 { get; set; }
        public string? Tipo2 { get; set; }
        public List<PokemonTreinador> PokemonTreinador { get; set; } = new();
    }
}
