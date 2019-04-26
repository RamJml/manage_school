using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Specialite
    {

        [Key]
        public int Specialite_id { get; set; }
        public string Specialite_designation { get; set; }
        
        

        [JsonIgnore]
        public virtual List<Matiere> Matieres_Specialite { get; set; }
    
        [JsonIgnore]
        public virtual List<Enseignant> Enseignant_Specialite { get; set; }
    
    }
}
