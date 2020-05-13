using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PostComment;

namespace ClientPostComment
{
    public partial class Form1 : Form
    {
        List<Post> posts = new List<Post>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            posts = LoadPosts().ToList<Post>();
            dataGridView1.DataSource = posts;
            dataGridView1.Columns[0].Width = 0;
            if (dataGridView1.Rows.Count > 0)
                dataGridView2.DataSource = posts[0].Comments;
        }

        private static PostComment.Post[] LoadPosts()
        {
            PostCommentClient pc = new PostCommentClient();
            var p = pc.GetPosts();
            return p;
        }
        // Handler pentru evenimentul CellMouseClick din DatagridView numit dataGridView1
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            // Se afiseaza Comment-urile pentru Post-ul selectat
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = posts[e.RowIndex].Comments;
        }

    }
}
