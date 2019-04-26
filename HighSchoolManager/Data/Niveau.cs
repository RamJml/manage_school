using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Niveau
    {
        [Key]
        public int Niveau_id { get; set; }
        public string Niveau_designation { get; set; }

    }
}
