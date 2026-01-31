
using Library.Domain.Entities;
namespace Library.Application.Interfaces
{

    public interface IIssueRepository
    {
        List<Issue> GetAll();
        Issue GetById(int id);
        void Add(Issue issue);
        void Update(Issue issue);
        List<Issue> GetActiveIssues();
        List<Issue> GetByMemberNumber(string memberNumber);
    }

}