using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudetnInformationSystem.Repository.Interfaces
{
    internal interface ITeacherRepository
    {
        int UpdateTeacherInfo(string firstname, string lastname, string email);
        List<Teacher> DisplayTeacherInfo();
        List<Course> GetAssignedCourses(int teacherid);
    }
}
