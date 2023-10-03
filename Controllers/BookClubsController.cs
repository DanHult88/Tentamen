using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemTenta.Models;
using HemTenta;



namespace HemTenta.Controllers
{
    public class BookClubsController : Controller
    {
        public readonly ApplicationContext Context;
        public BookClubsController(ApplicationContext context)
        {
            Context = context;
        }
        public IActionResult Index()
        {


            List<BookClub> bookClubs = Context.BookClubs.Include(bc => bc.users).ToList();

            return View(bookClubs);


        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Delete(int Id)
        {
            BookClub bookClub = Context.BookClubs.FirstOrDefault(y => y.Id == Id);
            Context.Remove(bookClub);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteUser(int bookClubId, int userId)
        {
            var bookClub = Context.BookClubs.Include(bc => bc.users).FirstOrDefault(bc => bc.Id == bookClubId);

            var userToRemove = bookClub.users.FirstOrDefault(u => u.Id == userId);


            bookClub.users.Remove(userToRemove);

            Context.SaveChanges();

            return RedirectToAction(nameof(Edit), new { Id = bookClubId });
        }

        [HttpPost]
        public IActionResult AddUser(string User1, string User2, string User3, int Id)
        {
            var bookClub = Context.BookClubs.Include(bc => bc.users).FirstOrDefault(bc => bc.Id == Id);

            User user1 = Context.Users.FirstOrDefault(u => u.Name == User1);
            User user2 = Context.Users.FirstOrDefault(u => u.Name == User2);
            User user3 = Context.Users.FirstOrDefault(u => u.Name == User3);

            if (user1 != null)
            {
                bookClub.users.Add(user1);
            }
            if (user2 != null)
            {
                bookClub.users.Add(user2);
            }
            if (user3 != null)
            {
                bookClub.users.Add(user3);
            }

            Context.SaveChanges();
            return RedirectToAction(nameof(Edit), new { Id });
        }

        [HttpPost]
        public IActionResult ChangeName(string Name, int Id)
        {
            var bookClub = Context.BookClubs.FirstOrDefault(bc => bc.Id == Id);
            bookClub.Name = Name;
            Context.Update(bookClub);
            Context.SaveChanges();
            return RedirectToAction(nameof(Edit), new { Id });
        }

        public IActionResult Edit(int Id)
        {
            BookClub bookClub = Context.BookClubs.Include(bc => bc.users).FirstOrDefault(bc => bc.Id == Id);

            return View(bookClub);
        }







        [HttpPost]
        public IActionResult Create(string Name, string User1, string User2, string User3, string User4, string User5, string User6)
        {
            BookClub bookClub = new BookClub();
            bookClub.Name = Name;
            Context.BookClubs.Add(bookClub);

            List<User> users = new List<User>();
            User user1 = Context.Users.FirstOrDefault(u => u.Name == User1);

            User user2 = Context.Users.FirstOrDefault(u => u.Name == User2);

            User user3 = Context.Users.FirstOrDefault(u => u.Name == User3);

            User user4 = Context.Users.FirstOrDefault(u => u.Name == User4);

            User user5 = Context.Users.FirstOrDefault(u => u.Name == User5);

            User user6 = Context.Users.FirstOrDefault(u => u.Name == User6);

            if (user1 != null)
            {
                users.Add(user1);
            }
            if (user2 != null)
            {
                users.Add(user2);
            }
            if (user3 != null)
            {
                users.Add(user3);
            }
            if (user4 != null)
            {
                users.Add(user4);
            }
            if (user5 != null)
            {
                users.Add(user5);
            }
            if (user6 != null)
            {
                users.Add(user6);
            }

            bookClub.users = users;

            Context.SaveChanges();

            return View();
        }

    }
}
