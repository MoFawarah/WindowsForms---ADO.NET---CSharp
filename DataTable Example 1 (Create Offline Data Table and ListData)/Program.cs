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
        EmployeesDataTable.Rows.Add(1, "Mohammad Taleb.jo", "Jordan",1, DateTime.Now);
        EmployeesDataTable.Rows.Add(2, "Ali Maher", "KSA",1.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(3, "Lina Kamal", "Jordan",1.5, DateTime.Now);
        EmployeesDataTable.Rows.Add(4, "Fadi JAmeel.jo", "Egypt",2, DateTime.Now);
        EmployeesDataTable.Rows.Add(5, "Omar Mahmoud", "Lebanon",100, DateTime.Now);
        EmployeesDataTable.Rows.Add(6, "Mohammad Fawareh", "Jordan", 1, DateTime.Now);
        EmployeesDataTable.Rows.Add(7, "Basil", "Jordan", 1, DateTime.Now);


 

        Console.WriteLine("\nEmployees List:\n");

        foreach (DataRow row in EmployeesDataTable.Rows)
        {    
         
            Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
                row["ID"], row["Name"], row["Country"], row["Salary"],
                row["Date"]);
       
        }


        DataRow[] results = EmployeesDataTable.Select("ID = 4");

        DataColumn col = new DataColumn();
        col = EmployeesDataTable.Columns["Salary"];
        Console.WriteLine(col);

        foreach (DataColumn column in EmployeesDataTable.Columns)
        {
            Console.WriteLine("Column Name: " + column.ColumnName);
        }
        foreach (DataRow record in results)
        {
            record.Delete();
        }


        Console.WriteLine("\nEmployees List after deletion id = 4:\n");

        foreach (DataRow row in EmployeesDataTable.Rows)
        {

            Console.WriteLine("ID: {0}\t Name : {1} \t Country: {2} \t Salary: {3} Date: {4} \t ",
                row["ID"], row["Name"], row["Country"], row["Salary"],
                row["Date"]);

        }









        Console.ReadKey();

    }
}