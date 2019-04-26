using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Option
    {

        [Key]
        public int Option_id { get; set; }
        public string Option_designation { get; set; }


        public int Niveau_id_FK { get; set; }
        [ForeignKey("Niveau_id_FK")]
        public Niveau Ref_Niveau { get; set; }
    }
}
