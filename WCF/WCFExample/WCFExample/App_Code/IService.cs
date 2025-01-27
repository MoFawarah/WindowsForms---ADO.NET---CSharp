using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

[ServiceContract]
public interface IService
{

	[OperationContract]
	Task<string> GetData(int value);

	[OperationContract]
	Task <string> GetName(string user_name);

    [OperationContract]
    Task<int> FindSumAsync(int x, int y);

    [OperationContract]
    Task<float> FindDivision(int x, int y);

}



