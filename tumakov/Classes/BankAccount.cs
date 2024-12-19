using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tumakov
{
    /// <summary>
    /// Перечисление типов счёта
    /// </summary>
    public enum AccountType
    {
        Текущий,
        Сберегательный
    }
    public class BankAccount : IDisposable
    {
        private static int counter = 1000;
        private int number;
        private decimal balans;
        private readonly AccountType accountType;
        private readonly Queue<BankTransaction> transactions;
        private bool disposed = false;

        /// <summary>
        /// конструктор
        /// </summary>
        public BankAccount()
        {
            counter++;
            this.number = counter;
            this.balans = 0;
            this.accountType = AccountType.Текущий;
            transactions = new Queue<BankTransaction>();
        }
        /// <summary>
        /// Конструктор для заполнения поля баланс
        /// </summary>
        public BankAccount(decimal initialBalans)
        {
            counter++;
            this.number = counter;
            this.balans = initialBalans;
            this.accountType = AccountType.Текущий;
            transactions = new Queue<BankTransaction>();
        }
        /// <summary>
        /// конструктор для заполнения типа банковского счёта
        /// </summary>
        public BankAccount(AccountType accountType)
        {
            counter++;
            this.number = counter;
            this.balans = 0;
            this.accountType = accountType;
            transactions = new Queue<BankTransaction>();
        }
        /// <summary>
        /// конструктор для заполнения баланса и типа банковского счёта
        /// </summary>
        public BankAccount(decimal initialBalans, AccountType accountType)
        {
            counter++;
            this.number = counter;
            this.balans = initialBalans;
            this.accountType = accountType;
            transactions = new Queue<BankTransaction>();
        }
        /// <summary>
        /// Метод пополнения счёта
        public void Popolnenie(decimal symma)
        {
            if (symma > 0)
            {
                balans += symma;
                Console.WriteLine($"Произошло пополнение на {symma}. Новый баланс {balans}");
                transactions.Enqueue(new BankTransaction(symma));
            }
            else
            {
                Console.WriteLine("Сумма не может быть отрицательной!");
            }
        }
        /// <summary>
        /// Метод вывода со счёта
        /// </summary>
        public void Withdraw(decimal symma)
        {
            if (symma <= 0)
            {
                Console.WriteLine("Сумма вывода должна быть положительной");
                return;
            }
            if (symma > balans)
            {
                Console.WriteLine("У вас недостаточно средств");
            }
            else
            {
                balans -= symma;
                Console.WriteLine($"Произошел вывод средств на {symma}. Новый баланс {balans}");
                transactions.Enqueue(new BankTransaction(-symma));
            }
        }
        /// <summary>
        /// Метод, который отправляет сумму с одного счёта на другой
        /// </summary>
        public void Transfer(BankAccount targetAccount, decimal symma)
        {
            if (targetAccount == null)
            {
                throw new ArgumentNullException(nameof(targetAccount), "Целевой счет не может быть null.");
            }
            if (symma <= 0)
            {
                throw new ArgumentException("Сумма перевода должна быть положительной.");
            }
            Withdraw(symma); 
            targetAccount.Popolnenie(symma); 
        }
        /// <summary>
        /// Метод, который выводит информацию
        /// </summary>
        public void Info()
        {
            Console.WriteLine($"Номер счета: {number}");
            Console.WriteLine($"Баланс: {balans}");
            Console.WriteLine($"Тип счета: {accountType}");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"Дата: {transaction.TransactionDate}, Сумма: {transaction.Symma}");
            }
        }
        /// <summary>
        /// метод для записи транзакций в файл
        /// </summary>
        public void Dispose()
        {
            using (var writer = new System.IO.StreamWriter("../../../транзакции.txt", true))
            {
                while (transactions.Count > 0)
                {
                    var transaction = transactions.Dequeue();
                    writer.WriteLine($"{transaction.TransactionDate}: {transaction.Symma}");
                }
            }

            GC.SuppressFinalize(this);
        }
       
    }
}
