using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Interfaces;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        private List<Account> _accounts = new List<Account>();

        private string path = @"C:\Users\John\Desktop\SoftwareGuild\C#\Badge 2\Milestone 2\SG - Bank\SGBank.Data\Accounts.txt";

        public Account LoadAccount(string AccountNumber)
        {
            string[] rows = File.ReadAllLines(path);
            for (int i = 0; i < rows.Length; i++)
            {
                string[] columns = rows[i].Split(',');
                Account a = new Account();
                a.AccountNumber = columns[0];
                a.Name = columns[1];
                a.Balance = Int32.Parse(columns[2]);
                if (columns[3] == "Free")
                {
                    a.Type = AccountType.Free;
                }
                if (columns[3] == "Basic")
                {
                    a.Type = AccountType.Basic;
                }
                if (columns[3] == "Premium")
                {
                    a.Type = AccountType.Premium;
                }
                _accounts.Add(a);
            }
            foreach (var item in _accounts)
            {
                if (AccountNumber == item.AccountNumber)
                {
                    return item;
                }
            }
            return null;
        }

        public void SaveAccount(Account account)
        {
            using (StreamWriter writer = new StreamWriter(path))
            foreach (var item in _accounts)
                {

                    writer.WriteLine(item.AccountNumber + "," + item.Name + "," + item.Balance + "," + item.Type);
                }
        }
    }
}
