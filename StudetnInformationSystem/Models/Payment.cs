using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Models
{
    internal class Payment
    {
        public int PaymentID { get; set; }
        public int StudentID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment(int paymentID, decimal amount, DateTime paymentDate)
        {
            PaymentID = paymentID;
            Amount = amount;
            PaymentDate = paymentDate;
        }

        public Payment()
        {
        }

        public override string ToString()
        {
            return $"PaymentID: {PaymentID}, StudentId { StudentID}, Amount: {Amount}, PaymentDate: {PaymentDate.ToShortDateString()}";
        }
    }
}
