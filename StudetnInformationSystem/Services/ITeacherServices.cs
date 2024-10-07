using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    internal interface ITeacherServices
    {
        void UpdateTeacherInfo(string firstname, string lastname, string email);
        void DisplayTeacherInfo();
        void GetAssignedCourses(int teacherid);
    }
}
