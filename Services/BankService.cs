using BusinessObjects;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BankService : IBankService
    {
        private readonly IBankRepo repo;
        public BankService()
        {
            repo = new BankRepo();
        }
        public List<Bank> GetBanks()
        {
            return repo.GetBanks();
        }
    }
}
