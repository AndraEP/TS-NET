using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace GUI
{
    public partial class Form1 : Form
    {
        MediaClient newMediaClient = new MediaClient();
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
                newMediaClient.SaveMedia(imgLocation, textBoxEvent.Text, textBoxPerson.Text, textBoxPeisaj.Text, textBoxLoc.Text, textBoxAltele.Text, dateTimePicker1.Value.Date);                

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
                string pathToDelete = textBoxDeleteEditPath.Text;
                newMediaClient.DeleteMedia(pathToDelete);
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            object result = newMediaClient.ShowData();
            MessageBox.Show(result.ToString());
        }

        private void buttonShowGridView_Click(object sender, EventArgs e)
        {
            DataTable dtTable = new DataTable();
            BindingSource binding = new BindingSource();
            dtTable.Columns.Add("Data", typeof(string));
            object result = newMediaClient.ShowGridData();
            if (result is string)
            {
                List<string> final = result.ToString().Split(new[] { "\n" }, StringSplitOptions.None).ToList();
                                
                foreach (var item in final)
                {
                    dtTable.Rows.Add(item);
                }

                binding.DataSource = dtTable;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = binding;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.Refresh();
            }
            else MessageBox.Show(result.ToString());
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
                string editEvent = textBoxDeleteEditEvent.Text;
                string editPerson = textBoxDeleteEditPerson.Text;
                string editPeisaj = textBoxDeleteEditPeisaj.Text;
                string editLoc = textBoxDeleteEditLoc.Text;
                string editAltele = textBoxDeleteEditAltele.Text;

                newMediaClient.EditData(pathForEdit, editEvent, editPerson, editPeisaj, editLoc, editAltele);
        }

        private void buttonSaveExternal_Click(object sender, EventArgs e)
        {
            MessageBox.Show(newMediaClient.SaveFile().ToString());
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            string editEvent = textBoxDeleteEditEvent.Text;
            string editPerson = textBoxDeleteEditPerson.Text;
            string editPeisaj = textBoxDeleteEditPeisaj.Text;
            string editLoc = textBoxDeleteEditLoc.Text;
            string editAltele = textBoxDeleteEditAltele.Text;
            string result = "";

            result += newMediaClient.FindData(result, editEvent, editPerson, editPeisaj, editLoc, editAltele);

            DataTable dtTable = new DataTable();
            BindingSource binding = new BindingSource();
            dtTable.Columns.Add("Data Found", typeof(string));
            if (result is string)
            {
                List<string> final = result.ToString().Split(new[] { "\t" }, StringSplitOptions.None).ToList();

                foreach (var item in final)
                {
                    dtTable.Rows.Add(item);
                }

                binding.DataSource = dtTable;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = binding;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dataGridView1.Refresh();
            }
            result = "";
        }
    }
}