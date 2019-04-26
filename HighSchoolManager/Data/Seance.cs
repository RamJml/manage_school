using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Seance
    {
        
        [Key]
        public int Seance_id { get; set; }
        public string  Seance_Jour { get; set; }
        public string  Seance_Heure { get; set; }
        
        public string Enseignant_id_FK { get; set; }
        [ForeignKey("Enseignant_id_FK")]
        public Enseignant Ref_Enseignant { get; set; }

        public int Matiere_id_FK { get; set; }
        [ForeignKey("Matiere_id_FK")]
        public Matiere Ref_Matiere { get; set; }
        
        public int Salle_id_FK { get; set; }
        [ForeignKey("Salle_id_FK")]
        public Salle Ref_Salle { get; set; }
        
        public int Groupe_id_FK { get; set; }
        [ForeignKey("Groupe_id_FK")]
        public Groupe Ref_Groupe { get; set; }

    }
}
