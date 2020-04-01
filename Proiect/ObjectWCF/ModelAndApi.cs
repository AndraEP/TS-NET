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
        object IMedia.SaveMedia(string sqlCommand)
        {
            API api = new API();
            return api.SaveMedia(sqlCommand);
        }

        object IMedia.DeleteMedia(string sqlCommand, string path)
        {
            API api = new API();
            return api.DeleteMedia(sqlCommand, path);
        }

        object IMedia.ShowGridData(string sqlCommand)
        {
            API api = new API();
            return api.ShowGridData(sqlCommand);
        }

        object IMedia.ShowData(string sqlCommand)
        {
            API api = new API();
            return api.ShowData(sqlCommand);
        }

        object IMedia.SaveFile(string sqlCommand)
        {
            API api = new API();
            return api.SaveFile(sqlCommand);
        }
    }
}
