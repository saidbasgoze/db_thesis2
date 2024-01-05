using System.ComponentModel.DataAnnotations;

namespace db_thesis.Models
{
    public class University
    {
        [Key]
        public int UniversityId { get; set; }

        [StringLength(70)]
        public string UniversityName { get; set; } = null!;
    }
}
