using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFirstClassLibrary;

namespace LinkingAClassLibrary
{
    public class Whatever : StringLib
    {
        void somePrintingStuff()
        {
            Whatever whateverObj = new Whatever();
            whateverObj.SLastName = "FFFf";
            base.SLastName = "10000";
            base.CombineThreeStrings("FFFF", SLastName, "DDDd");
        }

    }
}
