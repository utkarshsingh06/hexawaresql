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
    internal class CourseRepository : ICourseRepository
    {
        SqlCommand cmd = null;
        public CourseRepository()
        {
            cmd = new SqlCommand();
        }
        public int AssignTeacher(int teacherid,int courseid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "UPDATE Courses SET teacher_id = @teacherId WHERE course_id = @courseId";
                    cmd.Parameters.AddWithValue("@teacherId", teacherid);
                    cmd.Parameters.AddWithValue("@courseId", courseid);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int paymentstatus = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return paymentstatus;
                }
            }
        }

        public void DisplayCourseInfo()
        {
            throw new NotImplementedException();
        }

        public Course GetCoursebyId(int courseid)
        {
            Course course = null;
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.CommandText = "Select * from Courses where course_id=@coursecode";
                cmd.Parameters.AddWithValue("@coursecode", courseid);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    course = new Course();
                    course.CourseName = (string)reader["course_name"];
                    course.Coursecredits = (int)reader["credits"];
                    course.CourseCode = (string)reader["course_code"];
                }
                sqlConnection.Close();
                return course;
            }
        }

        public CourseStatistics GetCourseStatisticsById(int courseid)
        {
            CourseStatistics statistics = new CourseStatistics();
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM Enrollments WHERE course_id=@CourseId";
                    cmd.Parameters.AddWithValue("@CourseId", courseid);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    statistics.NumberOfEnrollments = (int)cmd.ExecuteScalar();
                }
                statistics.CourseId = courseid;
                return statistics;
            }
        }

        public List<Enrollment> GetEnrollments()
        {
            throw new NotImplementedException();
        }

        public Teacher GetTeacher()
        {
            throw new NotImplementedException();
        }

        public void UpdateCourseInfo(string courseCode, string courseName, string instructor)
        {
            throw new NotImplementedException();
        }

    }
}
