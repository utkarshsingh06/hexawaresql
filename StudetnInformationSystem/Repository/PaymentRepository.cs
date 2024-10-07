using StudentInformationSystem.Models;
using StudetnInformationSystem.Models;
using StudetnInformationSystem.Repository.Interfaces;
using StudetnInformationSystem.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudetnInformationSystem.Repository
{
    internal class PaymentRepository : IPaymentRepository
    {
        SqlCommand cmd = null;
        public PaymentRepository()
        {
            cmd = new SqlCommand();
        }
        public decimal GetPaymentAmount()
        {
            throw new NotImplementedException();
        }

        public DateTime GetPaymentDate()
        {
            throw new NotImplementedException();
        }

        public List<Payment> GetPaymentReportbyId(int studentid)
        {
            List<Payment> reports = new List<Payment>();
            using (SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                cmd.CommandText = "SELECT * from Payments where student_id=@StudentId";
                cmd.Parameters.AddWithValue("@StudentId", studentid);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Payment payment = new Payment();
                    payment.PaymentID = (int)reader["payment_id"];
                    payment.StudentID = (int)reader["student_id"];
                    payment.Amount = (decimal)reader["amount"];
                    payment.PaymentDate = (DateTime)reader["payment_date"];
                    reports.Add(payment);
                }
                sqlConnection.Close();
                return reports;
            }
        }

        public Student GetStudent()
        {
            throw new NotImplementedException();
        }

        public int InsertPaymentrecord(Payment record)
        {
            using(SqlConnection sqlConnection = new SqlConnection(DbConutil.GetConnString()))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = "INSERT INTO Payments VALUES (@studentid,@amount,@paymentdate)";
                    cmd.Parameters.AddWithValue("@studentid", record.StudentID);
                    cmd.Parameters.AddWithValue("@amount", record.Amount);
                    cmd.Parameters.AddWithValue("@paymentdate", record.PaymentDate);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    int paymentstatus = cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    return paymentstatus;
                }
            }
        }
    }
}
