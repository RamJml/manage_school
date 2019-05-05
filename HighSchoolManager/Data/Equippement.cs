using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Equippement
    {

        [Key]
        public int Equippement_id { get; set; }
        public string Equippement_designation { get; set; }


        public int TypeEquippement_id_FK { get; set; }
        [ForeignKey("TypeEquippement_id_FK")]
        public TypeEquippement Ref_TypeEquippement { get; set; }

        public int Salle_id_FK_equip { get; set; }
        [ForeignKey("Salle_id_FK_equip")]
        public Salle Ref_Salle_equip { get; set; }
    }
}
