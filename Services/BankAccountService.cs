using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IBankAccountRepo repo;
        public BankAccountService()
        {
            repo = new BankAccountRepo();
        }

        public BankAccount GetBankAccountbyId(int id)
        {
            return repo.GetBankAccountbyId(id);
        }

        public List<BankAccount> GetBankAccounts()
        {
            return repo.GetBankAccounts();
        }

        public bool ValidateBankAccount(int bankID, string number, string name, string releaseDate)
        {
            return repo.ValidateBankAccount(bankID, number, name, releaseDate);
        }
    }
}
