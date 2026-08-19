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
            lblStatus.Text = string.Empty;
        }

        // -------------------------------------------------------------------
        // 1.2.1  REGISTER  (insert into tblStudents)
        // -------------------------------------------------------------------
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // --- Validation ---
            string studentNo = txtStudentNo.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string course = txtCourse.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentNo))
            {
                MessageBox.Show("Please enter a Student Number.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Student number must be a positive number
            if (!double.TryParse(studentNo, out double number) || number <= 0)
            {
                MessageBox.Show("Please enter a valid positive number for Student Number.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please enter a Full Name.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Full name should not be purely numeric
            if (double.TryParse(fullName, out _))
            {
                MessageBox.Show("Full Name cannot be a number. Please enter a valid name.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(course))
            {
                MessageBox.Show("Please enter a Course.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Prevent duplicate Student Numbers
            bool alreadyExists = StudentDetails.tblStudents
                .Any(s => s.StudentNo.Equals(studentNo, StringComparison.OrdinalIgnoreCase));

            if (alreadyExists)
            {
                MessageBox.Show("A student with this Student Number already exists.",
                                "Duplicate Record",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // --- Insert into tblStudents ---
            Student newStudent = new Student(studentNo, fullName, course);
            StudentDetails.tblStudents.Add(newStudent);

            // Exact message required by the assessment
            lblStatus.Text = "Student Registered";
            lblStatus.ForeColor = Color.Green;
        }

        // -------------------------------------------------------------------
        // 1.2.2  REMOVE  (delete by StudentNo)
        // -------------------------------------------------------------------
        private void btnRemove_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentNo))
            {
                MessageBox.Show("Please enter a Student Number to remove.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Search for the student
            Student studentToRemove = StudentDetails.tblStudents
                .FirstOrDefault(s => s.StudentNo.Equals(studentNo, StringComparison.OrdinalIgnoreCase));

            if (studentToRemove != null)
            {
                StudentDetails.tblStudents.Remove(studentToRemove);

                // Exact message required by the assessment
                lblStatus.Text = "Student Removed";
                lblStatus.ForeColor = Color.Green;
            }
            else
            {
                // Exact message required by the assessment
                lblStatus.Text = "Student NOT Found";
                lblStatus.ForeColor = Color.Red;
            }
        }

        // -------------------------------------------------------------------
        // 1.2.3  SEARCH  (find by StudentNo)
        // -------------------------------------------------------------------
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string studentNo = txtStudentNo.Text.Trim();

            if (string.IsNullOrWhiteSpace(studentNo))
            {
                MessageBox.Show("Please enter a Student Number to search.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // Search for the student
            Student foundStudent = StudentDetails.tblStudents
                .FirstOrDefault(s => s.StudentNo.Equals(studentNo, StringComparison.OrdinalIgnoreCase));

            if (foundStudent != null)
            {
                // Exact message required by the assessment
                lblStatus.Text = "Student Found";
                lblStatus.ForeColor = Color.Green;

                // Optional: populate the other fields so the user can see the record
                txtFullName.Text = foundStudent.FullName;
                txtCourse.Text = foundStudent.Course;
            }
            else
            {
                // Exact message required by the assessment
                lblStatus.Text = "Student NOT Found";
                lblStatus.ForeColor = Color.Red;
            }
        }
    }
}
