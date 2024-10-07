using StudentInformationSystem.Models;
using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Repository.Interfaces
{
    internal interface IEnrollmentRepository
    {
        Student GetStudent();
        Course GetCourse();
        List<EnrollmentReport> GetEnrollmentReport(int courseid);
    }
}
