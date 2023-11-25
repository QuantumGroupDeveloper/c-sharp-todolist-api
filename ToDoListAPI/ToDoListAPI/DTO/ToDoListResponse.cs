namespace ToDoListAPI.DTO
{
    /// <summary>
    /// レスポンス用DTO
    /// </summary>
    public class ToDoListResponse
    {
        /// <summary>ID</summary>
        public int Id { get; set; }

        /// <summary>タイトル</summary>
        public string Title { get; set; } = null!;

        /// <summary>詳細</summary>
        public string? Detail { get; set; }

        /// <summary>場所</summary>
        public string? Place { get; set; }

        /// <summary>期限</summary>
        public DateTime? Deadline { get; set; }

        /// <summary>備考</summary>
        public string? Remarks { get; set; }

        /// <summary>期限切れ判定</summary>
        public bool IsOverdue {  get; set; }
    }
}
