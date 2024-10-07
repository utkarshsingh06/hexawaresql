using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Services
{
    internal interface IStudentService
    {
        void EnrollInCourse(int courseid, int studentId);
        void UpdateStudentInfo(int studentid, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber);
        void MakePayment(int student_id, decimal amount, DateTime paymentDate);
        void DisplayStudentInfo();
        void GetEnrolledCourses(int studentId);
        void GetPaymentHistory(int studentId);
        void Insertstudents(Student student);
    }
}
