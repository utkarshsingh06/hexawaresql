using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Services
{
    internal interface IPaymentService
    {
        Student GetStudent();
        decimal GetPaymentAmount();
        DateTime GetPaymentDate();
        void InsertPaymentrecord(Payment record);

        void GetPaymentReportbyId(int studentid);
    }
}
