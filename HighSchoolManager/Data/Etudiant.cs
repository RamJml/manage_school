using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Etudiant
    {
        [Key]
        public string Id { get; set; }
        public string Etudiant_nom { get; set; }
        public string Etudiant_prenom { get; set; }
        public string Etudiant_contact_parent { get; set; }


        public int Groupe_id_FK { get; set; }
        [ForeignKey("Groupe_id_FK")]
        public Groupe Ref_Groupe { get; set; }
    }
}
