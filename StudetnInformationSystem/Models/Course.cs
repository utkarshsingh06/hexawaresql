using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Models
{
    internal class Course
    {
        public int CourseID { get; set; } 
        public int Coursecredits { get; set; }
        public string CourseName { get; set; }  
        public string CourseCode { get; set; }
        public int TeacherId { get; set; }

        public Course(int courseid,int coursecredits,string coursename,string coursecode,int teacherid) { 
            CourseID = courseid;
            Coursecredits = coursecredits;
            CourseName = coursename;
            CourseCode = coursecode;
            TeacherId = teacherid;   
        }

        public Course()
        {
        }

        public override string ToString()
        {
            return $"CourseID: {CourseID}, Coursecredits: {Coursecredits}, Coursename: {CourseName}, CourseCode: {CourseCode}, TeacherId: {TeacherId}";
        }
    }
}
