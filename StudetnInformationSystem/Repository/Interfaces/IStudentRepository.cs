using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Repository.Interfaces
{
    internal interface IStudentRepository
    {
        int EnrollInCourse(int courseid,int studentId);
        int IsStudentEnrolledInCourse(int studentId, int courseId);
        int UpdateStudentInfo(int studentid,string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber);
        int MakePayment(int student_id,decimal amount, DateTime paymentDate);
        List<Student> DisplayStudentInfo();
        List<Course> GetEnrolledCourses(int studentId);
        List<Payment> GetPaymentHistory(int studentId);

        int Insertstudents(Student student);

    }
}
