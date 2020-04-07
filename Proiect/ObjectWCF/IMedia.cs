using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ModelAndApi;

namespace ObjectWCF
{
    [ServiceContract]
    interface IMedia
    {
        [OperationContract]
        void SaveMedia(string path, string events, string persons, string peisaj, string locatie, string altele, DateTime creationDate);
        [OperationContract]
        void DeleteMedia(string path);
        [OperationContract]
        object ShowGridData();
        [OperationContract]
        object ShowData();
        [OperationContract]
        string SaveFile();
    }
}
