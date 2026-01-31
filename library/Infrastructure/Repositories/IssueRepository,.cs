

using Library.Application.Interfaces;
using Library.Domain.Entities;


namespace Library.Infrastructure.Repositories
{

    public class IssueRepository : IIssueRepository
    {
        private static List<Issue> _issues = new List<Issue>();
        private static int _nextId = 1;
        public List<Issue> GetAll()
        {
            return _issues;
        }

        public Issue GetById(int id)
        {
            return _issues.FirstOrDefault(i => i.Id == id);
        }

        public void Add(Issue issue)
        {
            issue.Id = _nextId++;
            _issues.Add(issue);
        }

        public void Update(Issue issue)
        {
            var existingIssue = GetById(issue.Id);
            if (existingIssue != null)
            {
                existingIssue.BookId = issue.BookId;
                existingIssue.MemberNumber = issue.MemberNumber;
                existingIssue.IssueDate = issue.IssueDate;
                existingIssue.ReturnDate = issue.ReturnDate;
                existingIssue.IsReturned = issue.IsReturned;
            }
        }

        public List<Issue> GetActiveIssues()
        {
            return _issues.Where(i => !i.IsReturned).ToList();
        }

        public List<Issue> GetByMemberNumber(string memberNumber)
        {
            return _issues.Where(i => i.MemberNumber == memberNumber).ToList();
        }

    }

}