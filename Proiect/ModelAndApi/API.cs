using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using System.Text;

namespace ModelAndApi
{
    public class API
    {
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-A6HN40I;Initial Catalog=ProiectMedia;Integrated Security=True;");
        SqlCommand command;
        public object SaveMedia (string sql1)
        {
            string result = "";
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                command = new SqlCommand(sql1, connect);
                int x = command.ExecuteNonQuery();
                result = x.ToString() + "record(s) affected.";
                connect.Close();
                return result;
            }
            catch (Exception except)
            {
                connect.Close();
                result = except.Message;
                return result;
            }

        }

        public object DeleteMedia (string sql1, string pathToDelete)
        {
            string result = "";
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                command = new SqlCommand(sql1, connect);
                command.Parameters.AddWithValue("@path", pathToDelete);
                int x = command.ExecuteNonQuery();
                result = x.ToString() + "record(s) affected.";
                connect.Close();
                return result;
            }
            catch (Exception except)
            {
                connect.Close();
                result = except.Message;
                return result;
            }
        }

        public object ShowGridData (string sql1)
        {
            string result = "";
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql1, connect);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                return table;

            }
            catch (Exception except)
            {
                connect.Close();
                result = except.Message;
                return result;
            }
        }

        public object ShowData (string sql1)
        {
            string result = "";
            string final = "";
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                command = new SqlCommand(sql1, connect);
                int x = command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = result + "ID: " + reader["Id"].ToString() + "\n" +
                            "Path: " + reader["Path"].ToString() + "\n" +
                            "Moved: " + reader["Moved"].ToString() + "\n" +
                            "Evenimente: " + reader["Evenimente"].ToString() + "\n" +
                            "Persoane: " + reader["Persoane"].ToString() + "\n" +
                            "Peisaje: " + reader["Peisaje"].ToString() + "\n" +
                            "Locuri: " + reader["Locuri"].ToString() + "\n" +
                            "Altele: " + reader["Altele"].ToString() + "\n" +
                            "Data Creare: " + reader["DataCreare"].ToString() + "\n";
                    }
                    reader.Close();
                }
                final = x.ToString() + "record(s) affected.\n" + result;
                connect.Close();
                return final;
            }
            catch (Exception except)
            {
                connect.Close();
                result = except.Message;
                return result;
            }
        }

        public object SaveFile (string sql1)
        {
            string final = "";
            try
            {
                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sql1, connect);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
                DataTable table = new DataTable
                {
                    Locale = CultureInfo.InvariantCulture
                };
                dataAdapter.Fill(table);
                string result = string.Empty;

                foreach (DataColumn column in table.Columns)
                {
                    result += column.ColumnName + "\t\t";
                }

                result += "\n\n";
                foreach (DataRow row in table.Rows)
                {
                    foreach (DataColumn column in table.Columns)
                    {
                        result += row[column.ColumnName].ToString() + "\t";
                    }
                    result += "\n";
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
                final = "Data saved!";
                connect.Close();
                return final;
            }
            catch (Exception except)
            {
                connect.Close();
                final = except.Message;
                return final;
            }
        }
    }
}
