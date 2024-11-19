using BusinessObjects;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BankAccountRepo : IBankAccountRepo
    {


        public BankAccount GetBankAccountbyId(int id)
        {
            return BankAccountDAO.GetBankAccountById(id);
        }

        public List<BankAccount> GetBankAccounts()
        {
            return BankAccountDAO.GetBankAccounts();
        }

        public bool ValidateBankAccount(int bankID, string number, string name, string releaseDate)
        {
            return BankAccountDAO.ValidateBankAccount(bankID, number, name, releaseDate);
        }
    }
}
