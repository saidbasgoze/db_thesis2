using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace db_thesis.Models;


public class Person
{
    [Key]
    public int PersonId { get; set; }

    [Required]
    [StringLength(35)]
    public string Name { get; set; }

   








}
