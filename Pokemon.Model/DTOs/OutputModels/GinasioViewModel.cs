using PocketMonster.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.DTOs.OutputModels
{
     public class GinasioViewModel
    {
        public Guid Id { get; set; }
        public string GymTipo { get; set; }
        public string Cidade { get; set; }
        public string GymLider { get; set; }
    }
}
