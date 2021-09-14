using PocketMonster.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.Entities
{
    public class Ginasio : IEntity
    {
        public Guid Id { get; set; }
        public string GymTipo { get; set; }
        public string Cidade { get; set; }
        public Treinador GymLider { get; set; }
    }
}
