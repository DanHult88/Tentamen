﻿namespace HemTenta.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string PhoneNumber { get; set; }
        public List<Loan> Loans { get; set; }

        public List<BookClub> BookClubs { get; set; }
    }
}
