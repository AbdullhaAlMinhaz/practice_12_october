using System.ComponentModel.DataAnnotations;

namespace practice_12_october.Models
{
    public class ManageCow
    {
        [Key]
        public int Tag_Number { get; set; }
        public string Name { get; set; }
        public string Breeds { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string gender { get; set; }
        public string Status { get; set; }

        public ICollection<HealthRecord> HealthRecords { get; set; }

    }
}
