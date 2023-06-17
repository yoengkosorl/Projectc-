using System.Linq.Expressions;

namespace pos
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string st = treeView1.SelectedNode.Text;
            switch (st)
            {
                case "User":
                    {
                        user student = new user();
                        student.MdiParent = this;
                        student.WindowState = FormWindowState.Maximized;
                        student.Show();
                    }
                    break;
                case "":
                    // code block
                    break;
                default:
                    // code block
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            clsConection.con.ConnectionString = "Data Source=DESKTOP-JI8RNQM;Initial Catalog=pos; Integrated Security=true;";
            try
            {
                clsConection.con.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("Erorr", "Connection error", MessageBoxButtons.OK);
            }
        }

        private void main_Load(object sender, EventArgs e)
        {
            clsConection.con.ConnectionString = "Data Source=DESKTOP-JI8RNQM;Initial Catalog=pos; Integrated Security=true;";
            try
            {
                clsConection.con.Open();
            }
            catch (Exception)
            {

                MessageBox.Show("Erorr", "Connection error", MessageBoxButtons.OK);
            }
        }
    }
}