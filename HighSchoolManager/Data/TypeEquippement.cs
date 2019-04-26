using System.ComponentModel.DataAnnotations;

namespace HighSchoolManager.Data
{
    public class TypeEquippement
    {
        [Key]
        public int Type_Equippement_id { get; set; }
        public string Type_Equippement_designation { get; set; }

    }
}