using System;
using System.ServiceModel;

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
        [OperationContract]
        void EditData(string pathForEdit, string editEvent, string editPerson, string editPeisaj, string editLoc, string editAltele);
        [OperationContract]
        string FindData(string result, string editEvent, string editPerson, string editPeisaj, string editLoc, string editAltele);
    }
}
