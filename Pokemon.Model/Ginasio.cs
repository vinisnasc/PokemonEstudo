using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model
{
    public class Ginasio
    {
        public int IdGinasio { get; set; }
        public string GymTipo { get; set; }
        public string Cidade { get; set; }
        public Treinador GymLider { get; set; }
    }
}
