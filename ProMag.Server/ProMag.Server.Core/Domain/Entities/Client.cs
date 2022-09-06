﻿using System.ComponentModel.DataAnnotations;

namespace ProMag.Server.Core.Domain.Entities;

public class Client : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public string Description { get; set; }

    public ICollection<ClientContact> Contacts { get; set; }

    public ICollection<Project> Projects { get; set; }
    
    public List<ProjectClient> ProjectClients { get; set; }
}

public class ClientContact : BaseEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string DisplayName { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string FullName { get; set; }

    public string Title { get; set; }

    public string Phone { get; set; }

    public string Email { get; set; }

    public string Notes { get; set; }

    [Required]
    public int ClientId { get; set; }

    public Client Client { get; set; }
}