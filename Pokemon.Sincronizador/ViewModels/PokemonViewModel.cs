using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Sincronizador.ViewModels
{
    public class PokemonViewModel
    {
        //private List<string> _idsTypes;
        public string Name { get; set; }
        //[JsonProperty("types_type_name")]
        //public IReadOnlyList<string> Types { get; set; }
        public string Url { get; set; }
        //public string Location_area_encounters { get; set; }

        public class Type
        {
            public string Slot { get; set; }
            [JsonProperty("type")]
            public IReadOnlyList<string> Types { get; set; }
        }

        public int IdPokemon
        {
            get
            {
                return int.Parse(Url?.Split('/').Where(u => !string.IsNullOrEmpty(u)).LastOrDefault());
            }
        }

        //public IReadOnlyList<string> IdTypes
        //{
        //    get
        //    {
        //        if (_idsTypes == null)
        //            _idsTypes = Types.Select(tipo => tipo?.Split('/').Where(u => !string.IsNullOrEmpty(u)).LastOrDefault()).ToList();

        //        return _idsTypes;
        //    }
        //}
    }

    public class Types
    {
        public string Slot { get; set; }
        public Type Type { get; set; }
    }

    public class Type
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
