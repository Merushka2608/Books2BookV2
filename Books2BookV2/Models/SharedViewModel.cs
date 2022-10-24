namespace Books2BookV2.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }   
        public string CommentText { get; set; } 
        public int bookId { get; set; }
        public int userId { get; set; }
        public int parentId { get; set; }
        public DateOnly datePosted { get; set; }
    }
}
