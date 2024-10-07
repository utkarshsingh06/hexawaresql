using StudentInformationSystem.Models;
using StudetnInformationSystem.Models;
using StudetnInformationSystem.Repository.Interfaces;
using StudetnInformationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Repository
{
    internal class EnrollmentRepository : IEnrollmentRepository
    {
        SqlCommand cmd = null;
        public EnrollmentRepository()
        {
            cmd = new SqlCommand();
        }
        public Course GetCourse()
        {
            throw new NotImplementedException();
        }

        public List<EnrollmentReport> GetEnrollmentReport(int courseid)
        {
            List<EnrollmentReport> reports = new List<EnrollmentReport>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.CommandText = "SELECT e.enrollment_id,s.first_name,s.last_name,c.course_name, e.enrollment_date FROM Enrollments e JOIN Students s ON e.student_id = s.student_id  JOIN  Courses c ON e.course_id = c.course_id  WHERE e.course_id = @courseid";
                cmd.Parameters.AddWithValue("@courseid", courseid);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    EnrollmentReport e1= new EnrollmentReport();
                    e1.EnrollmentID = (int)reader["enrollment_id"];
                    e1.FirstName = (string)reader["first_name"];
                    e1.LastName= (string)reader["last_name"];
                    e1.CourseName= (string)reader["course_name"];
                    e1.EnrollmentDate= (DateTime)reader["enrollment_date"];
                    reports.Add(e1);
                }
                sqlConnection.Close();
                return reports;
            }
        }

        public Student GetStudent()
        {
            throw new NotImplementedException();
        }
    }
}
