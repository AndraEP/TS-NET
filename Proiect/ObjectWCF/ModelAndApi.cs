using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
