using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HemTenta.Models;
using HemTenta;


namespace HemTenta.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationContext Context;


        public UsersController(ApplicationContext context)
        {
            Context = context;
        }

        public IActionResult Index()
        {
            List<User> Users = Context.Users.ToList();
            return View(Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Name, string LastName, string Address, string PhoneNumber)
        {
            User NewUser = new User();
            NewUser.Name = Name;
            NewUser.LastName = LastName;
            NewUser.Adress = Address;
            NewUser.PhoneNumber = PhoneNumber;

            Context.Users.Add(NewUser);
            Context.SaveChanges();
            return View();
        }

        public IActionResult Edit(int id)
        {
            User User = Context.Users.FirstOrDefault(x => x.Id == id);
            return View(User);

        }

        [HttpPost]
        public IActionResult Edit(int Id, string Name, string LastName, string Adress, string PhoneNumber)
        {
            User User = Context.Users.FirstOrDefault(x => x.Id == Id);
            User.Name = Name;
            User.LastName = LastName;
            User.Adress = Adress;
            User.PhoneNumber = PhoneNumber;
            Context.Users.Update(User);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {
            User User = Context.Users.FirstOrDefault(x => x.Id == Id);
            Context.Remove(User);
            Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchUser(string Name, string LastName)
        {
            User user = Context.Users.Include(u => u.Loans).ThenInclude(l => l.Book).FirstOrDefault(u => u.Name == Name && u.LastName == LastName);


            return View(user);
        }
    }
}
