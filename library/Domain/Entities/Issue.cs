
namespace Library.Domain.Entities;

public class Issue
{
    
      public int Id { get; set; }
        public int BookId { get; set; }
        public string MemberNumber { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; }
}