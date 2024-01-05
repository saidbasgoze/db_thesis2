using System.ComponentModel.DataAnnotations;

namespace db_thesis.Models
{
    public class ThesisType
    {
        [Key]
        public int TypeId { get; set; }

        [StringLength(60)]
        public string TypeName { get; set; } = null!;
    }
}
