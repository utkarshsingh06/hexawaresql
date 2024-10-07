using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace StudetnInformationSystem.Models
{
    internal class Student
    {
        public int StudentID { get; set; }      
        public string FirstName { get; set; }   
        public string LastName { get; set; }    
        public DateTime DateOfBirth { get; set; } 
        public string Email { get; set; }        
        public string PhoneNumber { get; set; }  
        public Student(int studentid,string firstname,string lastname,DateTime dateofbirth,string email,string phone)
        {
            StudentID = studentid;
            FirstName = firstname;   
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Email = email;
            PhoneNumber = phone;


        }

        public Student()
        {
        }

        public override string ToString()
        {
            return $"StudentID: {StudentID}, Name: {FirstName} {LastName}, DOB: {DateOfBirth.ToShortDateString()}, " +
                   $"Email: {Email}, Phone: {PhoneNumber}";
        }
    }
}
