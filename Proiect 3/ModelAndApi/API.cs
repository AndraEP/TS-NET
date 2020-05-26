using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace ModelAndApi
{
    public class API
    {
        public void SaveMedia(string path, string events, string persons, string peisaj, string locatie, string altele, DateTime creationDate)
        {
            int check = 1;
            using (var context = new Model1Container())
            {
                foreach (var data in context.Media)
                {
                    if (data.Path.ToString() == path)
                    {
                        check = 0;
                    }
                }

                if (check == 1)
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
        }

        public void DeleteMedia(string path)
        {
            using (var context = new Model1Container())
            {
                Media oldMedia = context.Media.First(x => x.Path == path);
                context.Media.Remove(oldMedia);
                context.SaveChanges();
            }
        }

        public object ShowGridData()
        {
            string result = "";
            using (var context = new Model1Container())
            {
                foreach (var data in context.Media)
                {
                    result = result + "ID: " + data.Id.ToString() + ";" +
                        " Path: " + data.Path.ToString() + ";" +
                        " Moved: " + data.Moved.ToString() + ";" +
                        " Evenimente: " + data.Evenimente.ToString() + ";" +
                        " Persoane: " + data.Persoane.ToString() + ";" +
                        " Peisaje: " + data.Peisaje.ToString() + ";" +
                        " Locuri: " + data.Locuri.ToString() + ";" +
                        " Altele: " + data.Altele.ToString() + ";" +
                        " Data Creare: " + data.DataCreare.ToString() + "\n";
                }
            }
            return result;
        }

        public object ShowData()
        {
            string result = "";

            using (var context = new Model1Container())
            {
                foreach (var data in context.Media)
                {
                    result = result + "ID: " + data.Id.ToString() + "\n" +
                        "Path: " + data.Path.ToString() + "\n" +
                        "Moved: " + data.Moved.ToString() + "\n" +
                        "Evenimente: " + data.Evenimente.ToString() + "\n" +
                        "Persoane: " + data.Persoane.ToString() + "\n" +
                        "Peisaje: " + data.Peisaje.ToString() + "\n" +
                        "Locuri: " + data.Locuri.ToString() + "\n" +
                        "Altele: " + data.Altele.ToString() + "\n" +
                        "Data Creare: " + data.DataCreare.ToString() + "\n\n";
                }
            }
            return result;
        }

        public string SaveFile()
        {
            string result = "";
            using (var context = new Model1Container())
            {
                foreach (var data in context.Media)
                {
                    result = result + "ID: " + data.Id.ToString() + "\n" +
                        "Path: " + data.Path.ToString() + "\n" +
                        "Moved: " + data.Moved.ToString() + "\n" +
                        "Evenimente: " + data.Evenimente.ToString() + "\n" +
                        "Persoane: " + data.Persoane.ToString() + "\n" +
                        "Peisaje: " + data.Peisaje.ToString() + "\n" +
                        "Locuri: " + data.Locuri.ToString() + "\n" +
                        "Altele: " + data.Altele.ToString() + "\n" +
                        "Data Creare: " + data.DataCreare.ToString() + "\n\n";
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

        public void EditData(string pathForEdit, string editEvent, string editPerson, string editPeisaj, string editLoc, string editAltele)
        {
            using (var context = new Model1Container())
            {
                IQueryable<Media> mediaList = from elem in context.Media where elem.Path.ToString() == pathForEdit select elem;
                foreach (var data in mediaList.ToList())
                {
                    string test = data.ToString();

                    if (!String.IsNullOrEmpty(test) && data.Path.ToString() == pathForEdit)
                    {
                        if (!String.IsNullOrEmpty(editEvent))
                        {
                            string eventChange = data.Evenimente.ToString();
                            eventChange = eventChange + ", " + editEvent;
                            data.Evenimente = eventChange;
                        }

                        if (!String.IsNullOrEmpty(editPerson))
                        {
                            string persChange = data.Persoane.ToString();
                            persChange = persChange + ", " + editPerson;
                            data.Persoane = persChange;
                        }

                        if (!String.IsNullOrEmpty(editPeisaj))
                        {
                            string peisajChange = data.Peisaje.ToString();
                            peisajChange = peisajChange + ", " + editPeisaj;
                            data.Peisaje = peisajChange;
                        }

                        if (!String.IsNullOrEmpty(editLoc))
                        {
                            string locChange = data.Locuri.ToString();
                            locChange = locChange + ", " + editLoc;
                            data.Locuri = locChange;
                        }

                        if (!String.IsNullOrEmpty(editAltele))
                        {
                            string alteleChange = data.Altele.ToString();
                            alteleChange = alteleChange + ", " + editAltele;
                            data.Persoane = alteleChange;
                        }
                        context.SaveChanges();
                    }
                }
            }
        }

        public string FindData(string result, string editEvent, string editPerson, string editPeisaj, string editLoc, string editAltele)
        {
            using (var context = new Model1Container())
            {
                IQueryable<Media> mediaList = from elem in context.Media select elem;
                foreach (var data in mediaList.ToList())
                {
                    string test = data.ToString();
                    if (!String.IsNullOrEmpty(test))
                    {

                        if ((!String.IsNullOrEmpty(editEvent) && data.Evenimente.ToString().Contains(editEvent)) || 
                            (!String.IsNullOrEmpty(editPerson) && data.Persoane.ToString().Contains(editPerson)) ||
                            (!String.IsNullOrEmpty(editPeisaj) && data.Peisaje.ToString().Contains(editPeisaj)) ||
                            (!String.IsNullOrEmpty(editLoc) && data.Locuri.ToString().Contains(editLoc)) ||
                            (!String.IsNullOrEmpty(editAltele) && data.Altele.ToString().Contains(editAltele)))
                        {
                            result = result + "ID: " + data.Id.ToString() + "\n" +
                                " Path: " + data.Path.ToString() + "\n" +
                                " Moved: " + data.Moved.ToString() + "\n" +
                                " Evenimente: " + data.Evenimente.ToString() + "\n" +
                                " Persoane: " + data.Persoane.ToString() + "\n" +
                                " Peisaje: " + data.Peisaje.ToString() + "\n" +
                                " Locuri: " + data.Locuri.ToString() + "\n" +
                                " Altele: " + data.Altele.ToString() + "\n" +
                                " Data Creare: " + data.DataCreare.ToString() + "\t";
                        }
                    }
                }
            }
            return result;
        }
    }
}
