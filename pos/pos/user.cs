using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pos
{
    public partial class user : Form
    {
        clsUser users = new clsUser();
        int iduser = 0;
        public user()
        {
            InitializeComponent();
        }
        private void clear()
        {
            txtfullname.Focus();
            foreach (var c in this.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }
        }

        private void validate()
        {
            if (txtfullname.Text == "" ||  txtpassword.Text ==" ")
            {
                MessageBox.Show("Fullname Or password can't blank");
                
            }
        }

        private void user_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da = new SqlDataAdapter("Select id,fullname ,email, phone From tblusers", clsConection.con);

            DataTable dt = new DataTable();
            try
            {
                da.Fill(dt);
                dvguser.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error.....! cannot Opne Data source.", "Connection");
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            
            users.fullname = txtfullname.Text;
            users.phone = txtphone.Text;
            users.email = txtemal.Text;
            users.password = txtpassword.Text;

            if (users.insert() == true)
            {
                clear();
                user_Load(null, null);
                MessageBox.Show("Data insert Successful..!");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            users.Id = iduser;
            users.fullname = txtfullname.Text;
            users.phone = txtphone.Text;
            users.email = txtemal.Text;
            users.password = txtpassword.Text;
            if (users.update() == true)
            {
                clear();
                user_Load(null, null);
                MessageBox.Show("Data Update Successful..!");
            }
        }

        private void dvguser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                iduser = int.Parse(dvguser.CurrentRow.Cells[0].Value.ToString());
                txtfullname.Text = dvguser.CurrentRow.Cells[1].Value.ToString();
                txtemal.Text = dvguser.CurrentRow.Cells[2].Value.ToString();
                txtphone.Text = dvguser.CurrentRow.Cells[3].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Rang", "out of Rang ...!", MessageBoxButtons.OK);
                throw;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            users.Id = iduser;
            if (users.delete() == true)
            {
                clear();
                user_Load(null, null);
                MessageBox.Show("Data Update Successful..!");
            }
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            string find = txtsearch.Text;

            dvguser.DataSource = users.GetData(find);
        }
    }
}
