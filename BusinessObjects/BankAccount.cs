using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class BankAccount
    {
        public BankAccount()
        {

        }

        public BankAccount(int bankAccountID, string number, string bankAccountName, string releaseDate, int bankID)
        {
            this.bankAccountID = bankAccountID;
            this.number = number;
            this.bankAccountName = bankAccountName;
            this.releaseDate = releaseDate;
            this.BankID = bankID;
        }
        public BankAccount(int bankAccountID, string number, string bankAccountName, string releaseDate)
        {
            this.bankAccountID = bankAccountID;
            this.number = number;
            this.bankAccountName = bankAccountName;
            this.releaseDate = releaseDate;

        }

        public int bankAccountID { get; set; }
        public string number { get; set; }
        public string bankAccountName { get; set; }
        public string releaseDate { get; set; }
        public int BankID { get; set; }
        public virtual Bank Bank { get; set; }
    }
}
