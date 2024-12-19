using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{ 
    /// <summary>
    /// класс, который представляет отчёт
    /// </summary>
    public class Report
    {
        public string Text { get; set; }
        public DateTime CompletionDate { get; set; }
        public Employee Ispolnitel { get; set; }
        /// <summary>
        /// конструктор
        /// </summary>
        public Report(string text, DateTime completionDate, Employee ispolnitel)
        {
            Text = text;
            CompletionDate = completionDate;
            Ispolnitel = ispolnitel;
        }
    }
}
