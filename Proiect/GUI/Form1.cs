using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using ModelAndApi;

namespace GUI
{
    public partial class Form1 : Form
    {
        API useApi = new API();
        SqlConnection connect = new SqlConnection("Data Source=DESKTOP-A6HN40I;Initial Catalog=ProiectMedia;Integrated Security=True;");
        SqlCommand command;
        string imgLocation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog fileDiag = new OpenFileDialog();
                fileDiag.Filter = "JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|PNG Files (*.png)|*.png|MP4 Files (*.mp4)|*.mp4|All Files (*.*)|*.*";
                fileDiag.Title = "Select Media";
                if (fileDiag.ShowDialog() == DialogResult.OK)
                {
                    imgLocation = Path.GetFullPath(fileDiag.FileName.ToString());
                    pictureBox.ImageLocation = imgLocation;
                }
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            
                byte[] img = null;
                FileStream fs = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string sql1 = "insert into Media (Path, Moved, Evenimente, Persoane, Peisaje, Locuri, Altele, DataCreare) values ('" + imgLocation + "', 0, '" + textBoxEvent.Text + "', '" + textBoxPerson.Text + "', '" + textBoxPeisaj.Text + "', '" + textBoxLoc.Text + "', '" + textBoxAltele.Text + "', '" + dateTimePicker1.Value.Date + "')";
                MessageBox.Show(useApi.SaveMedia(sql1).ToString());

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
                string pathToDelete = textBoxDeleteEditPath.Text;
                string sql1 = "delete from Media where Path = @path";
                MessageBox.Show(useApi.DeleteMedia(sql1, pathToDelete).ToString());
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {

            string sql1 = "select * from Media";
            BindingSource bindingSource = new BindingSource();
            dataGridView1.DataSource = bindingSource;
            object result = useApi.ShowGridData(sql1);
            if (!(result is string))
            {
                bindingSource.DataSource = result;
            }
            else MessageBox.Show(result.ToString());
        }

        private void buttonShowGridView_Click(object sender, EventArgs e)
        {
                string sql1 = "select * from Media";
                MessageBox.Show(useApi.ShowData(sql1).ToString());
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = textBoxOpenPath.Text;
                Process.Start(@filePath);
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                string pathForEdit = textBoxDeleteEditPath.Text;
                string sql1 = "select * from Media where Path = @path";

                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                command = new SqlCommand(sql1, connect);
                command.Parameters.AddWithValue("@path", pathForEdit);
                int x = command.ExecuteNonQuery();
                if (x == 0)
                {
                    connect.Close();
                    MessageBox.Show(x.ToString() + "record(s) affected.\n" + "There is no media with such path!");
                }
                else
                {
                    string editEvent = textBoxDeleteEditEvent.Text;
                    string editPerson = textBoxDeleteEditPerson.Text;
                    string editPeisaj = textBoxDeleteEditPeisaj.Text;
                    string editLoc = textBoxDeleteEditLoc.Text;
                    string editAltele = textBoxDeleteEditAltele.Text;

                    if (!String.IsNullOrEmpty(editEvent))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Evenimente from Media where Path = @path";
                        command2 = new SqlCommand(sql2, connect);
                        command2.Parameters.AddWithValue("@path", pathForEdit);
                        string result = "";

                        using (SqlDataReader reader1 = command.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                result = result + reader1["Evenimente"].ToString() + ", " + editEvent;
                            }
                            reader1.Close();
                        }
                        string sql3 = "";
                        MessageBox.Show(result);
                        sql3 = "update Media set Evenimente = @data where Path = @path";
                        SqlCommand command3;
                        command3 = new SqlCommand(sql3, connect);
                        command3.Parameters.AddWithValue("@data", result);
                        command3.Parameters.AddWithValue("@path", pathForEdit);
                        x = command3.ExecuteNonQuery();
                        MessageBox.Show(x.ToString() + "record(s) affected.");

                    }
                                       

                    if (!String.IsNullOrEmpty(editPerson))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Persoane from Media where Path = @path";
                        command2 = new SqlCommand(sql2, connect);
                        command2.Parameters.AddWithValue("@path", pathForEdit);
                        string result = "";

