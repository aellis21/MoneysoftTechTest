using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneysoftTechTest
{
    class QuestionFive
    {
        static void Main()
        {
            var test = new QuestionFive();
            var partOne = test.PartOne(new List<FinancialAccount>()
            {

            });
        }

        //this is assuming the list of financial accounts all belong to the same user
        public double PartOne(List<FinancialAccount> accounts)
        {
            return accounts.Select(a => a.Balance).Sum();

            //If .Sum() wasnt an option, then the following is what I would write
            //var result = 0.0;
            //foreach (var account in accounts)
            //{
            //    result += account.Balance;
            //}
            //return result;
        }

        //this is assuming the list of financial accounts do not all belong to the same user
        public double PartOneAlternate(List<FinancialAccount> accounts, int userId)
        {
            return accounts.Where(a => a.UserId == userId).Select(a => a.Balance).Sum();
        }

        //this is assuming the list of financial accounts and transactions all belong to the same user
        public double PartThree(DateTime date, List<FinancialAccount> accounts, List<Transaction> transactions)
        {
            var currentBalance = PartOne(accounts);
            if (date.Date == DateTime.Now.Date)
            {
                return currentBalance;
            }

            var transactionsToRevert = transactions.Where(t => t.TransactionDate.Date > date.Date);

            foreach (var transaction in transactionsToRevert)
            {
                if (transaction.IsOutgoingTransaction)
                {
                    currentBalance += transaction.Amount;
                }
                else
                {
                    currentBalance -= transaction.Amount;
                }
            }

            return currentBalance;
        }

    }
}
