
// WebUI/Controllers/IssuesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Application.Services;
using Library.Models;

namespace Library.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IssueService _issueService;
        private readonly BookService _bookService;

        public IssuesController(IssueService issueService, BookService bookService)
        {
            _issueService = issueService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            var issues = _issueService.GetAllIssues();
            var books = _bookService.GetAllBooks();
            
            ViewBag.Books = books;
            return View(issues);
        }

        public IActionResult IssueBook()
        {
            Console.WriteLine("IssueBook GET method called");
            var availableBooks = _bookService.GetAvailableBooks();
            Console.WriteLine($"Available books count: {availableBooks.Count}");
            ViewBag.Books = new SelectList(availableBooks, "Id", "Title");
            Console.WriteLine("ViewBag.Books populated");
            return View();
        }
[HttpPost]
public IActionResult IssueBook(IssueBookViewModel model)
{
   

    if (ModelState.IsValid)
    {
        _issueService.IssueBook(model.BookId, model.MemberNumber);
        return RedirectToAction("Index");
    }

    var availableBooks = _bookService.GetAvailableBooks();
    ViewBag.Books = new SelectList(availableBooks, "Id", "Title");
    return View(model);
}

        public IActionResult ReturnBook(int id)
        {
            _issueService.ReturnBook(id);
            return RedirectToAction("Index");
        }

        public IActionResult ActiveIssues()
        {
            var issues = _issueService.GetActiveIssues();
            var books = _bookService.GetAllBooks();
            
            ViewBag.Books = books;
            return View(issues);
        }

        public IActionResult SearchByMember(string memberNumber)
        {
            if (string.IsNullOrEmpty(memberNumber))
            {
                return RedirectToAction("Index");
            }

            var issues = _issueService.GetIssuesByMemberNumber(memberNumber);
            var books = _bookService.GetAllBooks();
            
            ViewBag.Books = books;
            ViewBag.MemberNumber = memberNumber;
            return View("Index", issues);
        }
    }
}