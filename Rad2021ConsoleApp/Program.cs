using Microsoft.EntityFrameworkCore;
using Rad2021ClassLibrary.Models;
using Rad2021ConsoleApp.Data;

class Program
{
    static void Main(string[] args)
    {
        int answer;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n----------------\n");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("\n1: List loans to approve, \n2:List Loan book, \n3:List invalid loans, \nExit ");

            answer = Convert.ToInt32(Console.ReadLine());

            switch (answer)
            {
                case 1:
                    list_loans_to_approve();
                    break;

                case 2:
                    list_loan_book();
                    break;

                case 3:
                    invalid_loans();
                    break;
            }
        }
    }
    static void list_loans_to_approve()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        using (var context = new Rad2022Context())
        {
            var loans = context.Loans
                .Include(l => l.Member)  
                .Where(l => l.Approved == false && l.ApprovedBy == null) 
                .ToList();

            foreach (var loan in loans)
            {
                Console.WriteLine(
                    $"Loan Application Date: {loan.ApplicationDate.ToShortDateString()}, " +
                    $"Loan Amount: €{loan.LoanAmount:F2}, " +
                    $"Member Name: {loan.Member.Name}, " +
                    $"Share Balance: €{loan.Member.ShareBalance:F2}"
                );
            }
        }
    }

    static void list_loan_book()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        using (var context = new Rad2022Context())
        {
            var members = context.Members
                .Include(m => m.Loan) 
                .Where(m => m.Loan.Any(l => l.RepaidInFull == false))
                .ToList();

            foreach (var member in members)
            {
                var unpaidLoans = member.Loan.Where(l => l.RepaidInFull == false);
                foreach (var loan in unpaidLoans)
                {
                    Console.WriteLine(
                        $"Member: {member.Name}, " +
                        $"Share Balance: €{member.ShareBalance:F2}, " +
                        $"Loan Amount: €{loan.LoanAmount:F2}, " +
                        $"Application Date: {loan.ApplicationDate.ToShortDateString()}, " +
                        $"Approval Date: {(loan.ApprovalDate?.ToShortDateString() ?? "Not Approved")}"
                    );
                }
            }
        }
    }

    static void invalid_loans()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        using (var context = new Rad2022Context())
        {
            var members = context.Members
                .Include(m => m.Loan)
                .Where(m => m.Loan.Any(l => l.LoanAmount > (m.ShareBalance * 2)))
                .ToList();

            foreach (var member in members)
            {
                var invalidLoans = member.Loan.Where(l => l.LoanAmount > (member.ShareBalance * 2));
                foreach (var loan in invalidLoans)
                {
                    Console.WriteLine(
                        $"Member: {member.Name}, " +
                        $"Share Balance: €{member.ShareBalance:F2}, " +
                        $"Loan Amount: €{loan.LoanAmount:F2}, " +
                        $"Application Date: {loan.ApplicationDate.ToShortDateString()}"
                    );
                }
            }
        }
    }
}