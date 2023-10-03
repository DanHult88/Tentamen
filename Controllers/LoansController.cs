using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemTenta.Models;
using HemTenta;


namespace HemTenta.Controllers
{
    public class LoansController : Controller
    {
        public readonly ApplicationContext Context;
        public LoansController(ApplicationContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {
            List<Loan> Loans = Context.Loans.ToList();
            return View(Loans);
        }

        public IActionResult Add()
        {
            return View();
        }

        

        public IActionResult Details(int Id)
        {
            Loan bookloan = Context.Loans.Include(l => l.Book).Include(l => l.User).FirstOrDefault(l => l.Id == Id);
            LoanDetailsViewModel viewModel = new LoanDetailsViewModel
            {
                User = bookloan.User,

                Book = bookloan.Book,

                Loan = bookloan
            };

            return View(viewModel);
        }

        public IActionResult Delete(int Id)
        {
            Loan loan = Context.Loans.FirstOrDefault(l => l.Id == Id);

            Context.Loans.Remove(loan);

            Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Add(string LoanDate, string DueDate, int BookId, string Name, string LastName)
        {
            var book = Context.Books.Include(b => b.Loans).FirstOrDefault(b => b.Id == BookId);
            var user = Context.Users.Include(b => b.Loans).FirstOrDefault(u => u.Name == Name && u.LastName == LastName);
            Loan newLoan = new Loan();
            newLoan.LoanDate = LoanDate;
            newLoan.DueDate = DueDate;

            if (user == null)
            {
                return View();
            }
            if (book == null)
            {
                return View();
            }

            Context.Loans.Add(newLoan);

            book.Loans.Add(newLoan);

            user.Loans.Add(newLoan);

            book.CheckedOut = true;

            book.Inhouse = false;

            Context.Books.Update(book);

            Context.SaveChanges();

            return View();

        }
    }
}
