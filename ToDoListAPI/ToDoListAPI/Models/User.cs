using System;
using System.Collections.Generic;

namespace ToDoListAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<ToDoListUser> ToDoListUsers { get; set; } = new List<ToDoListUser>();
}
