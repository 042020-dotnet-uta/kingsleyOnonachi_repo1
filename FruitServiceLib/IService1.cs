using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace FruitServiceLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IFruit
    {
        
        [OperationContract]
        List<string> Add(List<string> n1, string n2);
        [OperationContract]
        List<string> Subtract(List<string> n1, string n2);

    }
}
