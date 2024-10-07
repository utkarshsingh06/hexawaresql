using StudetnInformationSystem.Exceptions;
using StudetnInformationSystem.Models;
using StudetnInformationSystem.Repository;
using StudetnInformationSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Services
{
    internal class StudentService: IStudentService
    {

        readonly IStudentRepository _studentrepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentrepository = studentRepository;
        }

        public void DisplayStudentInfo()
        {
            List<Student> students = _studentrepository.DisplayStudentInfo();
            foreach (Student item in students)
            {
                Console.WriteLine(item.ToString());
            }
        }
        public void EnrollInCourse(int coursecode, int studentId)
        {

            if (_studentrepository.IsStudentEnrolledInCourse(coursecode,studentId)>0)
            {
                throw new DuplicateEnrollmentException($"Student ID {studentId} is already enrolled in Course ID {coursecode}.");
            }
            else
            {
                int enrollstatus = _studentrepository.EnrollInCourse(coursecode, studentId);
                if (enrollstatus > 0)
                {
                    Console.WriteLine(enrollstatus);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Course Successfully Enrolled");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("sorry enrollment not possible");
                    Console.ResetColor();
                }
            }
        }

        public void GetEnrolledCourses(int studentId)
        {
            List<Course> courses = _studentrepository.GetEnrolledCourses(studentId);
            foreach (Course item in courses)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetPaymentHistory(int studentId)
        {
            List<Course> courses = _studentrepository.GetEnrolledCourses(studentId);
            foreach (Course item in courses)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void Insertstudents(Student student)
        {
            int ststus=_studentrepository.Insertstudents(student);
            Console.WriteLine(ststus);
            if (ststus > 0)
            {
                Console.WriteLine("Student inserted successfully");
            }
            else
            {
                Console.WriteLine("Insertion Unsuccessful");
            }

        }

        public void MakePayment(int student_id, decimal amount, DateTime paymentDate)
        {
            int paymentstatus = _studentrepository.MakePayment(student_id, amount, paymentDate);
            Console.WriteLine(paymentstatus);
            if (paymentstatus > 0)
            {
                Console.WriteLine("Payment made successfully");
            }
            else
            {
                Console.WriteLine("Payment Unsuccessful");
            }
        }

        public void UpdateStudentInfo(int studentid, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber)
        {
            int updatestatus = _studentrepository.UpdateStudentInfo(studentid, firstName, lastName, dateOfBirth, email, phoneNumber);
            Console.WriteLine(updatestatus);
            if (updatestatus > 0)
            {
                Console.WriteLine("Update made successfully");
            }
            else
            {
                Console.WriteLine("Update Unsuccessful");
            }

        }
    }
}
