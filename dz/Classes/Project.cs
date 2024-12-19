using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    /// <summary>
    /// класс, который представляет проект
    /// </summary>
    public class Project
    {
        public string Opisanie { get; set; }
        public DateTime Deadline { get; set;}
        public Employee Initiator { get; set; }
        public Employee TeamLead { get; set; }
        public List<Task> Tasks { get; set; }
        public ProjectStatus Status { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        public Project(string opisanie, DateTime deadline, Employee initiator, Employee teamLead)
        {
            Opisanie = opisanie;
            Deadline = deadline;
            Initiator = initiator;
            TeamLead = teamLead;
            Tasks = new List<Task>();
            Status = ProjectStatus.Проект;
        }

        /// <summary>
        /// метод, который добавляет задачи в проект
        /// </summary>
        public void AddTask(Task task)
        {
            if (Status == ProjectStatus.Проект)
            {
                Tasks.Add(task);
            }
            else
            {
                Console.WriteLine("Нельзя добавить в проект задачи с дургим статусом");
            }
        }

        /// <summary>
        /// метод для начала проекта
        /// </summary>
        public void StartProject()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Выполнена)
                {
                    throw new InvalidOperationException("Задачи должны быть назначены до начала проекта");
                }
            }
            Status = ProjectStatus.Исполнение;
        }

        public bool IsCompleted()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Выполнена)
                    return false;
            }

            return true;
        }
        /// <summary>
        /// метод для закрытия проекта
        /// </summary>
        public void CloseProject()
        {
            foreach (var task in Tasks)
            {
                if (task.Status != TaskStatus.Выполнена)
                {
                    throw new InvalidOperationException("Не все задачи завершены");
                }
            }
            Status = ProjectStatus.Закрыт;
        }
    }
}
