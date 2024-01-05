using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db_thesis.Models
{
    public class Institue
    {
        [Key]
        public int InstitueId { get; set; }

        [StringLength(50)]
        public string InstitueName { get; set; } = null!;

        [Required]
        public int UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public University University { get; set; }
    }
}
