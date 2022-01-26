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
    public partial class Table : Form
    {
        public Table()
        {
            InitializeComponent();
            string gridzap = "SELECT * FROM GameTable WHERE idUser = " + Clases.UserInformation.UserID + ";";
            LoadData();
        }

        private void LoadData()
        {
            string connectString = Clases.UserInformation.UserServer;

            SqlConnection myConnection = new SqlConnection(connectString);

            myConnection.Open();

            string query = "SELECT Num,Game,Difficulty,System,Date,Remark FROM GameTable WHERE idUser =" + Clases.UserInformation.UserID + ";";

            SqlCommand command = new SqlCommand(query, myConnection);

            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();

            while (reader.Read())
            {
                data.Add(new string[6]);

                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
                data[data.Count - 1][5] = reader[5].ToString();

            }

            reader.Close();

            myConnection.Close();

            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mgdbDataSet.GameTable". При необходимости она может быть перемещена или удалена.
            this.gameTableTableAdapter.Fill(this.mgdbDataSet.GameTable);
            label4.Text = "" + Clases.UserInformation.UserID;
            label2.Text = "" + Clases.UserInformation.Nickname;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Table.ActiveForm.Close();
            TableAdd MyForm4 = new TableAdd();
            MyForm4.Show();
            
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
