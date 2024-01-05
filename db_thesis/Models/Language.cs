using System.ComponentModel.DataAnnotations;

namespace db_thesis.Models
{
    public class Language
    {
        [Key]
        public int LanguageId { get; set; }

        [StringLength(45)]
        public string LanguageName { get; set; } = null!;
    }
}
