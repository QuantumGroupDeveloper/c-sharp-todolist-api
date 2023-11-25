﻿namespace ToDoListAPI.DTO
{
    public class ToDoListRequest
    {
        public string Title { get; set; } = null!;

        public string? Detail { get; set; }

        public string? Place { get; set; }

        public DateTime? Deadline { get; set; }

        public string? Remarks { get; set; }
    }
}