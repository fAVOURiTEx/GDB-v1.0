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
    public partial class Autorisation : Form
    {
        public Autorisation()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }



        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(Clases.UserInformation.UserServer);
            try
            {
                string comand = string.Format("SELECT * FROM Users WHERE Login = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "';");
                SqlCommand check = new SqlCommand(comand, con);
                con.Open();

                if (check.ExecuteScalar() != null)
                {

                    string MyCommand = "SELECT idUser FROM Users WHERE Login = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "';";
                    SqlCommand Zapros = new SqlCommand(MyCommand, con);
                    Clases.UserInformation.UserID = (Int32)Zapros.ExecuteScalar();

                    string MyCommand2 = "SELECT Nickname FROM Users WHERE Login = '" + textBox1.Text + "' AND Password = '" + textBox2.Text + "';";
                    SqlCommand Zapros2 = new SqlCommand(MyCommand2, con);
                    Clases.UserInformation.Nickname = (String)Zapros2.ExecuteScalar();


                    Autorisation.ActiveForm.Hide();
                    Table MyForm3 = new Table();
                    MyForm3.ShowDialog();
                    Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пороль");
                }
            }
            finally
            {
                con.Close();
            }
        }

        



        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Login")
            {
                textBox1.Text = "";
            }

            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
            }

        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
            }

            if (textBox1.Text == "")
            {
                textBox1.Text = "Login";
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Login";
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form Form2 = new Registration();
            Form Form1 = new Autorisation();
            Form2.Show();
            this.Hide();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
