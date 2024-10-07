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
    internal class CourseService : ICourseService
    {
        readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository= courseRepository;
        }
        public void AssignTeacher(int teacherid, int courseid)
        {
            int assignstatus = _courseRepository.AssignTeacher(teacherid, courseid);
            Console.WriteLine(assignstatus);
            if (assignstatus > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Teacher Assigned successfully");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Assingment Unsuccessful");
            }
            Console.ResetColor();

        }

        public void DisplayCourseInfo()
        {
            throw new NotImplementedException();
        }

        public Course GetCoursebyId(int coursecode)
        {
            Course course=_courseRepository.GetCoursebyId(coursecode);
            return course;
        }

        public void GetCourseStatisticsById(int courseid)
        {
            CourseStatistics courseStatistics = _courseRepository.GetCourseStatisticsById(courseid);
            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine(courseStatistics.ToString());
            Console.ResetColor();
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
