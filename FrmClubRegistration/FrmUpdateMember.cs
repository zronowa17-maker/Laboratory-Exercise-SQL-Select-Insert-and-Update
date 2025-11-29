using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmClubRegistration
{
    public partial class FrmUpdateMember : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private DataTable studentData;
        public FrmUpdateMember()
        {
            InitializeComponent();
            clubRegistrationQuery = new ClubRegistrationQuery();
        }
        private void comboBoxStudentID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStudent.SelectedIndex > -1 && studentData != null)
            {
                
                string selectedID = comboBoxStudent.SelectedValue.ToString();

                
                DataRow[] selectedRows = studentData.Select($"StudentID = '{selectedID}'");

                if (selectedRows.Length > 0)
                {
                    DataRow row = selectedRows[0]; 
                    textBox2.Text = row["LastName"].ToString();

                  
                    textBox3.Text = row["FirstName"].ToString();

                  
                    textBox4.Text = row["MiddleName"].ToString();

                 
                    textBox5.Text = row["Age"].ToString();

                    comboBox1.Text = row["Gender"].ToString();

                    
                    comboBox2.Text = row["Program"].ToString();
                }
            }
            else
            {
               
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            studentData = clubRegistrationQuery.GetStudentIDs();

            if (studentData != null)
            {
                comboBoxStudent.DataSource = studentData;

              
                comboBoxStudent.DisplayMember = "StudentID";

              
                comboBoxStudent.ValueMember = "StudentID";

               
                comboBoxStudent.SelectedIndex = -1;
            }
        }
    }
}
