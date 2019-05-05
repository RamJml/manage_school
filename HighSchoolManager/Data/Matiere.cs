using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Matiere
    {

        [Key]
        public int Matiere_id { get; set; }
        [Display(Name ="Désignation")]
        public string Matiere_designation { get; set; }
        public List<TypeEquippement> Matiere_typeEquippements { get; set; }

        public int Specialite_id_FK { get; set; }

        [Display(Name = "Spécialité")]
        [ForeignKey("Specialite_id_FK")]
        public Specialite Ref_Specialite { get; set; }
    }
}
