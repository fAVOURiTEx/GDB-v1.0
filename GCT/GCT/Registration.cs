
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCT
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form Form1 = new Autorisation();
            Form1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля для регистрации!!!");
            }
            else
            {
                SqlConnection con = new SqlConnection(Clases.UserInformation.UserServer);
                con.Open();
                string str = "insert into Users(Nickname,Login,Password) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text +"')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("User registrated");

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
