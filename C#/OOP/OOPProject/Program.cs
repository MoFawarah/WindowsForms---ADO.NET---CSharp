using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using OOPProject.Classes;
using MyFirstClassLibrary;
using OOPProject;

class clsA
{
    public int xNormal;
    public static int xStatic;
   

    private string name = string.Empty;

    public int Age { get; set; }

    public string Name 
    { 
            get
        {
            if (name == string.Empty)
                return "name";
            else
            {
                return name;
            }
        }
      
       
            
            set
        {
            if(name != null)
                name = value;
        }
            
            
            
    }

    public int method1()
    {
      return this.xNormal + xStatic;
    }

    public static int method2()
    {
        return clsA.xStatic;
    }

}
static class Settings
{
    public static int DayNumber
    {
        get
        {
            return DateTime.Today.Day;
        }
    }

    public static string DayName
    {
        get
        {
            return DateTime.Today.DayOfWeek.ToString();
        }
    }

    public static string ProjectPath
    {
        get;
        set;
    }

    public static string Year
    {
        get
        {
            return DateTime.Today.Year.ToString();
        }
    }
}
class Calculator
{
    enum enOperations {Clear = 0, Adding, Dividng, Multiplying, Substracting};

    private double _result = 0;
    private double _lastResult = 0;
    private string _lastOperation = "Clear";
    private double _lastNumber = 0;
    private enOperations _enOperation = enOperations.Clear;

    private string LastOperation { 
        get
        {
            return _lastOperation;
        } 
        set
        {
            _lastOperation = value;
        }
    }


    private bool _IsZero(double num)
    {
        
        return num == 0;
    }

    private double GetLastResult()
    {
        return this._lastResult = this._result; 
    }

    public void clear()
    {
        _enOperation = enOperations.Clear;
        this._lastNumber = 0;   
        LastOperation = "Clear";
        this._result = 0;
    }

    public void Add(double num)
    {
        _enOperation = enOperations.Adding;
        this._lastNumber = num;
        LastOperation = "Adding";
        GetLastResult();
        this._result += num;
    }
    
    public void Substract(double num)
    {
        _enOperation = enOperations.Substracting;
        this._lastNumber = num;
        LastOperation = "Substracting";
        GetLastResult();
        this._result -= num;
    }

    public void Multiply (double num)
    {
        _enOperation = enOperations.Multiplying;
        this._lastNumber = num;
        LastOperation = "Multiplying";
        GetLastResult();
        this._result *= num;
    }

    public bool Divide(double num)
    {
        _enOperation = enOperations.Dividng;
        bool succeded = true;
        this._lastNumber = num;
        LastOperation = "Dividng";
        if (_IsZero(num))
        {
            succeded = false;
            this._result /= 1;
        } 
        else
        {
            GetLastResult();
            this._result /=num;
        }

        return succeded;
    }

    public void PrintResult()
    {
        if(this._enOperation == enOperations.Clear)
        {
            Console.WriteLine("Calculator Cleared");
        }
        else if (this._enOperation == enOperations.Dividng || this._enOperation == enOperations.Multiplying)
        {
            Console.WriteLine("Result after {0} {1} by {2} = {3}", this._lastOperation, this._lastNumber, this._lastResult, this._result);
        }
        else
            Console.WriteLine("Result after {0} {1} to {2} = {3}", this._lastOperation, this._lastNumber, this._lastResult, this._result);

    }

    public double GetFinalResult()
    {
        return this._result;
    }
    
}

class clsPerson
{
    private string _name;
    private bool _isLifeGood;
    public int ID { get; set; }
    public string Name { 
        get
        {
            return _name;
        }
        
        set
        {
            _name = value.ToLower();
                ;
        }
    
    }
    public int Age { get; set; }
    public string UserName { get; set; }
    public String Email { get; set; }
    public int Password { get; set; }

    protected bool IsLifeGood {
        get
        {
            return _isLifeGood;
        }
             
        set
        {
            _isLifeGood = value;
        }
            }

    public clsPerson(int id, string name, int age)
    {
        this.ID = id;
        this.Name = name;
        this.Age = age;
        this._isLifeGood = false;
    }


    public static clsPerson Find(int Id)
    {
        if (Id == 10)
            return new clsPerson(10, "Mohammad Fawareh", 26);
        else
            return null;     
    }

    public static clsPerson Find(string userName, string password)
    {
        if (userName == "MoFawareh" && password == "fawareh123")
            return new clsPerson(11, "Rami Ayyash", 30);
        else
            return null;
    }

    public static clsPerson Find (string email)
    {
        if (email == "mohammaddfawareh@gmail.com")
            return new clsPerson(10, "Mohammad Fawareh", 26);
        else
            return null;
    }

}

class clsEmployee : clsPerson
{
    public float Salary { get; set; }
    public string Department { get; set; }

    public clsEmployee(float salary, string department, int id, string name, int age) : base(id, name, age)
    {
        this.Salary = salary;
        this.Department = department;
    }

    public void increaseSalary(float inceaseAmount)
    {
        this.Salary += inceaseAmount;
    }

    public bool isLifeGoodFunc()
    {
        IsLifeGood = true;
        return IsLifeGood;
    }


   
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Greet()
    {
        Console.WriteLine($"Hi, my name is {Name} and I am {Age} years old.");
        
    }
}

public class Employee : Person
{
    public string Company { get; set; }
    public decimal Salary { get; set; }


    public void Work()
    {
        Console.WriteLine($"I work at {Company} and earn {Salary:C} per year.");
        base.Greet();
    }
}

