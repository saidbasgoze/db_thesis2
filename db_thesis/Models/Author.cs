
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;



namespace db_thesis.Models;



public class Author
{
	[Key]
	public int AuthorId { get; set; }

	[Required]
	public int PersonId { get; set; }

	[ForeignKey("PersonId")]
	public Person Person { get; set; }

    
    public virtual ICollection<Thesis> Theses { get; set; } = new List<Thesis>();
}









