using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Enseignant:IdentityUser
    {
        
        public string Enseignant_nom { get; set; }
        public string Enseignant_prenom { get; set; }


        public int Specialite_id_FK { get; set; }
        [ForeignKey("Specialite_id_FK")]
        public Specialite Ref_Specialite { get; set; }
    }
}
