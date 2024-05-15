using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Registation_and_login_with_CRUD
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
           
        }
        private void Register_Load(object sender, EventArgs e)
        {
           
        }
        private void LoadAllData()
        {
            SqlConnection con = new SqlConnection("Data Source=HACHIBURRAHMAN\\SQLEXPRESS;Initial Catalog=loginpage;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string query = "SELECT * FROM register";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            con.Close();
        }

        



        private void button1_Click(object sender, EventArgs e)
            {
            SqlConnection con = new SqlConnection("Data Source=HACHIBURRAHMAN\\SQLEXPRESS;Initial Catalog=loginpage;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            //string querry = "SELECT COUNT (*) FROM  WHERE username=@username AND password =@password";
            string insertQuery = "INSERT INTO register VALUES (@email,@username,@password)";
            SqlCommand cmd = new SqlCommand(insertQuery, con);
            cmd.Parameters.AddWithValue("@email", register_email.Text);
            cmd.Parameters.AddWithValue("@username", register_username.Text);
            cmd.Parameters.AddWithValue("@password", register_password.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Register");
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=HACHIBURRAHMAN\\SQLEXPRESS;Initial Catalog=loginpage;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string updateQuery = "UPDATE register SET email = @email WHERE username = @username AND password= @password";
            SqlCommand command = new SqlCommand(updateQuery, con);
            command.Parameters.AddWithValue("@email", register_email.Text);
            command.Parameters.AddWithValue("@username", register_username.Text);
            command.Parameters.AddWithValue("@password", register_password.Text);
            int rowsAffected = command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Updated");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=HACHIBURRAHMAN\\SQLEXPRESS;Initial Catalog=loginpage;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string deleteQuery = "DELETE FROM register WHERE email = @email AND username = @username AND password = @password";
            SqlCommand command = new SqlCommand(deleteQuery, con);
            command.Parameters.AddWithValue("@email", register_email.Text);
            command.Parameters.AddWithValue("@username", register_username.Text);
            command.Parameters.AddWithValue("@password", register_password.Text);
            int rowsAffected = command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=HACHIBURRAHMAN\\SQLEXPRESS;Initial Catalog=loginpage;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string searchQuery = "SELECT * FROM register WHERE email = @email AND username = @username AND password = @password";
            SqlCommand command = new SqlCommand(searchQuery, con);
            command.Parameters.AddWithValue("@email", register_email.Text);
            command.Parameters.AddWithValue("@username", register_username.Text);
            command.Parameters.AddWithValue("@password", register_password.Text);
            SqlDataReader reader = command.ExecuteReader();
            con.Close();
            DataTable dataTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                adapter.Fill(dataTable);
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable;

            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("No matching records found.");
            }
            else if (dataTable.Rows.Count == 1)
            {
                MessageBox.Show("Exact match found.");
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadAllData();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form1 dFrom = new Form1();
            dFrom.Show();
            this.Hide();
        }
    }
}
