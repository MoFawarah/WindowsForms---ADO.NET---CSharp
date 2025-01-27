using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

public class Service : IService
{
    public async Task<float> FindDivision(int x, int y)
    {
        await Task.Delay(100);
        try
        {

        if (y==0)
       
            return float.NaN;

        return (float)x / y;
        }

        catch (Exception ex)
        {
            return  float.NaN;
        }
    }

    public async Task<int> FindSumAsync(int x, int y)
    {
        await Task.Delay(1000);
        int sum = x + y;
        return sum;
    }

    public async Task<string>GetData(int value)
	{
        await Task.Delay(100);
		 return  string.Format("You entered: {0}", value);
	}

    public async Task <string> GetName(string user_name)
    {
        await Task.Delay(100);
        if (string.IsNullOrEmpty(user_name))
        {
            return "plz enter a name"; 
        }

        return string.Format("your name is: {0}", user_name);
    }
}
