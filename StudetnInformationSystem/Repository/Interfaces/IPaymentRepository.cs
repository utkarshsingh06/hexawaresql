using StudetnInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Repository.Interfaces
{
    internal interface IPaymentRepository
    {
        Student GetStudent();
        decimal GetPaymentAmount();
        DateTime GetPaymentDate();
        int InsertPaymentrecord(Payment record);
        List<Payment> GetPaymentReportbyId(int studentid);
    }
}