                        using (SqlDataReader reader1 = command.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                result = result + reader1["Persoane"].ToString() + ", " + editPerson;
                            }
                            reader1.Close();
                        }
                        string sql3 = "";
                        MessageBox.Show(result);
                        sql3 = "update Media set Persoane = @data where Path = @path";
                        SqlCommand command3;
                        command3 = new SqlCommand(sql3, connect);
                        command3.Parameters.AddWithValue("@data", result);
                        command3.Parameters.AddWithValue("@path", pathForEdit);
                        x = command3.ExecuteNonQuery();
                        MessageBox.Show(x.ToString() + "record(s) affected.");
                    }

                    if (!String.IsNullOrEmpty(editPeisaj))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Peisaje from Media where Path = @path";
                        command2 = new SqlCommand(sql2, connect);
                        command2.Parameters.AddWithValue("@path", pathForEdit);
                        string result = "";

                        using (SqlDataReader reader1 = command.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                result = result + reader1["Peisaje"].ToString() + ", " + editPeisaj;
                            }
                            reader1.Close();
                        }
                        string sql3 = "";
                        MessageBox.Show(result);
                        sql3 = "update Media set Peisaje = @data where Path = @path";
                        SqlCommand command3;
                        command3 = new SqlCommand(sql3, connect);
                        command3.Parameters.AddWithValue("@data", result);
                        command3.Parameters.AddWithValue("@path", pathForEdit);
                        x = command3.ExecuteNonQuery();
                        MessageBox.Show(x.ToString() + "record(s) affected.");
                    }

                    if (!String.IsNullOrEmpty(editLoc))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Locuri from Media where Path = @path";
                        command2 = new SqlCommand(sql2, connect);
                        command2.Parameters.AddWithValue("@path", pathForEdit);
                        string result = "";

                        using (SqlDataReader reader1 = command.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                result = result + reader1["Locuri"].ToString() + ", " + editLoc;
                            }
                            reader1.Close();
                        }
                        string sql3 = "";
                        MessageBox.Show(result);
                        sql3 = "update Media set Locuri = @data where Path = @path";
                        SqlCommand command3;
                        command3 = new SqlCommand(sql3, connect);
                        command3.Parameters.AddWithValue("@data", result);
                        command3.Parameters.AddWithValue("@path", pathForEdit);
                        x = command3.ExecuteNonQuery();
                        MessageBox.Show(x.ToString() + "record(s) affected.");
                    }

                    if (!String.IsNullOrEmpty(editAltele))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Altele from Media where Path = @path";
                        command2 = new SqlCommand(sql2, connect);
                        command2.Parameters.AddWithValue("@path", pathForEdit);
                        string result = "";

                        using (SqlDataReader reader1 = command.ExecuteReader())
                        {
                            while (reader1.Read())
                            {
                                result = result + reader1["Altele"].ToString() + ", " + editAltele;
                            }
                            reader1.Close();
                        }
                        string sql3 = "";
                        MessageBox.Show(result);
                        sql3 = "update Media set Altele = @data where Path = @path";
                        SqlCommand command3;
                        command3 = new SqlCommand(sql3, connect);
                        command3.Parameters.AddWithValue("@data", result);
                        command3.Parameters.AddWithValue("@path", pathForEdit);
                        x = command3.ExecuteNonQuery();
                        MessageBox.Show(x.ToString() + "record(s) affected.");
                    }

                }
                connect.Close();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }

        private void buttonSaveExternal_Click(object sender, EventArgs e)
        {

                string sql1 = "select * from Media";
                MessageBox.Show(useApi.SaveFile(sql1).ToString());
                connect.Close();
            
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                string sql1 = "select * from Media";

                if (connect.State != ConnectionState.Open)
                {
                    connect.Open();
                }
                command = new SqlCommand(sql1, connect);
                int x = command.ExecuteNonQuery();
                if (x == 0)
                {
                    connect.Close();
                    MessageBox.Show(x.ToString() + "record(s) affected.\n" + "There is no media!");
                }
                else
                {
                    string editEvent = textBoxDeleteEditEvent.Text;
                    string editPerson = textBoxDeleteEditPerson.Text;
                    string editPeisaj = textBoxDeleteEditPeisaj.Text;
                    string editLoc = textBoxDeleteEditLoc.Text;
                    string editAltele = textBoxDeleteEditAltele.Text;
                    string result = "";

                    if (!String.IsNullOrEmpty(editEvent))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Evenimente from Media";
                        command2 = new SqlCommand(sql2, connect);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["Evenimente"].ToString().Contains(editEvent))
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
                            result += "\n";
                        }
                    }
                                       

                    if (!String.IsNullOrEmpty(editPerson))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Persoane from Media";
                        command2 = new SqlCommand(sql2, connect);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["Persoane"].ToString().Contains(editPerson))
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
                            result += "\n";
                        }
                    }

                    if (!String.IsNullOrEmpty(editPeisaj))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Peisaje from Media";
                        command2 = new SqlCommand(sql2, connect);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["Peisaje"].ToString().Contains(editPeisaj))
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
                            result += "\n";
                        }
                    }

                    if (!String.IsNullOrEmpty(editLoc))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Locuri from Media";
                        command2 = new SqlCommand(sql2, connect);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["Locuri"].ToString().Contains(editLoc))
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
                            result += "\n";
                        }
                    }

                    if (!String.IsNullOrEmpty(editAltele))
                    {
                        string sql2 = "";
                        SqlCommand command2;
                        sql2 = "select Altele from Media";
                        command2 = new SqlCommand(sql2, connect);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (reader["Altele"].ToString().Contains(editAltele))
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
                            result += "\n";
                        }
                    }
                    MessageBox.Show(result);
                }
                connect.Close();
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }
        }
    }
}