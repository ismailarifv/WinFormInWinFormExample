using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WinFormInWinFormExample
{
    public partial class Form1 : Form
    {
        SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-6I3C0B5\SQLEXPRESS;initial catalog=schoolDb;Integrated Security=True;");
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            login_lbl.Visible = false;

        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            db.Open();

            SqlCommand cmd = new SqlCommand("Login", db);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar,250).Value=email_txt.Text;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar,250).Value=password_txt.Text;

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                Form2 form2 = new Form2();
                form2.ShowDialog();
            }
            else
            {
                MessageBox.Show("Giriş Hatalı");
            }
            db.Close();
        }
    }
}
