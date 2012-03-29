using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "WCFService")]
    public interface IDBService
    {
        [OperationContract]
        object GetRecords();

        [OperationContract]
        void AddPhoto(int index, byte[] bytes, string path);

        [OperationContract(IsOneWay = true)]
        void SaveChanges(string jsonstring);


    }

}
