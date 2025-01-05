using System;
using System.Data;
using System.Linq;

public class Example
{
    public static void Main()
    {
        DataTable EmployeesDataTable = new DataTable();
        EmployeesDataTable.Columns.Add("ID", typeof(int));
        EmployeesDataTable.Columns.Add("Name", typeof(string));
        EmployeesDataTable.Columns.Add("Country", typeof(string));
        EmployeesDataTable.Columns.Add("Salary", typeof(Double));
        EmployeesDataTable.Columns.Add("Date", typeof(DateTime));

        //Add rows 
        EmployeesDataTable.Rows.Add(1, "Mohammed Abu-Hadhoud", "Jordan",0.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA",1.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(3, "Lina Kamal", "Jordan",1.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(4, "Fadi JAmeel", "Egypt",2, DateTime.Now);
        EmployeesDataTable.Rows.Add(5, "Omar Mahmoud", "Lebanon",100, DateTime.Now);
        EmployeesDataTable.Rows.Add(6, "Mohammad Fawareh", "Jordan", 1, DateTime.Now);

        int empCount = 0;
        double totalSalary = 0;
        double avgSalary = 0;
        double minSalary = 0;
        double maxSalary = 0;

        empCount = EmployeesDataTable.Rows.Count;
        totalSalary = (double) EmployeesDataTable.Compute("Sum(Salary)", string.Empty);
        avgSalary = (double) EmployeesDataTable.Compute("avg(Salary)", string.Empty);
        minSalary = (double) EmployeesDataTable.Compute("min(Salary)", string.Empty);
        maxSalary = (double) EmployeesDataTable.Compute("MAX(Salary)", string.Empty);

        Console.WriteLine(empCount);
        Console.WriteLine(totalSalary);
        Console.WriteLine(avgSalary);
        Console.WriteLine(minSalary);
        Console.WriteLine(maxSalary);

        Console.WriteLine("\nEmployees List:\n");
    
        /*foreach (DataRow row in EmployeesDataTable.Rows)
        {    
         
            Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
                row["ID"], row["Name"], row["Country"], row["Salary"],
                row["Date"]);
       
        }*/

       

        Console.ReadKey();

    }
}