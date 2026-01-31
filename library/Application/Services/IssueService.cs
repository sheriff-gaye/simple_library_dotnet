
using Library.Application.Interfaces;
using Library.Domain.Entities;


namespace Library.Application.Services
{
    public class IssueService
    {
        private readonly IIssueRepository _issueRepository;
        private readonly IBookRepository _bookRepository;

        public IssueService(IIssueRepository issueRepository, IBookRepository bookRepository)
        {
            _issueRepository = issueRepository;
            _bookRepository = bookRepository;
        }



        public List<Issue> GetAllIssues()
        {
            return _issueRepository.GetAll();
        }

        public Issue GetIssueById(int id)
        {
            return _issueRepository.GetById(id);
        }

        public void IssueBook(int bookId, string memberNumber)
        {
            var book = _bookRepository.GetBookById(bookId);
            if (book != null && book.IsAvailable)
            {
                var issue = new Issue
                {
                    BookId = bookId,
                    MemberNumber = memberNumber,
                    IssueDate = DateTime.Now,
                    IsReturned = false
                };

                _issueRepository.Add(issue);
                book.IsAvailable = false;
                _bookRepository.Update(book);
            }
        }


        public void ReturnBook(int issueId)
        {
            var issue = _issueRepository.GetById(issueId);
            if (issue != null && !issue.IsReturned)
            {
                issue.ReturnDate = DateTime.Now;
                issue.IsReturned = true;
                _issueRepository.Update(issue);

                var book = _bookRepository.GetBookById(issue.BookId);
                if (book != null)
                {
                    book.IsAvailable = true;
                    _bookRepository.Update(book);
                }
            }
        }

        public List<Issue> GetActiveIssues()
        {
            return _issueRepository.GetActiveIssues();
        }

        public List<Issue> GetIssuesByMemberNumber(string memberNumber)
        {
            return _issueRepository.GetByMemberNumber(memberNumber);
        }


    }

}