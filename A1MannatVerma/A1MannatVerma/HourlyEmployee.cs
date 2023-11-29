using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1MannatVerma
{
    internal class HourlyEmployee : Employee
    {
        public double Wage { get; set; }
        public double Hours { get; set; }

        public HourlyEmployee(EmployeeType employeeType, int employeeId, string employeeName, string employeeDepartment ,double wage, double hours) : base(employeeType, employeeId, employeeName, employeeDepartment)
        { 
            Wage = wage;
            Hours = hours;
        }
        public override double Earning()
        {
            if (Hours <= 40)
            {
                return Wage * Hours;
            }
            else
                return (Wage * 40) + (Hours - 40) * Wage * 1.5;
        }
        public override string ToString()
        {
            return base.ToString() + $"Wage: {Wage}\n Hours: {Hours}\n";
        }
    }
}
