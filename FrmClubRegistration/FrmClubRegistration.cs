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

namespace FrmClubRegistration
{
    public partial class FrmClubRegistration : Form
    {
        private SqlConnection sqlconnection;
        private SqlCommand sqlcommand;

        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();
        }

        private long StudentID;

        public FrmClubRegistration()
        {
            InitializeComponent();
        }
        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            sqlcommand = new SqlCommand("INSERT INTO ClubMembers VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)", sqlconnection);
            sqlcommand.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
            sqlcommand.Parameters.Add("@StudentID", SqlDbType.BigInt).Value = StudentID; 
            sqlcommand.Parameters.Add("@RegistrationID", SqlDbType.BigInt).Value = StudentID; 
            sqlcommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = FirstName;
            sqlcommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = MiddleName;
            sqlcommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = LastName;
            sqlcommand.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            sqlcommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = Gender;
            sqlcommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = Program;
            sqlconnection.Open();
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();

            return true;
        }
    }
}










        