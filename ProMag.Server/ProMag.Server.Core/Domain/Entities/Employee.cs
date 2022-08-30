﻿using System.ComponentModel.DataAnnotations;

namespace ProMag.Server.Core.Domain.Entities;

public class Employee : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }

    public User UserAccount { get; set; }

    [Required, Display(Name = "Employee Code")]
    public string Code { get; set; }

    [Required, Display(Name = "Employee Name")]
    public string Name { get; set; }

    //
    public ICollection<TeamMember> Members { get; set; }
}