using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    /// <summary>
    /// класс, который представляет задачу в проекте
    /// </summary>
    public class Task
    {
        public string Opisanie { get; set; }
        public DateTime Deadline { get; set; }
        public Employee Initiator { get; set; }
        public Employee Ispolnitel {get; set; }
        public TaskStatus Status { get; set; }
        public Report Report { get; set; }
        /// <summary>
        /// конструктор
        /// </summary>
        public Task(string opisanie, DateTime deadline, Employee initiator)
        {
            Opisanie = opisanie;
            Deadline = deadline;
            Initiator = initiator;
            Status = TaskStatus.Назначена;
        }
        /// <summary>
        /// метод, который назначает исполнителя и меняет статус задачи на "ВРаботе"
        /// </summary>
        public void StartWork(Employee employee)
        {
            Ispolnitel = employee;
            Status = TaskStatus.ВРаботе;
        }
        /// <summary>
        /// метод, который изменяет исполнителя на нового и меняет статус задачи
        /// </summary>
        public void DelegateTask(Employee newIspolnitel)
        {
            Ispolnitel = newIspolnitel;
            Status = TaskStatus.Назначена;
        }
        /// <summary>
        /// метод, который убирает исполнителя
        /// </summary>
        public void RejectTask()
        {
            Ispolnitel = null;
            Status = TaskStatus.Назначена;
        }
        /// <summary>
        /// метод, который создает новый отчёт
        /// </summary>
        public void CompleteTask(string reportText)
        {
            Report = new Report(reportText, DateTime.Now, Ispolnitel);
            Status = TaskStatus.Выполнена;
        }
        /// <summary>
        /// метод, который проверяет есть ли отчёт
        /// </summary>
        public void ApproveReport()
        {
            if (Report != null)
            {
                Status = TaskStatus.Выполнена;
            }
        }

        /// <summary>
        /// метод, который смотрит, если отчёт существует
        /// </summary>
        public void ReturnReport()
        {
            if (Report != null)
            {
                Status = TaskStatus.НаПроверке;
                Report = null;
            }
        }
    }
}
