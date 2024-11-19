using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BankAccountDAO
    {
        private static List<BankAccount> listAccount;
        public BankAccountDAO()
        {

        }
        public static List<BankAccount> GetBankAccounts()
        {
            if (listAccount == null)
            {
                BankAccount account1 = new BankAccount(1, "1031329679", "Nguyen Van A", "0715", 1);
                BankAccount account2 = new BankAccount(2, "123456789", "Nguyen Van B", "0816", 2);
                listAccount = new List<BankAccount> { account1, account2 };

            }
            Console.WriteLine($"Room count: {listAccount.Count}"); //in số phòng
            return listAccount;
        }
        public static BankAccount GetBankAccountById(int id)
        {
            foreach (BankAccount r in listAccount.ToList())
            {
                if (r.bankAccountID == id)
                {
                    return r;
                }
            }
            return null;
        }
        public static bool ValidateBankAccount(int bankID, string number, string name, string releaseDate)
        {
            List<BankAccount> accounts = GetBankAccounts();
            BankAccount matchedAccount = accounts.FirstOrDefault(account =>
                account.bankAccountID == bankID && account.number == number
                && account.bankAccountName == name && account.releaseDate == releaseDate);

            if (matchedAccount != null)
            {
                return true;
            }
            else
            {
                Console.WriteLine("The input is wrong. Please check again!");
                return false;
            }
        }

    }
}
