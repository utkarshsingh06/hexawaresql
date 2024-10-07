using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    internal class EnrollmentReport
    {
        public int EnrollmentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CourseName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public EnrollmentReport(int enrollmentId, string firstname,string lastname, string courseName, DateTime enrollmentDate)
        {
            EnrollmentID = enrollmentId;
            FirstName = firstname;
            lastname = lastname;
            CourseName = courseName;
            EnrollmentDate = enrollmentDate;
        }
        public EnrollmentReport()
        {
        }
        public override string ToString()
        {
            return $"EnrollmentID: {EnrollmentID}, FirstName: {FirstName},LastName: {LastName}, CourseName: {CourseName}, EnrollmentDate: {EnrollmentDate.ToString("yyyy-MM-dd")}";
        }
    }
}
