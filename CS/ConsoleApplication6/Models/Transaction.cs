using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneysoftTechTest
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public string TransactionType { get; set; }
        public int FinancialAccountId { get; set; }
        public DateTime TransactionDate { get; set; }

        //This is for Question 5 Part 3
        public bool IsOutgoingTransaction { get; set; }
    }
}
