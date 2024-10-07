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
    internal class StudentRepository : IStudentRepository
    {
        SqlCommand cmd = null;
        public StudentRepository()
        {
            cmd = new SqlCommand();
        }
        public List<Student> DisplayStudentInfo()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.CommandText = "Select * from Students";
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Student student = new Student();
                    student.StudentID = (int)reader["student_id"];
                    student.FirstName = (string)reader["first_name"];
                    student.LastName = (string)reader["last_name"];
                    student.DateOfBirth = (DateTime)reader["date_of_birth"];
                    student.Email = (string)reader["email"];
                    student.PhoneNumber = (string)reader["phone"];
                    students.Add(student);
                }
                sqlConnection.Close();
                return students;
            }
            }

        public int EnrollInCourse(int courseid,int studentId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "insert into Enrollments values(@student_id,@course_id,@enrollment_date)";
                cmd.Parameters.AddWithValue("@student_id", studentId);
                cmd.Parameters.AddWithValue("@course_id", courseid);
                cmd.Parameters.AddWithValue("@enrollment_date", DateTime.Now);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int enrolllcoursestatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return enrolllcoursestatus;
            }

        }
        public List<Course> GetEnrolledCourses(int studentId)
        {
            List<Course> course = new List<Course>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.CommandText = "SELECT c.course_id, c.course_name, c.course_id, CONCAT(t.first_name, ' ', t.last_name) AS teacher_name FROM Enrollments e INNER JOIN Courses c ON e.course_id = c.course_id INNER JOIN Teacher t ON c.teacher_id = t.teacher_id WHERE e.student_id = @studentId";
                cmd.Parameters.AddWithValue("@Studentid", studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Course courses = new Course();
                    courses.CourseID = (int)reader["course_id"];
                    courses.CourseName = (string)reader["course_name"];
                    course.Add(courses);
                }
                sqlConnection.Close();
                return course;
            }
        }

        public List<Payment> GetPaymentHistory(int studentId)
        {
            List<Payment> paym = new List<Payment>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT payment_id, amount ,payment_date from Payments where student_id = @studentId";
                cmd.Parameters.AddWithValue("@Studentid", studentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Payment paymt = new Payment();
                    paymt.PaymentID = (int)reader["payment_id"];
                    paymt.Amount = (decimal)reader["amount"];
                    paymt.PaymentDate= (DateTime)reader["payment_date"];
                    paym.Add(paymt);

                }
                sqlConnection.Close();
                return paym;
            }

        }

        public int Insertstudents(Student student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Student VALUES (@firstname,@lastname,@dob,@email,phone)";
                    cmd.Parameters.AddWithValue("@firstname", student.FirstName);
                    cmd.Parameters.AddWithValue("@lastname", student.LastName);
                    cmd.Parameters.AddWithValue("@dob", student.DateOfBirth);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    cmd.Parameters.AddWithValue("@phone", student.PhoneNumber);

                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int studentstatus = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return studentstatus;
                }
            }
        }

        public int IsStudentEnrolledInCourse(int courseid,int studentid)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandText = "SELECT COUNT(*) FROM Enrollments WHERE student_id = @StudentId AND course_id = @CourseId";
                    cmd.Parameters.AddWithValue("@StudentId", studentid);
                    cmd.Parameters.AddWithValue("@CourseId", courseid);
                    cmd.Connection = sqlConnection;

                    sqlConnection.Open();
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public int MakePayment(int student_id,decimal amount, DateTime paymentDate)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Payments (student_id, amount, payment_date) VALUES (@StudentId, @Amount, @PaymentDate)";
                    cmd.Parameters.AddWithValue("@StudentId", student_id);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@PaymentDate", paymentDate);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int paymentstatus=cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return paymentstatus;
                }
            }
        }

        public int UpdateStudentInfo(int studentid,string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "UPDATE Employee SET first_name = @FirstName, last_name = @LastName, date_of_birth=@dob, email = @Email, phone=@Phone WHERE emp_id = @Employeeid";
                cmd.Parameters.AddWithValue("@Employeeid", studentid);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@@dob", dateOfBirth);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Phone", phoneNumber);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int updateemployeestatus = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return updateemployeestatus;
            }
        }
    }
}
