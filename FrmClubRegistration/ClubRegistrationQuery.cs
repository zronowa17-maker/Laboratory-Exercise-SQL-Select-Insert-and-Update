using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;

namespace FrmClubRegistration
{


    public class ClubRegistrationQuery
    {
        private SqlConnection sqlconnection;
        private SqlCommand sqlcommand;
        private SqlDataAdapter sqladapter;
        private DataTable datatable;
        private string connectionString;

        public DataTable dataTable;
        public BindingSource bindingSource;
        public string FirstName;
        public string LastName;
        public string MiddleName;
        public string Gender;
        public string Porgram;
        public string Age;


        public ClubRegistrationQuery()
        {
            sqlconnection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\ClubDB.mdf;Integrated Security=True");
            dataTable = new DataTable();
            bindingSource = new BindingSource();
        }

        public bool DisplayList()
        {
            string ViewClubMembers = "SELECT StudentID, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers1";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(ViewClubMembers, sqlconnection);
            dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            bindingSource.DataSource = dataTable;
            return true;


        }
        public bool RegisterStudent(int ID, long StudentID, string FirstName, string MiddleName, string LastName, int Age, string Gender, string Program)
        {
            string sql = "INSERT INTO ClubMembers1 VALUES(@ID, @StudentID, @FirstName, @MiddleName, @LastName, @Age, @Gender, @Program)";


            sqlcommand = new SqlCommand(sql, this.sqlconnection);


            sqlcommand.Parameters.AddWithValue("@ID", ID);
            sqlcommand.Parameters.AddWithValue("@StudentID", StudentID);
            sqlcommand.Parameters.AddWithValue("@FirstName", FirstName);
            sqlcommand.Parameters.AddWithValue("@MiddleName", MiddleName);
            sqlcommand.Parameters.AddWithValue("@LastName", LastName);
            sqlcommand.Parameters.AddWithValue("@Age", Age);
            sqlcommand.Parameters.AddWithValue("@Gender", Gender);
            sqlcommand.Parameters.AddWithValue("@Program", Program);

            // ... (Parameters.Add code) ...

            try
            {
                this.sqlconnection.Open();
                sqlcommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration DB Error: " + ex.Message);
                return false;
            }
            finally
            {
                if (this.sqlconnection.State == ConnectionState.Open)
                    this.sqlconnection.Close();
            }
        }

        public DataTable GetStudentIDs()
        {
            DataTable dt = new DataTable();

            try
            {
                
                sqlconnection.Open();

                string sql = "SELECT StudentID, FirstName, MiddleName, LastName, Age, Gender, Program FROM ClubMembers1";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlconnection);

                adapter.Fill(dt);

              
                return dt;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Database Load Error: " + ex.Message);
                return null; 
            }
            finally
            {
                
                if (sqlconnection != null && sqlconnection.State == ConnectionState.Open)
                {
                    sqlconnection.Close();
                }
            }
        }
    }
}
