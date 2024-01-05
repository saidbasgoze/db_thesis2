using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db_thesis.Models
{
    public class Thesis
    {
        [Key]
        public int ThesisId { get; set; }

        [Required]
        public int ThesisNo { get; set; }

		public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; } = null!;

        public int SupervisorId { get; set; }

        [ForeignKey("SupervisorId")]
        public virtual Supervisor Supervisor { get; set; } = null!;

        public int UniversityId { get; set; }

        [ForeignKey("UniversityId")]
        public virtual University University { get; set; } = null!;

        public int InstitueId { get; set; }

        [ForeignKey("InstitueId")]
        public virtual Institue Institue { get; set; } = null!;

        public int LanguageId { get; set; }

        [ForeignKey("LanguageId")]
        public virtual Language Language { get; set; } = null!;
       

        public int TypeId { get; set; }

        [ForeignKey("TypeId")]
        public virtual ThesisType ThesisType { get; set; } = null!;

        [StringLength(500)]
        public string ThesisTitle { get; set; } = null!;

        public string ThesisAbstract { get; set; } = null!;

		[StringLength(1000)]
		public string ThesisTopic { get; set; } = null!;

		public int NumberOfPages { get; set; }

        [Precision(0)]
        public DateTime SubmissionDate { get; set; }

       


    }
}
