using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BankDAO
    {
        public BankDAO()
        {

        }
        public static List<Bank> GetBanks()
        {
            Bank bank1 = new Bank(1, "Vietcombank(VCB)");
            Bank bank2 = new Bank(2, "NCB");


            var listBank = new List<Bank>();
            try
            {
                listBank.Add(bank1);
                listBank.Add(bank2);


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listBank;

        }
    }
}
