namespace ToDoListAPI.DTO
{
    /// <summary>
    /// リクエスト受け取り用DTO
    /// </summary>
    public class ToDoListRequest
    {
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
    }
}