public class clsAA
{
    public virtual void Print()
    {
        Console.WriteLine("Hi, I'm the print method from the base class A");
    }
}

public class clsB : clsAA
{
    public override void Print()

    {
        Console.WriteLine("Hi, I'm the print method from the derived class B");
        base.Print();
    }
}

interface IPerson
{
  
    string PersonName { get; set; }
    void SayHello();
}

interface ICommunicate
{
    void SendEmail(string email, string subject, string body);
    void SendFax(string email);
    void CallPhone(string phoneNumber);
    void SendSMS(string phoneNumber, string msg);

}


public abstract class newPerson : IPerson, ICommunicate
{
    public newPerson()
    {
        this._personName = "Mohammad";
    }
    private string _personName;
    public string PersonName
    {

        get
        {
            if(string.IsNullOrEmpty(_personName))
            return "No Name Yet!";
            else
            return _personName;
        }

        set
        {
           _personName = string.IsNullOrEmpty(value) ? "No name provided" : value;

        }
    }

    abstract public void SayHello();

    public void SendEmail(string email, string subject, string body)
    {
        Console.WriteLine("Email Sent");
    }
    public void SendFax(string email)
    {
        Console.WriteLine("Fax Sent");
    }
    public void CallPhone(string phoneNumber)
    {
        Console.WriteLine("Calling Phone...");
    }
    public void SendSMS(string phoneNumber, string msg)
    {
        Console.WriteLine("SMS Sent");
    }

}

public abstract class newNewPerson : newPerson
{
     public void SayNo()
    {
        Console.WriteLine("SayNo");
    }
}

public class newNewNewPerson : newPerson
{
    public override void SayHello()
    {
        Console.WriteLine("Hello");
    }
    public void SayNo()
    {
        Console.WriteLine("SayNo");
    }
}
public abstract class Person02
{
    //public Person02(string firstName, string lastName)
    //{
    //    FirstName = firstName;
    //    LastName = lastName;
    //}

    public string FirstName { get; set; }
    public string LastName { get; set; }

    public abstract void Introduce();

    public virtual void SayGoodbye()
    {
        Console.WriteLine("Goodbye from the parent!");
    }
}

public class Employee02 : Person02
{
    //public Employee02(int employeeId, string firstName, string lastName) : base(firstName, lastName)
    //{
    //    this.EmployeeId = employeeId;
    //}

    public int EmployeeId { get; set; }

    public override void Introduce()
    {
        Console.WriteLine($"Hi, my name is {FirstName} {LastName}, and my employee ID is {EmployeeId}.");
    }

    public override void SayGoodbye()
    {
        Console.WriteLine("Goodbye from the child!");
    }
}


public class Marhaba
{
    public virtual void sayingHello()
    {
        Console.WriteLine("Hello from Marhaba Class");
    }
}
public class Hello: Marhaba
{
    public sealed override void sayingHello()
    {
        Console.WriteLine("HELLO from Hello Class!");
    }
}

public class Welcome: Hello
{
 
    public void sayingWelcome()
    {
        Console.WriteLine("WELCOME from Welcome Class!");
    }
}

class MyCls
{
    public enum myEnum : short {Small, Medium, Large }
    public string name;
}
struct MyStruct
{
    public string name;
    public int age;
 
    //public string Name { get; set; }
}

class Parent
{
    public string Name = "parent";

    public virtual string Message() // Must be marked as virtual for polymorphism
    {
        return "from parent";
    }
}

class Child : Parent
{
    //public new string Name = "child"; // Hides the parent field

    public override string Message() // Overrides the parent method
    {
        return "from child";
    }
}



 

namespace OOPProject
{
    internal class Program
    {

        static void isPangram(string sentence)
        {
            string allAlphabet = "abcdefghijklmnopqrstuvwxyz";
            
            bool isPangram = allAlphabet.All(letter => sentence.ToLower().Contains(letter));
            if (isPangram)
            {
                Console.WriteLine("Pangram");
            }
            else
            {
                Console.WriteLine("Not");

            }




        }

        static int[] maxSubSumArray(int[] array, int n)
        {
            int[] subArray = new int[3];
            int sumThreeItems = 0;
            int maxSum = 0;
           


            for (int i = 0; i <= array.Length-n; i++)
            {
              
                    sumThreeItems = 0;

                    sumThreeItems += array[i] + array[i + 1] + array[i + 2];
                    if (sumThreeItems > maxSum)
                    {
                        maxSum = sumThreeItems;
                        subArray[0] = array[i];
                        subArray[1] = array[i + 1];
                        subArray[2] = array[i + 2];
                    }

                


            }
            subArray = null;
            return subArray;

        }

        static int[] whatever(int[] array)
        {
            List<int> result = new List<int>();

            //int[] input = { 1, 2, 1, 2, 3, 4, 1, 1 };
            int counter = -1;

            for (int i = 0; i <= array.Length-1; i++)
            {
                counter++;
                if (counter == array.Length - 1)
                {
                    result.Add(array[i]);
                    break;
                }
                if(array[i+1] > array[i])
                {
                    result.Add(array[i]);
                    
                }
                else
                {
                    result.Clear();
                }




            }
           
            return result.ToArray();

        }
        static void Main(string[] args)
        {

            int[] input = { 1, 2, 1, 2, 3, 4, 1, 1 };

            int[] subArray = new int[3];
            subArray = whatever(input);
            if(subArray != null)
            for (int i = 0; i < subArray.Length; i++)
            {
                Console.WriteLine(subArray[i]);

            }





        }
    }
}
