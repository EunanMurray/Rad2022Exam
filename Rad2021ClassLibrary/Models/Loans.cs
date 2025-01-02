using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad2021ClassLibrary.Models
{
    public class Loans
    {
        public int LoanID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public double LoanAmount { get; set; }
        public DateTime ApprovalDate { get; set; }
        public bool Approved { get; set; }
        public string ApprovedBy { get; set; }

        public int MemberID { get; set; }
        public virtual Members Member { get; set; }
    }
}
