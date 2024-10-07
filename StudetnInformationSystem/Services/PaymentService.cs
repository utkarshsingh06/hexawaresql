using StudentInformationSystem.Models;
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
    internal class PaymentService : IPaymentService
    {
        readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
             _paymentRepository=paymentRepository;
        }
        public decimal GetPaymentAmount()
        {
            throw new NotImplementedException();
        }

        public DateTime GetPaymentDate()
        {
            throw new NotImplementedException();
        }

        public void GetPaymentReportbyId(int studentid)
        {
            List<Payment> payments = _paymentRepository.GetPaymentReportbyId(studentid);
            if (payments == null || payments.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No enrollments found for this course.");
            }
            else
            {
                foreach (Payment item in payments)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(item.ToString());
                }
            }
            Console.ResetColor();
        }

        public Student GetStudent()
        {
            throw new NotImplementedException();
        }

        public void InsertPaymentrecord(Payment record)
        {
            int enrollstatus = _paymentRepository.InsertPaymentrecord(record);
            Console.WriteLine(enrollstatus);
            if (enrollstatus > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Payment Recorded Successfully");
            }
            else
            {
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine("srry enrollment not possible");
            }
            Console.ResetColor();
        }
    }
}
