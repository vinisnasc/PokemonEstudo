using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketMonster.Model.DTOs.InputModels
{
    public class GinasioInputModel
    {
        public string GymTipo { get; set; }
        public string Cidade { get; set; }
        public string GymLider { get; set; }
    }
}
