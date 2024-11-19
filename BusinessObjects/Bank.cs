using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public partial class Bank
    {

        public Bank()
        {
            BankAccounts = new HashSet<BankAccount>();
        }
        public Bank(int bankID, string bankName)
        {
            BankID = bankID;
            BankName = bankName;
        }

        public Bank(int bankID, string bankName, ICollection<BankAccount> bankAccounts)
        {
            BankID = bankID;
            BankName = bankName;
            BankAccounts = bankAccounts;
        }



        public int BankID { get; set; }
        public string BankName { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
    }
}
