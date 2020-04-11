using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace ModelAndApi
{
    public class API
    {
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-A6HN40I;Initial Catalog=ProiectMedia;Integrated Security=True;");
        SqlCommand command;
        public void SaveMedia (string path, string events, string persons, string peisaj, string locatie, string altele, DateTime creationDate)
        {
            using (Model1Container context = new Model1Container())
            {
                Media newMedia = new Media()
                {
                    Path = path,
                    Moved = 0,
                    Evenimente = events,
                    Persoane = persons,
                    Peisaje = peisaj,
                    Locuri = locatie,
                    Altele = altele,
                    DataCreare = creationDate.ToString()
                };
                context.Media.Add(newMedia);
                context.SaveChanges();
            }
        }

        public void DeleteMedia (string path)
        {
            using (Model1Container context = new Model1Container())
            {
                Media oldMedia = context.Media.First(x => x.Path == path);
                context.Media.Remove(oldMedia);
                context.SaveChanges();
            }
        }

        public object ShowGridData ()
        {
            string result = "";
            using (var context = new Model1Container())
            {
                foreach (var data in context.Media)
                {
                    result = result + data.ToString() + "\n";
                }
            }
            return result;
        }

        public object ShowData ()
        {
            string result = "";
            string final = "";


            using (Model1Container context = new Model1Container())
            {
                foreach (var data in context.Media)
                {
                    result = result + data.ToString() + "\n";
                }
            }
            return result;
        }

        public string SaveFile ()
        {
            string result = "";
            using (Model1Container context = new Model1Container())
            {
                foreach (var data in context.Media)
                {
                    result = result + data.ToString() + "\n";
                }
            }
            string filename = @"D:\file.txt";
            FileInfo fileInfo = new FileInfo(filename);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }

                using (FileStream fs = fileInfo.Create())
                {
                    Byte[] txt = new UTF8Encoding(true).GetBytes("New file.\n");
                    fs.Write(txt, 0, txt.Length);
                    Byte[] author = new UTF8Encoding(true).GetBytes("Author Andra Paduraru\n");
                    fs.Write(author, 0, author.Length);
                    Byte[] data = new UTF8Encoding(true).GetBytes(result);
                    fs.Write(data, 0, data.Length);
                }
                string final = "Data saved!";
                return final;
        }
    }
}
