using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneysoftTechTest
{
    class QuestionThree
    {
        //The user confirms a financial transaction
        public Transaction CheckForTransfer(FinancialAccount sendingAccount, double amount)
        {
            //retrieve data from db
            List<FinancialAccount> userAccounts = accountRepository.GetUserAccounts();

            var preTransferAccountBalances = new Dictionary<int, double>();
            foreach (var account in userAccounts.Where(a => a.Id != sendingAccount.Id)) //dont include account that money is being sent from
            {
                preTransferAccountBalances.Add(account.Id, account.Balance); //store the id and balance of each account prior to transfer
            }

            //complete the transaction
            Transaction transaction = SendFinances(sendingAccount, amount);

            userAccounts = accountRepository.GetUserAccounts();

            //find an account that has had its balance updated by the same amount that was sent from the other account
            FinancialAccount accountTransferredTo = null;
            foreach (var account in preTransferAccountBalances)
            {
                accountTransferredTo = userAccounts.FirstOrDefault(a => a.Id == account.Key);
                if (account.Value == accountTransferredTo.Balance - amount)
                {
                    break;
                }
                accountTransferredTo = null;
            }

            if (accountTransferredTo != null)
            {
                //this is just an estimation of what data is set when a transfer is detected
                transaction.Category = "Transfers";
            }

            return transaction;
        }
    }
}
