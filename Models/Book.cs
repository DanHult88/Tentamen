namespace HemTenta.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Author> Author { get; set; }

        public string ISBN { get; set; }

        public List<Genre> Genres { get; set; }

        public bool? Inhouse { get; set; }

        public bool? CheckedOut { get; set; }

        public List<Loan> Loans { get; set; }
    }
}
