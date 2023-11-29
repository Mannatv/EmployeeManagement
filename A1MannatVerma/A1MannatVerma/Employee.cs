using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1MannatVerma
{
    public enum EmployeeType { 
        HourlyEmployee, CommissionBasedEmployee, SalariedEmployee
    }
    internal abstract class Employee
    {
        public EmployeeType EmployeeType { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeDepartment { get; set; }

        public Employee(EmployeeType employeeType, int employeeId, string employeeName, string employeeDepartment)
        {
            EmployeeType = employeeType;
            EmployeeId = employeeId;
            EmployeeName = employeeName;
            EmployeeDepartment = employeeDepartment;
        }

        public abstract double Earning();

        public override string ToString()
        {
            return $"Employee Type: {EmployeeType}\n Employee Id : {EmployeeId}\n Employee Name: {EmployeeName}\n Employee Department: {EmployeeDepartment}\n";
        }

    }
}
