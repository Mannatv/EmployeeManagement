using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1MannatVerma
{
    internal class SalariedEmployee : Employee
    {
        public double MonthlySalary { get; set; }
        public double MonthlyIncentive { get; set; }

        public SalariedEmployee(EmployeeType employeeType, int employeeId, string employeeName, string employeeDepartment,double monthlySalary , double monthlyIncentive) : base(employeeType, employeeId, employeeName, employeeDepartment)
        {
            MonthlySalary = monthlySalary;
            MonthlyIncentive = monthlyIncentive;

        }

        public override double Earning()
        {
            return MonthlySalary + MonthlyIncentive;

        }

        public override string ToString()
        {
            return base.ToString() + $" Monthly Salary: {MonthlySalary}\n Monthly Incentives: {MonthlyIncentive}\n";
        }
    }
}
