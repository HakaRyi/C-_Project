using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBankAccountService
    {
        List<BankAccount> GetBankAccounts();
        BankAccount GetBankAccountbyId(int id);
        bool ValidateBankAccount(int bankID, string number, string name, string releaseDate);
    }
}
