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
        object SaveMedia(string sqlCommand);
        [OperationContract]
        object DeleteMedia(string sqlCommand, string path);
        [OperationContract]
        object ShowGridData(string sqlCommand);
        [OperationContract]
        object ShowData(string sqlCommand);
        [OperationContract]
        object SaveFile(string sqlCommand);
    }
}
