using System;
using System.Collections.Generic;

namespace A1MannatVerma
{
    internal class Program
    {
        static int nextEmployeeId = 2; // Starting employee ID  like it is a primary key 

        static List<Employee> employees = new List<Employee>
        {
            new HourlyEmployee(EmployeeType.HourlyEmployee, 1, "Ram", "Sales", 20.0, 40.0),
            new SalariedEmployee(EmployeeType.SalariedEmployee, 1, "Mannat", "Computer Science", 10000.0, 1000.0),
            new CommissionBasedEmployee(EmployeeType.CommissionBasedEmployee, 1, "Rahul", "Marketing", 0.20, 20000.0)
        };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Employee Management System:");
                Console.WriteLine("1 - Add Employee");
                Console.WriteLine("2 - Edit Employee");
                Console.WriteLine("3 - Delete Employee");
                Console.WriteLine("4 - View Employee");
                Console.WriteLine("5 - Search Employee");
                Console.WriteLine("6 - Exit");
                Console.Write("Enter the Option from above list: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddEmployee();
                            break;
                        case 2:
                            EditEmployee();
                            break;
                        case 3:
                            DeleteEmployee();
                            break;
                        case 4:
                            ViewEmployee();
                            break;
                        case 5:
                            SearchEmployee();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid input. Please try again.");
                            break;
                    }
                }
            }
        }

        static void AddEmployee()
        {
            Console.Clear();
            Console.WriteLine("Select Employee Type:");
            Console.WriteLine("1 - Hourly Employee");
            Console.WriteLine("2 - Salaried Employee");
            Console.WriteLine("3 - Commission-Based Employee");
            Console.WriteLine("4 - Back to Main Menu");
            Console.Write("Enter the Option from above list: ");

            if (int.TryParse(Console.ReadLine(), out int typeChoice))
            {
                switch (typeChoice)
                {
                    case 1:
                        Console.Write("Enter Employee Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Employee Department: ");
                        string department = Console.ReadLine();
                        Console.Write("Enter Wage: ");
                        double wage = double.Parse(Console.ReadLine());
                        Console.Write("Enter Hours: ");
                        double hours = double.Parse(Console.ReadLine());
                        employees.Add(new HourlyEmployee(EmployeeType.HourlyEmployee, nextEmployeeId++, name, department, wage, hours));

                        Console.WriteLine("Employee Added Successfully.");
                        ViewEmployeesByType(EmployeeType.HourlyEmployee);
                        break;

                    case 2:
                        Console.Write("Enter Employee Name: ");
                        string salariedName = Console.ReadLine();
                        Console.Write("Enter Employee Department: ");
                        string salariedDepartment = Console.ReadLine();
                        Console.Write("Enter Monthly Salary: ");
                        double monthlySalary = double.Parse(Console.ReadLine());
                        Console.Write("Enter Monthly Incentive: ");
                        double monthlyIncentive = double.Parse(Console.ReadLine());
                        employees.Add(new SalariedEmployee(EmployeeType.SalariedEmployee, nextEmployeeId++, salariedName, salariedDepartment, monthlySalary, monthlyIncentive));
                        Console.WriteLine("Employee Added Successfully.");
                        ViewEmployeesByType(EmployeeType.SalariedEmployee);
                        break;

                    case 3:
                        Console.Write("Enter Employee Name: ");
                        string commissionName = Console.ReadLine();
                        Console.Write("Enter Employee Department: ");
                        string commissionDepartment = Console.ReadLine();
                        Console.Write("Enter Commission Rate (between 0.10 and 0.50): ");
                        double commissionRate = double.Parse(Console.ReadLine());
                        Console.Write("Enter Sales Amount: ");
                        double salesAmount = double.Parse(Console.ReadLine());

                        if (commissionRate < 0.10 || commissionRate > 0.50)
                        {
                            Console.WriteLine("Invalid Commission Rate....");
                            return;
                        }
                        employees.Add(new CommissionBasedEmployee(EmployeeType.CommissionBasedEmployee, nextEmployeeId++, commissionName, commissionDepartment, commissionRate, salesAmount));

                        Console.WriteLine("Employee Added Successfully.");
                        ViewEmployeesByType(EmployeeType.CommissionBasedEmployee);
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invalid option....\n please try again...");
                        break;
                }
            }
        }

        static void EditEmployee()
        {
            Console.Clear();
            // Display a list of employees based on their type
            Console.WriteLine("Select Employee Type to Edit:");
            Console.WriteLine("1 - Hourly Employee");
            Console.WriteLine("2 - Salaried Employee");
            Console.WriteLine("3 - Commission-Based Employee");
            Console.WriteLine("4 - Back to Main Menu");
            Console.Write("Enter the Option from above list: ");

            if (int.TryParse(Console.ReadLine(), out int typeChoice))
            {
                switch (typeChoice)
                {
                    case 1:
                        ViewEmployeesByType(EmployeeType.HourlyEmployee);
                        Console.Write("Enter Employee ID to Edit: ");
                        int id = int.Parse(Console.ReadLine());

                        // Find the HourlyEmployee with the specified ID
                        HourlyEmployee hourlyEmployee = employees.Find(emp => emp.EmployeeType == EmployeeType.HourlyEmployee && emp.EmployeeId == id) as HourlyEmployee;

                        if (hourlyEmployee != null)
                        {
                            Console.Write("Enter Updated Employee Name: ");
                            string updatedName = Console.ReadLine();
                            Console.Write("Enter Updated Employee Department: ");
                            string updatedDepartment = Console.ReadLine();
                            Console.Write("Enter Updated Wage: ");
                            double updatedWage = double.Parse(Console.ReadLine());
                            Console.Write("Enter Updated Hours Worked: ");
                            double updatedHours = double.Parse(Console.ReadLine());

                            // Update HourlyEmployee details
                            hourlyEmployee.EmployeeName = updatedName;
                            hourlyEmployee.EmployeeDepartment = updatedDepartment;
                            hourlyEmployee.Wage = updatedWage;
                            hourlyEmployee.Hours = updatedHours;

                            Console.WriteLine("Employee Edited Successfully.");
                            ViewEmployeesByType(EmployeeType.HourlyEmployee);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found with the specified ID.");
                        }
                        break;

                    case 2:
                        ViewEmployeesByType(EmployeeType.SalariedEmployee);
                        Console.Write("Enter Employee ID to Edit: ");
                        int idToEditSalaried = int.Parse(Console.ReadLine());

                        // Find the SalariedEmployee with the specified ID
                        SalariedEmployee salariedEmployee = employees.Find(emp => emp.EmployeeType == EmployeeType.SalariedEmployee && emp.EmployeeId == idToEditSalaried) as SalariedEmployee;

                        if (salariedEmployee != null)
                        {
                            Console.Write("Enter Updated Employee Name: ");
                            string updatedName = Console.ReadLine();
                            Console.Write("Enter Updated Employee Department: ");
                            string updatedDepartment = Console.ReadLine();
                            Console.Write("Enter Updated Monthly Salary: ");
                            double updatedMonthlySalary = double.Parse(Console.ReadLine());
                            Console.Write("Enter Updated Monthly Incentive: ");
                            double updatedMonthlyIncentive = double.Parse(Console.ReadLine());

                            // Update SalariedEmployee details
                            salariedEmployee.EmployeeName = updatedName;
                            salariedEmployee.EmployeeDepartment = updatedDepartment;
                            salariedEmployee.MonthlySalary = updatedMonthlySalary;
                            salariedEmployee.MonthlyIncentive = updatedMonthlyIncentive;

                            Console.WriteLine("Employee Edited Successfully.");
                            ViewEmployeesByType(EmployeeType.SalariedEmployee);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found with the specified ID.");
                        }
                        break;

                    case 3:
                        ViewEmployeesByType(EmployeeType.CommissionBasedEmployee);
                        Console.Write("Enter Employee ID to Edit: ");
                        int idToEditCommission = int.Parse(Console.ReadLine());
                        CommissionBasedEmployee commissionEmployee = employees.Find(emp => emp.EmployeeType == EmployeeType.CommissionBasedEmployee && emp.EmployeeId == idToEditCommission) as CommissionBasedEmployee;

                        if (commissionEmployee != null)
                        {
                            Console.Write("Enter Updated Employee Name: ");
                            string updatedName = Console.ReadLine();
                            Console.Write("Enter Updated Employee Department: ");
                            string updatedDepartment = Console.ReadLine();
                            Console.Write("Enter Updated Commission Rate (between 0.10 and 0.50): ");
                            double updatedCommissionRate = double.Parse(Console.ReadLine());
                            Console.Write("Enter Updated Sales Amount: ");
                            double updatedSalesAmount = double.Parse(Console.ReadLine());

                            if (updatedCommissionRate < 0.10 || updatedCommissionRate > 0.50)
                            {
                                Console.WriteLine("Updated Commission Rate must be between 0.10 and 0.50.");
                                return;
                            }

                            // Update CommissionBasedEmployee details
                            commissionEmployee.EmployeeName = updatedName;
                            commissionEmployee.EmployeeDepartment = updatedDepartment;
                            commissionEmployee.CommissionRate = updatedCommissionRate;
                            commissionEmployee.SalesAmount = updatedSalesAmount;

                            Console.WriteLine("Employee Edited Successfully.");
                            ViewEmployeesByType(EmployeeType.CommissionBasedEmployee);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found with the specified ID.");
                        }
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again....");
                        break;
                }
            }
        }

        static void DeleteEmployee()
        {
            Console.Clear();
            Console.WriteLine("Select Employee Type to Delete:");
            Console.WriteLine("1 - Hourly Employee");
            Console.WriteLine("2 - Salaried Employee");
            Console.WriteLine("3 - Commission-Based Employee");
            Console.WriteLine("4 - Back to Main Menu");
            Console.Write("Enter the Option from above list: ");

            if (int.TryParse(Console.ReadLine(), out int deleteType))
            {
                switch (deleteType)
                {
                    case 1:
                        ViewEmployeesByType(EmployeeType.HourlyEmployee);
                        Console.Write("Enter Employee ID to Delete: ");
                        int id = int.Parse(Console.ReadLine());

                        HourlyEmployee hourlyEmployee = employees.Find(emp => emp.EmployeeType == EmployeeType.HourlyEmployee && emp.EmployeeId == id) as HourlyEmployee;

                        if (hourlyEmployee != null)
                        {
                            employees.Remove(hourlyEmployee);
                            Console.WriteLine("Employee Deleted Successfully.");
                            ViewEmployeesByType(EmployeeType.HourlyEmployee);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found with the specified ID.");
                        }
                        break;

                    case 2:
                        ViewEmployeesByType(EmployeeType.SalariedEmployee);
                        Console.Write("Enter Employee ID to Delete: ");
                        int ids= int.Parse(Console.ReadLine());

                        SalariedEmployee salariedEmployee = employees.Find(e => e.EmployeeType == EmployeeType.SalariedEmployee && e.EmployeeId == ids) as SalariedEmployee;

                        if (salariedEmployee != null)
                        {
                            employees.Remove(salariedEmployee);
                            Console.WriteLine("Employee Deleted Successfully.");
                            ViewEmployeesByType(EmployeeType.SalariedEmployee);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found with the specified ID.");
                        }
                        break;

                    case 3:
                        ViewEmployeesByType(EmployeeType.CommissionBasedEmployee);
                        Console.Write("Enter Employee ID to Delete: ");
                        int idc = int.Parse(Console.ReadLine());
                        CommissionBasedEmployee commissionEmployee = employees.Find(e => e.EmployeeType == EmployeeType.CommissionBasedEmployee && e.EmployeeId == idc) as CommissionBasedEmployee;

                        if (commissionEmployee != null)
                        {
                            employees.Remove(commissionEmployee);
                            Console.WriteLine("Employee Deleted Successfully.");
                            ViewEmployeesByType(EmployeeType.CommissionBasedEmployee);
                        }
                        else
                        {
                            Console.WriteLine("Employee not found with the specified ID.");
                        }
                        break;

                    case 4:
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ViewEmployee()
        {
            Console.Clear();
            Console.WriteLine("View All Employees:");
            ViewEmployeesByType(EmployeeType.HourlyEmployee);
            ViewEmployeesByType(EmployeeType.SalariedEmployee);
            ViewEmployeesByType(EmployeeType.CommissionBasedEmployee);
        }

        static void ViewEmployeesByType(EmployeeType t)
        {
            Console.WriteLine($"Employees - {t}:");
            // Display column headers
            Console.WriteLine("Employee ID\tEmployee Name\tEmployee Dept\tEarnings");

            // Filter employees by type and display them in tabular form
            foreach (var employee in employees.FindAll(emp => emp.EmployeeType == t))
            {
                Console.WriteLine($"{employee.EmployeeId}\t\t{employee.EmployeeName}\t\t{employee.EmployeeDepartment}\t\t{employee.Earning():C}");
            }
            Console.WriteLine();
        }

        static void SearchEmployee()
        {
            Console.Clear();
            Console.Write("Enter Employee Name to Search: ");
            string search = Console.ReadLine();

            Console.WriteLine("Search Results:");

            // Display column headers
            Console.WriteLine("Employee ID\tEmployee Type\tEmployee Name\tEmployee Dept\tEarnings");

            foreach (var employee in employees.FindAll(emp => emp.EmployeeName.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0))
            {
                Console.WriteLine($"{employee.EmployeeId}\t\t{employee.EmployeeType}\t{employee.EmployeeName}\t\t{employee.EmployeeDepartment}\t\t{employee.Earning():C}");
            }

            Console.WriteLine();
        }
    }
}
