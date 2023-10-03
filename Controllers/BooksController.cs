using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemTenta.Models;
using HemTenta;


namespace HemTenta.Controllers
{
    public class BooksController : Controller
    {
        public readonly ApplicationContext Context;
        public BooksController(ApplicationContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            List<Book> AllBooks = Context.Books.Include(b => b.Genres).Include(b => b.Author).ToList();
            return View(AllBooks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Title, string Author, string ISBN, string Genre, bool Inhouse, bool CheckedOut)
        {
            // kollar om genren existerar
            Genre genre = Context.Genres.FirstOrDefault(g => g.Name == Genre);
            if (genre == null)
            {
                // skapar en ny genre om den inte redan existerar
                genre = new Genre { Name = Genre };
                Context.Genres.Add(genre);
            }

            // kollar om author existerar
            Author author = Context.Author.FirstOrDefault(a => a.Name == Author);
            if (author == null)
            {
                // skapar en ny author om den inte existerar
                author = new Author { Name = Author };
                Context.Author.Add(author);
            }

 

            Book newBook = new Book();
            newBook.Title = Title;
            newBook.ISBN = ISBN;
            newBook.Inhouse = Inhouse;
            newBook.CheckedOut = CheckedOut;

            Context.Books.Add(newBook);

            // Associerar den nya boken med genre och author
            newBook.Genres = new List<Genre> { genre };
            newBook.Author = new List<Author> { author };

            Context.SaveChanges();

            return View();
        }
   



        public IActionResult Delete(int Id)
        {
            Book Book = Context.Books.FirstOrDefault(b => b.Id == Id);
            Context.Remove(Book);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            Book Book = Context.Books.FirstOrDefault(b => b.Id == Id);
            return View(Book);

        }


        [HttpPost]
        public IActionResult Edit(int Id, string Title, string Author, string ISBN, string Genre, bool Inhouse, bool CheckedOut)
        {
            Book book = Context.Books.FirstOrDefault(b => b.Id == Id);
            book.Title = Title;

            book.ISBN = ISBN;
            book.Inhouse = Inhouse;
            book.CheckedOut = CheckedOut;

            if (Inhouse == true && CheckedOut == true)
            {
                return RedirectToAction(nameof(Index));
            }
            if (Inhouse == false && CheckedOut == false)
            {
                return RedirectToAction(nameof(Index));
            }

            Context.Books.Update(book);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Search()
        {
            return View();
        }



        [HttpPost]
        public IActionResult SearchBooks(string Genre)
        {
            List<Book> books = Context.Books.Where(b => b.Genres.Any(g => g.Name == Genre)).ToList();
            ViewBag.GenreName = Genre;
            return View(books);
        }
    }
}
