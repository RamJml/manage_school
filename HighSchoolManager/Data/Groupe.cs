using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HighSchoolManager.Data
{
    public class Groupe
    {

        [Key]
        public int Groupe_id { get; set; }
        public string Groupe_designation { get; set; }


        public int Option_id_FK { get; set; }
        [ForeignKey("Option_id_FK")]
        public Option Ref_Option { get; set; }
    }
}
