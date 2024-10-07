using StudentInformationSystem.Models;
using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    internal interface IEnrollmentService
    {
        Student GetStudent();
        Course GetCourse();
        void GetEnrollmentReport(int courseid);
    }
}
