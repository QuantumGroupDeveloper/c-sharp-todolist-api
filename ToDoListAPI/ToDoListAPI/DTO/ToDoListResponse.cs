namespace ToDoListAPI.DTO
{
    public class ToDoListResponse
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Detail { get; set; }

        public string? Place { get; set; }

        public DateTime? Deadline { get; set; }

        public string? Remarks { get; set; }

        public DateTime? ExcessTime { get; set; }


        public bool IsOverdue {  get; set; }
    }
}
