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
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers1();
            ClearInputs();

        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers1();
        }

        private long StudentID;

        private void button1_Click(object sender, EventArgs e)
        {
            ID = RegistrationID();
            StudentID = Convert.ToInt64(textBox1.Text);
            FirstName = textBox3.Text;
            MiddleName = textBox4.Text;
            LastName = textBox2.Text;
            Age = Convert.ToInt32(textBox5.Text);
            Gender = comboBox2.Text;
            Program = comboBox1.Text;

            
            bool isRegistered = clubRegistrationQuery.RegisterStudent(
                ID,
                StudentID,
                FirstName,
                MiddleName,
                LastName,
                Age,
                Gender,
                Program
            );

            if (isRegistered)
            {
                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

               
                RefreshListOfClubMembers1();
            }
            else
            {
                MessageBox.Show("Registration failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FrmUpdateMember updateForm = new FrmUpdateMember();

           
            updateForm.ShowDialog();
            RefreshListOfClubMembers1();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                
                textBox1.Text = row.Cells[0].Value.ToString();

               
                textBox2.Text = row.Cells[3].Value.ToString(); 
                
                textBox3.Text = row.Cells[1].Value.ToString();

                
                textBox4.Text = row.Cells[2].Value.ToString();

                
                textBox5.Text = row.Cells[4].Value.ToString();

                
                comboBox2.Text = row.Cells[5].Value.ToString();

               
                comboBox1.Text = row.Cells[6].Value.ToString();
            }
        }

        public FrmClubRegistration()
        {
            InitializeComponent();
        }
        public void RefreshListOfClubMembers1()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

        private int RegistrationID()
        {
            count++;
            return count;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ClearInputs()
        {
            
            textBox1.Clear(); 
            textBox2.Clear(); 
            textBox3.Clear(); 
            textBox4.Clear(); 
            textBox5.Clear(); 

            comboBox1.SelectedIndex = -1; 
            comboBox2.SelectedIndex = -1; 

           
            textBox1.Focus();
        }

    }
}










        