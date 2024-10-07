using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Models
{
    internal class CourseStatistics
    {
        public int CourseId { get; set; }
        public int NumberOfEnrollments { get; set; }
        public decimal TotalPayments { get; set; }
        public CourseStatistics(int courseId, int numberOfEnrollments, decimal totalPayments)
        {
            CourseId = courseId;
            NumberOfEnrollments = numberOfEnrollments;
            TotalPayments = totalPayments;
        }
        public CourseStatistics()
        {
        }
        public override string ToString()
        {
            return $"CourseId: {CourseId}, NumberOfEnrollments: {NumberOfEnrollments}, TotalPayments: {TotalPayments:C}";
        }
    }
}
