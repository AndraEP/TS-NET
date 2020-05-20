using System;
using ModelAndApi;

namespace ObjectWCF
{
    public class ModelAndApi : IMedia
    {
        void IMedia.SaveMedia(string path, string events, string persons, string peisaj, string locatie, string altele, DateTime creationDate)
        {
            API api = new API();
            api.SaveMedia(path, events, persons, peisaj, locatie, altele, creationDate);
        }

        void IMedia.DeleteMedia(string path)
        {
            API api = new API();
            api.DeleteMedia(path);
        }

        object IMedia.ShowGridData()
        {
            API api = new API();
            return api.ShowGridData();
        }

        object IMedia.ShowData()
        {
            API api = new API();
            return api.ShowData();
        }

        string IMedia.SaveFile()
        {
            API api = new API();
            return api.SaveFile();
        }

        void IMedia.EditData(string pathForEdit, string editEvent, string editPerson, string editPeisaj, string editLoc, string editAltele)
        {
            API api = new API();
            api.EditData(pathForEdit, editEvent, editPerson, editPeisaj, editLoc, editAltele);
        }

        string IMedia.FindData(string result, string editEvent, string editPerson, string editPeisaj, string editLoc, string editAltele)
        {
            API api = new API();
            return api.FindData(result, editEvent, editPerson, editPeisaj, editLoc, editAltele);
        }
    }
}
