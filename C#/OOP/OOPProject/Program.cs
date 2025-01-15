using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

namespace OOPProject
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Calculator clc = new Calculator();
            clc.clear();    
            clc.PrintResult();
            clc.Add(10);
            clc.PrintResult();
     
            clc.Multiply(2);
            clc.PrintResult();

        }
    }
}
