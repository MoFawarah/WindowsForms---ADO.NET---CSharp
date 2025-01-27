 using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CompanyService
{
    public class CompanyService : ICompanyPublicService, ICompanyConfidentialService
    {
        public string GetPublicInformation()
        {
            return "This is public Information over HTTP outside FireWall";
        }

        public string GetConfidentialInformation()
        {
            return "This is Confidential Information over TCP behind the company FireWall";
        }
    }
}
