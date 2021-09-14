using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.DTOs.OutputModels
{
    public class PokemonViewModel
    {
        public Guid Id { get; set; }
        public int RegistroPokedex { get; set; }
        public string Nome { get; set; }
        public string Tipo1 { get; set; }
        public string Tipo2 { get; set; }
    }
}
