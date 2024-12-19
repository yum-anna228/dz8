namespace dz
{
    /// <summary>
    /// Перечисление статуса проекта
    /// </summary>
    public enum ProjectStatus
    {
        Проект,
        Исполнение,
        Закрыт
    }
    /// <summary>
    /// перечисление статуса задачи
    /// </summary>
    public enum TaskStatus
    {
        Назначена,
        ВРаботе,
        НаПроверке,
        Выполнена
    }
    //Написать программу, содержащую решение следующих задач:
    //Task Manager
    //У команды из IT компании существует программа, где они контролируют свои текущие
    //задачи – что-то типа Task Manager.Существует проекты по каждому проекту создаются
    //задачи.
    //Сущность Проект может быть в трех статусах: Проект, Исполнение, Закрыт.
    //У проекта есть:

    //● описание проекта,
    //● сроки выполнения
    //● инициатор проекта(заказчик)
    //● человек, ответственный за проект(тимлид)
    //● задачи по проекту
    //● статус
    //Задачи по проекту назначает только один человек(тимлид) Сущность Задача может быть в
    //четырех статусах: Назначена, В работе, На проверке, Выполнена.
    //У задачи есть:
    //● описание задачи,
    //● сроки задачи,
    //● инициатор задачи.
    //● исполнитель,
    //● статус задачи
    //● отчет(ы) по задаче
    //Сущность Отчёт:
    //● текст отчета,
    //● дата выполнения,
    //● исполнитель.
    //Описание процесса:
    //Создается проект с определенными сроками.Далее ответственный за проект создает задачи
    //по этому проекту.
    //Задачи можно создавать только в статусе проекта «Проект». После того, как все проекты
    //назначены необходимо перевести проект в статус «Исполнение».
    //Задачи приходят исполнителям в статусе «Назначена». Исполнитель может взять задачу в
    //работу, делегировать ее другому человеку или отклонить. Если человек берет задачу в
    //работу, то задача переходит в статус «В работе», если он делегировал эту задачу, то меняется
    //исполнитель, а статус становится «Назначена», при отклонении задачи, задача не имеет
    //Исполнителя и Человек, назначивший задачу, может ее назначить кому-то другому или
    //удалить эту задачу вообще.По каждой задаче создается отчет по выполненной работе.
    //Отчет приходит инициатору на проверку.
    //Отчет можно утвердить или вернуть на доработку.Проект считается закрытым, если по
    //нему выполнены все задачи. Необходимо создать 10 человек команды, каждый человек
    //должен получить минимум одну задачу.
    internal class Program
    {
        static void Main(string[] args)
        {
            var employees = new List<Employee>
        {
            new Employee("Аня"),
            new Employee("Маша"),
            new Employee("Петя"),
            new Employee("Ксюша"),
            new Employee("Егор"),
            new Employee("Эльнар"),
            new Employee("Игорь"),
            new Employee("Софья"),
            new Employee("Витя"),
            new Employee("Кира")
        };
            var projectInitiator = employees[0]; 
            var teamLead = employees[1]; 
            var project = new Project("Разработка веб-сайта", DateTime.Now.AddDays(30), projectInitiator, teamLead);

            for (int i = 2; i < employees.Count; i++)
            {
                var task = new Task($"Задача {i - 1}", DateTime.Now.AddDays(30), projectInitiator);
                project.AddTask(task);
                Console.WriteLine($"Добавлена {task.Opisanie} в проект");
            }

            try
            {
                project.StartProject();
                Console.WriteLine($"Статус проекта: {project.Status}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (var task in project.Tasks)
            {
                var assignee = employees[new Random().Next(2, employees.Count)]; 
                task.StartWork(assignee);
                Console.WriteLine($"{assignee.Name} взял '{task.Opisanie}' в работу");

                task.CompleteTask($"Отчёт для  '{task.Opisanie}'  {assignee.Name}");
                Console.WriteLine($"'{task.Opisanie}' завершается отчётом");

                task.ApproveReport();
                Console.WriteLine($"Отчёт для  '{task.Opisanie}' одобрен");
            }
            try
            {
                project.CloseProject();
                Console.WriteLine($"Статус проекта: {project.Status}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    
    
}
