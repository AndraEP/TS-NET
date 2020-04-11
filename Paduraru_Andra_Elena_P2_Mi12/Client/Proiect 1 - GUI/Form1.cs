using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Globalization;
using System.Diagnostics;
using ModelAndApi;
using System.Linq;

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
                useApi.SaveMedia(imgLocation, textBoxEvent.Text, textBoxPerson.Text, textBoxPeisaj.Text, textBoxLoc.Text, textBoxAltele.Text, dateTimePicker1.Value.Date);                

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
                string pathToDelete = textBoxDeleteEditPath.Text;
                useApi.DeleteMedia(pathToDelete);
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {

            BindingSource bindingSource = new BindingSource();
            dataGridView1.DataSource = bindingSource;
            object result = useApi.ShowGridData();
            if (!(result is string))
            {
                bindingSource.DataSource = result;
            }
            else MessageBox.Show(result.ToString());
        }

        private void buttonShowGridView_Click(object sender, EventArgs e)
        {
            object result = useApi.ShowData();
            MessageBox.Show(result.ToString());
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

                string pathForEdit = textBoxDeleteEditPath.Text;
                using (Model1Container context = new Model1Container())
                {
                    foreach (var data in context.Media)
                    {
                        Media toChange = context.Media.First(x => x.Path == pathForEdit);
                        string test = toChange.ToString();

                        if (!String.IsNullOrEmpty(test))
                        {
                            string editEvent = textBoxDeleteEditEvent.Text;
                            string editPerson = textBoxDeleteEditPerson.Text;
                            string editPeisaj = textBoxDeleteEditPeisaj.Text;
                            string editLoc = textBoxDeleteEditLoc.Text;
                            string editAltele = textBoxDeleteEditAltele.Text;

                            if (!String.IsNullOrEmpty(editEvent))
                            {
                                string eventChange = toChange.Evenimente.ToString();
                                eventChange = eventChange + ", " + editEvent;
                                toChange.Evenimente = eventChange;
                            }

                            if (!String.IsNullOrEmpty(editPerson))
                            {
                                string persChange = toChange.Persoane.ToString();
                                persChange = persChange + ", " + editPerson;
                                toChange.Persoane = persChange;
                            }

                            if (!String.IsNullOrEmpty(editPeisaj))
                            {
                                string peisajChange = toChange.Peisaje.ToString();
                                peisajChange = peisajChange + ", " + editPeisaj;
                                toChange.Peisaje = peisajChange;
                            }

                            if (!String.IsNullOrEmpty(editLoc))
                            {
                                string locChange = toChange.Locuri.ToString();
                                locChange = locChange + ", " + editLoc;
                                toChange.Locuri = locChange;
                            }

                            if (!String.IsNullOrEmpty(editAltele))
                            {
                                string alteleChange = toChange.Altele.ToString();
                                alteleChange = alteleChange + ", " + editAltele;
                                toChange.Persoane = alteleChange;
                            }
                            context.SaveChanges();
                        }
                    }
                }
        }

        private void buttonSaveExternal_Click(object sender, EventArgs e)
        {
            MessageBox.Show(useApi.SaveFile().ToString());
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string editEvent = textBoxDeleteEditEvent.Text;
            string editPerson = textBoxDeleteEditPerson.Text;
            string editPeisaj = textBoxDeleteEditPeisaj.Text;
            string editLoc = textBoxDeleteEditLoc.Text;
            string editAltele = textBoxDeleteEditAltele.Text;
            string result = "";
            using (Model1Container context = new Model1Container())
            {
                foreach (var data in context.Media)
                {
                    string test = context.Media.ToString();
                    if (!String.IsNullOrEmpty(test))
                    {
                        
                        if (!String.IsNullOrEmpty(editEvent))
                        {
                            Media findMedia = context.Media.First(x => x.Evenimente == editEvent);
                            string eventFind = findMedia.ToString();
                            result = result + eventFind + "\n";
                        }

                        if (!String.IsNullOrEmpty(editPerson))
                        {
                            Media findMedia = context.Media.First(x => x.Persoane == editPerson);
                            string personFind = findMedia.ToString();
                            result = result + personFind + "\n";
                        }

                        if (!String.IsNullOrEmpty(editPeisaj))
                        {
                            Media findMedia = context.Media.First(x => x.Peisaje == editPeisaj);
                            string peisajFind = findMedia.ToString();
                            result = result + peisajFind + "\n";
                        }

                        if (!String.IsNullOrEmpty(editLoc))
                        {
                            Media findMedia = context.Media.First(x => x.Locuri == editLoc);
                            string locFind = findMedia.ToString();
                            result = result + locFind + "\n";
                        }

                        if (!String.IsNullOrEmpty(editAltele))
                        {
                            Media findMedia = context.Media.First(x => x.Altele == editAltele);
                            string alteleFind = findMedia.ToString();
                            result = result + alteleFind + "\n";
                        }
                    }
                }
                MessageBox.Show(result);
            }
        }
    }
}