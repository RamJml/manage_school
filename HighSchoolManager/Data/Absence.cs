using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Absence
    {

        [Key]
        public int Absence_id { get; set; }

        public string Etudiant_FK{ get; set; }
        [ForeignKey("Etudiant_FK")]
        public Etudiant Ref_Etudiant{ get; set; }
        
        public int Seance_FK{ get; set; }
        [ForeignKey("Seance_FK")]
        public Seance Ref_Seance{ get; set; }
    }
}
