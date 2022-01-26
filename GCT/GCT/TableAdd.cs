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
    public partial class TableAdd : Form
    {
        public TableAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Пожалуйста, заполните все обязательные!!!");
            }
            else
            {
                SqlConnection con = new SqlConnection(Clases.UserInformation.UserServer);
                con.Open();
                string str = "insert into GameTable(idUser,Game,Difficulty,System,Date,Remark) values ('" + Clases.UserInformation.UserID + "','" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Information added");

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void buttonb_Click(object sender, EventArgs e)
        {
            Form Form4 = new TableAdd();
            Form Form3 = new Table();
            Form3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Form3 = new Table();
            Form3.Show();
            this.Hide();
        }
    }
}
