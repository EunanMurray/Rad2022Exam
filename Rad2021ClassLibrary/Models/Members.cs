using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad2021ClassLibrary.Models
{
    public class Members
    {
        public int MemberID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int LoanID { get; set; }
        public virtual ICollection<Loans> Loan { get; set; }
    }
}
