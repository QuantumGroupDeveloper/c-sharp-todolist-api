using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListAPI.Models;

public partial class ToDoList
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Detail { get; set; }

    public string? Place { get; set; }

    public DateTime? Deadline { get; set; }

    public string? Remarks { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ToDoListUser> ToDoListUsers { get; set; } = new List<ToDoListUser>();
}
