using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Salle
    {

        [Key]
        public int Salle_id { get; set; }
        public string Salle_designation { get; set; }
        public int Salle_Capacite { get; set; }
        public List<Equippement> Salle_Equippement {get;set;}
    }
}
