using StudentInformationSystem.Services;
using StudetnInformationSystem.Models;
using StudetnInformationSystem.Repository.Interfaces;
using StudetnInformationSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.MainModule
{
    internal class SIS
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;
        private readonly ITeacherServices _teacherServices;
        private readonly IEnrollmentService _enrollmentService;
        private readonly IPaymentService _paymentService;
        public SIS(IStudentService studentService,ICourseService courseService , ITeacherServices teacherServices,IEnrollmentService enrollmentService,IPaymentService paymentService)
        {
            _studentService = studentService;
            _courseService = courseService;
            _teacherServices = teacherServices;
            _enrollmentService = enrollmentService;
            _paymentService = paymentService;

        }
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("==== Student Information System ====");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("1. Enroll Student in Course");
                Console.WriteLine("2. Assign Teacher to Course");
                Console.WriteLine("3. Record Payment");
                Console.WriteLine("4. Generate Enrollment Report");
                Console.WriteLine("5. Generate Payment Report");
                Console.WriteLine("6. Calculate Course Statistics");
                Console.WriteLine("7. Add Student");
                Console.ResetColor(); 

                Console.WriteLine("0. Exit");
                Console.Write("Please select an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        EnrollStudent();
                        break;
                    case "2":
                        AssignTeacher();
                        break;
                    case "3":
                        RecordPayment();
                        break;
                    case "4":
                        GenerateEnrollmentReport();
                        break;
                    case "5":
                        GeneratePaymentReport();
                        break;
                    case "6":
                        CalculateCourseStatistics();
                        break;
                    case "7":
                        AddStudent();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine();
            }

            Console.WriteLine("Exiting the system. Thank you!");
        }
        void EnrollStudent()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Student Id:");
            int studid = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Course ID:");
            int courseid = int.Parse(Console.ReadLine());
            Console.ResetColor();
            try
            {
                _studentService.EnrollInCourse(courseid, studid);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

            }
        }
        void AssignTeacher()
        {
            Console.ForegroundColor = ConsoleColor.Red;
         
            Console.WriteLine("Enter Course Id:");
            int courseid= int.Parse(Console.ReadLine());
            Console.ResetColor();
            Course course = _courseService.GetCoursebyId(courseid);
            if (course == null)
            {
                Console.WriteLine("Course not found.");
            }
            else
            {
                if (course.TeacherId==null|| course.TeacherId==0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Enter Teacher Id:");
                    Console.ResetColor();
                    int teachid = int.Parse(Console.ReadLine());
                    _courseService.AssignTeacher(teachid, courseid);

                }
                else
                {
                    Console.WriteLine($"Teacher is already assigned to this course (Teacher ID: {course.TeacherId}).");
                }
            }

        }
        void RecordPayment()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Student ID:");
            int studid=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter amount:");
            decimal amount=decimal.Parse(Console.ReadLine());
            DateTime payment_date = DateTime.Now;
            Payment payment = new Payment()
            {
                StudentID = studid,
                Amount = amount,
                PaymentDate = payment_date
            };
            _paymentService.InsertPaymentrecord(payment);
        }

        void GenerateEnrollmentReport()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Course ID:");
            int courseid=int.Parse(Console.ReadLine());
            _enrollmentService.GetEnrollmentReport(courseid);
        }
        void GeneratePaymentReport()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Student ID:");
            int studid=int.Parse(Console.ReadLine());
            _paymentService.GetPaymentReportbyId(studid);
        }
        void CalculateCourseStatistics()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter Course ID: ");
            int courseid=int.Parse(Console.ReadLine());
            Console.ResetColor();   
            _courseService.GetCourseStatisticsById(courseid);
            

        }
        void AddStudent()
        {
            Console.WriteLine("==== Add New Student ====");
            Console.Write("Enter First Name: ");
            string firstname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastname = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            DateTime dob = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            Console.Write("Enter Phone: ");
            string phone= Console.ReadLine();

            Student student = new Student()
            {
                FirstName=firstname,
                LastName=lastname,
                DateOfBirth=dob,
                Email=email,
                PhoneNumber=phone
            };
            _studentService.Insertstudents(student);
        }
    }
}
