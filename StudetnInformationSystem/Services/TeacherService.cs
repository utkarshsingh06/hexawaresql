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
    internal class TeacherService : ITeacherServices
    {
        readonly ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public void DisplayTeacherInfo()
        {
            List<Teacher> teachers= _teacherRepository.DisplayTeacherInfo();    
            foreach (Teacher item in teachers)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void GetAssignedCourses(int teacherid)
        {
            List<Course> courses = _teacherRepository.GetAssignedCourses(teacherid);
            foreach (Course item in courses)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public void UpdateTeacherInfo(string firstname, string lastname, string email)
        {
            int updatestatus = _teacherRepository.UpdateTeacherInfo(firstname,lastname,email);
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
