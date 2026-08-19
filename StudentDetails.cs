using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section_C_Question1__StudentRecordManager_
{
    /// <summary>
    /// Represents a single student record.
    /// </summary>
    public class Student
    {
        public string StudentNo { get; set; }
        public string FullName { get; set; }
        public string Course { get; set; }

        public Student(string studentNo, string fullName, string course)
        {
            StudentNo = studentNo;
            FullName = fullName;
            Course = course;
        }
    }

    /// <summary>
    /// In-memory student store. The static list acts as the tblStudents table
    /// required by the assessment specification.
    /// </summary>
    public static class StudentDetails
    {
        // This list represents the tblStudents table
        public static List<Student> tblStudents { get; private set; } = new List<Student>();

        public static void ClearAll()
        {
            tblStudents.Clear();
        }
    }
}
