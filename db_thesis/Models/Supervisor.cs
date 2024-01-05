using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db_thesis.Models;


public class Supervisor
{
    [Key]
    public int SupervisorId { get; set; }

    [Required]
    public int PersonId { get; set; }

    [ForeignKey("PersonId")]

    public Person Person { get; set; }

    public List<Thesis> Thesisses { get; set; }


}
