using StudentInformationSystem.Models;
using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Repository.Interfaces
{
    internal interface ICourseRepository
    {
        int AssignTeacher(int teacherid,int courseid);
        void UpdateCourseInfo(string courseCode, string courseName, string instructor);
        void DisplayCourseInfo();
        List<Enrollment> GetEnrollments();
        Teacher GetTeacher();

        Course GetCoursebyId(int coursecode);

        CourseStatistics GetCourseStatisticsById(int courseid);
    }
}
