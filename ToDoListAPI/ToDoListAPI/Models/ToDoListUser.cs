using System;
using System.Collections.Generic;

namespace ToDoListAPI.Models;

public partial class ToDoListUser
{
    public int Id { get; set; }

    public int ToDoListId { get; set; }

    public int UserId { get; set; }

    public byte Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ToDoList ToDoList { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
