using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrmClubRegistration
{
    public class ClubRegistrationQuery
    {
        private SqlConnection sqlconnection;
        private SqlCommand sqlcommand;
        private SqlDataAdapter sqladapter;
        private DataTable datatable;
        private string connectionString = "C:\\USERS\\PANGAN.347793\\SOURCE\\REPOS\\FRMCLUBREGISTRATION\\FRMCLUBREGISTRATION\\CLUBDB.MDF";

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
            connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + connectionString + ";Integrated Security=True;Connect Timeout=30";
            sqlconnection = new SqlConnection(connectionString);
            datatable = new DataTable();
            bindingSource = new BindingSource();
        }

    }
}
