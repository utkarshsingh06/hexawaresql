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
    internal class TeacherRepository : ITeacherRepository
    {
        SqlCommand cmd = null;
        public TeacherRepository()
        {
            cmd = new SqlCommand();
        }
        public List<Teacher> DisplayTeacherInfo()
        {
            List<Teacher> teachers = new List<Teacher>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.CommandText = "Select * from Teacher";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.TeacherID = (int)reader["teacher_id"];
                    teacher.FirstName = (string)reader["first_name"];
                    teacher.LastName = (string)reader["last_name"];
                    teachers.Add(teacher);
                }
                sqlConnection.Close();
                return teachers;
            }
        }

        public List<Course> GetAssignedCourses(int teacherid)
        {
            List<Course> courses= new List<Course>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.CommandText = "Select * from Courses where teacher_id=@Teacherid";
                cmd.Parameters.AddWithValue("@Teacherid", teacherid);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Course course = new Course();
                    course.CourseID = (int)reader["course_id"];
                    course.CourseName = (string)reader["course_name"];
                    course.CourseCode = (string)reader["course_code"];
                    course.CourseCode = (string)reader["course_code"];
                    course.TeacherId = (int)reader["teacher_id"];
                    courses.Add(course);


                }
                sqlConnection.Close();
                return courses;
            }
        }

        public int UpdateTeacherInfo(string firstname,string lastname, string email)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Teacher SET first_name = @FirstName, last_name = @LastName, email = @Email  WHERE teacher_id = @TeacherId";
                cmd.Parameters.AddWithValue("@FirstName", firstname);
                cmd.Parameters.AddWithValue("@LastName", lastname);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int updateemployeestatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return updateemployeestatus;
            }
        }
    }
}
