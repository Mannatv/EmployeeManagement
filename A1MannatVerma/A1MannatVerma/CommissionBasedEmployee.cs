using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1MannatVerma
{
    internal class CommissionBasedEmployee : Employee
    {
        public Double CommissionRate {  get; set; }
        public Double SalesAmount { get; set; }

        public CommissionBasedEmployee(EmployeeType employeeType, int employeeId, string employeeName, string employeeDepartment, double commissionRate, double salesAmount) : base(employeeType, employeeId, employeeName, employeeDepartment)
        {
            CommissionRate = commissionRate;
            SalesAmount = salesAmount;
        }

        public override double Earning()
        {
            if (CommissionRate >= 0.10 && CommissionRate <= 0.50)
            {
                return CommissionRate * SalesAmount;
            }
            else { return 0; }
        }
        public override string ToString()
        {
            return base.ToString() + $"Commission Rate: {CommissionRate}\n Sales Amount: {SalesAmount}\n";
        }
    }
}
