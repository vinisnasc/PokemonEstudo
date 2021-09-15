using PocketMonster.Model.Entities;
using System;
using System.Collections.Generic;

namespace PocketMonster.Model.DTOs.OutputModels
{
    public class TreinadorViewModel
    {
        public Guid IdTreinador { get; set; }
        public string Nome { get; set; }
        public List<PokemonViewModel> Pokemons { get; set; }
    }
}
