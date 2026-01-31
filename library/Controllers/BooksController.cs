
using Microsoft.AspNetCore.Mvc;
using Library.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Library.Domain.Entities;


namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        private readonly CategoryService _categoryService;

        public BookController(BookService bookService, CategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var books = _bookService.GetAllBooks();
            var categories = _categoryService.GetAll();

            ViewBag.Categories = categories;
            return View(books);
        }

        public ActionResult Create()
        {
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View();
        } 

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.IsAvailable = true;
                _bookService.Add(book);
                return RedirectToAction("Index");
            }

             var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(book);
        }

        public ActionResult Edit(int id)
        {
            var book = _bookService.GetBookById(id);
            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", book.CategoryId);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _bookService.Update(book);
                return RedirectToAction("Index");
            }

            var categories = _categoryService.GetAll();
            ViewBag.Categories = new SelectList(categories, "Id", "Name", book.CategoryId);
            return View(book);
        }


        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }





    }

}