using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class TypeEquippementMatiere
    {
        public int TypeEquippement_FK { get; set; }
        public int Matiere_FK { get; set; }
        [ForeignKey("Matiere_FK")]
        public Matiere Ref_Matiere { get; set; }
        [ForeignKey("TypeEquippement_FK")]
        public TypeEquippement Ref_TypeEquippement { get; set; }

    }
}
