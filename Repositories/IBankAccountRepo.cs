using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBankAccountRepo
    {
        List<BankAccount> GetBankAccounts();
        BankAccount GetBankAccountbyId(int id);
        bool ValidateBankAccount(int bankID, string number, string name, string releaseDate);
    }
}
