using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practice_12_october.Models
{
    public class HealthRecord
    {
        [Key]
        public int H_RecordId { get; set; }

        public DateTime RecordDate { get; set; }
        public DateTime F_Vaccine { get; set; }
        public DateTime L_Vaccine { get; set; }
        public DateTime Treatment { get; set; }
        public string Health_Condition { get; set; }



        [ForeignKey("ManageCow")]
        public int Tag_Number { get; set; } 

        public ManageCow ManageCow { get; set; }
    }
}