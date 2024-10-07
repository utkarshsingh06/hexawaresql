using StudentInformationSystem.Models;
using StudetnInformationSystem.Models;
using StudetnInformationSystem.Repository;
using StudetnInformationSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    internal class EnrollmentService : IEnrollmentService
    {
        readonly IEnrollmentRepository _Enrollrepository;

        public EnrollmentService(IEnrollmentRepository Enrollrepository)
        {
            _Enrollrepository = Enrollrepository;
        }
        public Course GetCourse()
        {
            throw new NotImplementedException();
        }

        public void GetEnrollmentReport(int courseid)
        {
            List<EnrollmentReport> reports = _Enrollrepository.GetEnrollmentReport(courseid);
            if (reports == null || reports.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No enrollments found for this course.");
            }
            else
            {
                foreach (EnrollmentReport item in reports)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ResetColor();
        }

        public Student GetStudent()
        {
            throw new NotImplementedException();
        }
    }
}
