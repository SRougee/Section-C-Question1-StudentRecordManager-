using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Section_C_Question1__StudentRecordManager_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate student number
            if (!double.TryParse(txtStudentNo.Text, out double studentNo) || studentNo <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for student number.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            // Full Name validation
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter a valid full name.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }
            // Course validation
            if (string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                MessageBox.Show("Please enter a valid course.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // student number, full name, and course are valid, proceed to add to the list in StudentDetails
            // Update the list sothat it is multidimentsioanal and can store the student number, full name, and course for each student.
            StudentDetails studentDetails = new StudentDetails();
            studentDetails.studentDetailsListNo.Add(txtStudentNo.Text);
            studentDetails.studentDetailsListFullName.Add(txtFullName.Text);
            studentDetails.studentDetailsListCourse.Add(txtCourse.Text);

            // Display the Student regeistration status on the label 
            lblStatus.Text = "Student registered successfully!";
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //When this button is clicked, the student details will be removed from the list in StudentDetails accordning to the student number entered in the txtStudentNo TextBox.
            // Validate student number
            if (!double.TryParse(txtStudentNo.Text, out double studentNo) || studentNo <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for student number.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            StudentDetails studentDetails = new StudentDetails();
            // Check if the student number exists in the list
            try
            {
                int index = studentDetails.studentDetailsListNo.IndexOf(txtStudentNo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the student: " + ex.Message,
                                "Search Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                if (studentDetails != null)
                {
                    int index = studentDetails.studentDetailsListNo.IndexOf(txtStudentNo.Text);
                    if (index >= 0)
                    {
                        // Student found, display Student Found in the lblStatus
                        studentDetails.studentDetailsListNo.RemoveAt(index);
                        studentDetails.studentDetailsListFullName.RemoveAt(index);
                        studentDetails.studentDetailsListCourse.RemoveAt(index);

                        lblStatus.Text = "Student Found";

                    }
                    else
                    {
                        // Student not found in the lblStatus
                        lblStatus.Text = "Student Not Found";
                    }
                }
            }

            
          
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //When this button is clicked, the student details will be searched from the list in StudentDetails according to the student number entered in the txtStudentNo TextBox.
            // Validate student number
            if (!double.TryParse(txtStudentNo.Text, out double studentNo) || studentNo <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for student number.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            //Start list and find student
            StudentDetails studentDetails = new StudentDetails();

            try
            {
                int index = studentDetails.studentDetailsListNo.IndexOf(txtStudentNo.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while searching for the student: " + ex.Message,
                                "Search Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            finally
            {
                if (studentDetails != null)
                {
                    int index = studentDetails.studentDetailsListNo.IndexOf(txtStudentNo.Text);
                    if (index >= 0)
                    {
                        // Student found, display Student Found in the lblStatus
                        lblStatus.Text = "Student Found";
                    }
                    else
                    {
                        // Student not found in the lblStatus
                        lblStatus.Text = "Student Not Found";
                    }
                }





            }
        }
    }
}
