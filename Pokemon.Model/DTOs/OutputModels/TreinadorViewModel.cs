using PocketMonster.Model.Entities;
using System.Collections.Generic;

namespace PocketMonster.Model.DTOs.OutputModels
{
    public class TreinadorViewModel
    {
        public int IdTreinador { get; set; }
        public string Nome { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}
