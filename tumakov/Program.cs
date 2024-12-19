using System.Security.Principal;

namespace tumakov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Task3();
            Task4();
        }

        //В классе банковский счет, созданном в предыдущих упражнениях, удалить
        //методы заполнения полей.Вместо этих методов создать конструкторы. Переопределить
        //конструктор по умолчанию, создать конструктор для заполнения поля баланс, конструктор
        //для заполнения поля тип банковского счета, конструктор для заполнения баланса и типа
        //банковского счета. Каждый конструктор должен вызывать метод, генерирующий номер
        //счета.
        static void Task1()
        {
            Console.WriteLine("Упражнение 9.1");
            BankAccount account1 = new BankAccount();
            BankAccount account2 = new BankAccount(AccountType.Сберегательный);
            account1.Info();
            account2.Info();
            account1.Transfer(account2, 200);
            account1.Info();
            account2.Info();
        }
        //Создать новый класс BankTransaction, который будет хранить информацию
        //о всех банковских операциях.При изменении баланса счета создается новый объект класса
        //BankTransaction, который содержит текущую дату и время, добавленную или снятую со
        //счета сумму.
        static void Task2()
        {
            Console.WriteLine("Упражнение 9.2");
            BankAccount account = new BankAccount();

            // Выполняем операции с депозитами
            Console.WriteLine("Депозит на счет: 1000");
            account.Popolnenie(1000);

            // Выполняем операции со снятием
            Console.WriteLine("Снятие со счета: 300");
            account.Withdraw(300);
        }
        //В классе банковский счет создать метод Dispose, который данные о
        //проводках из очереди запишет в файл.Не забудьте внутри метода Dispose вызвать метод
        //GC.SuppressFinalize, который сообщает системе, что она не должна вызывать метод
        //завершения для указанного объекта.
        static void Task3()
        {
            Console.WriteLine("Упражнение 9.3");
            using (var account = new BankAccount(1000))
            {
                account.Popolnenie(500);
                account.Withdraw(100);
                account.Info();
            }
        }
        //В класс Song(из домашнего задания 8.2) добавить следующие
        //конструкторы:
        //1) параметры конструктора – название и автор песни, указатель на предыдущую песню
        //инициализировать null.
        //2) параметры конструктора – название, автор песни, предыдущая песня.В методе Main
        //создать объект mySong.Возникнет ли ошибка при инициализации объекта mySong
        //следующим образом: Song mySong = new Song();
        static void Task4()
        {
            Console.WriteLine("Домашнее упражнение 9.1");
            Song mySong = new Song();
            mySong.Info(); 
            Song anotherSong = new Song("Гламур", "uniqe, nkeeei, ARTEM SHILOVETS, Wipo");
            anotherSong.Info(); 
            Song previousSong = new Song("Маленький", "Дайте танк (!)");
            Song myNextSong = new Song("Tearz", "PHARAOH", previousSong);
            myNextSong.Info(); 
        }
    }
}
