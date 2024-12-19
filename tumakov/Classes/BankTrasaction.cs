using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    public class BankTransaction
    {
        public DateTime TransactionDate;
        public decimal Symma;
        /// <summary>
        /// Конструктор
        /// </summary>
        public BankTransaction(decimal symma)
        {
            TransactionDate = DateTime.Now;
            Symma = symma;
        }
    }
}
