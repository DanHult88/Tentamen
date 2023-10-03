namespace HemTenta.Models
{

    public class Loan
    {
        public int Id { get; set; }

        public string LoanDate { get; set; }

        public string DueDate { get; set; }

        public Book Book { get; set; }

        public User User { get; set; }
    }
}
