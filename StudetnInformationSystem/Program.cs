using StudentInformationSystem.Services;
using StudetnInformationSystem.MainModule;
using StudetnInformationSystem.Models;
using StudetnInformationSystem.Repository;
using StudetnInformationSystem.Repository.Interfaces;
using StudetnInformationSystem.Services;

namespace StudetnInformationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStudentRepository studentRepository = new StudentRepository();
            IStudentService studentService = new StudentService(studentRepository);
            ICourseRepository courseRepository = new CourseRepository();
            ICourseService courseService = new CourseService(courseRepository);
            ITeacherRepository teacherRepository = new TeacherRepository();
            ITeacherServices teacherServices= new TeacherService(teacherRepository);
            IEnrollmentRepository enrollmentRepository = new EnrollmentRepository();
            IEnrollmentService enrollmentService = new EnrollmentService(enrollmentRepository);    
            IPaymentRepository paymentRepository = new PaymentRepository();
            IPaymentService paymentService = new PaymentService(paymentRepository);

            SIS s1 = new SIS(studentService,courseService,teacherServices,enrollmentService,paymentService);
            s1.Run();

        }
    }
}
