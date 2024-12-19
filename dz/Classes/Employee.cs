using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz
{
    public class Employee
    {
        public string Name { get; set; }
        /// <summary>
        /// конструктор
        /// </summary>
        public Employee(string name)
        {
            Name = name;
        }
    }
}
