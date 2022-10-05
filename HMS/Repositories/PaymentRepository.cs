using HMS.Context;
using HMS.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repositories
{
    public class PaymentRepository
    {
        private readonly HMSDbContext _context;

        public PaymentRepository(HMSDbContext context)
        {
            _context = context;
        }
        public bool Create(Payment payment)
        {
            if(payment == null)
            {
                return false;
            }
            else
            {
                _context.Payments.Add(payment);
                _context.SaveChanges();
                return true;
            }
        }
        public bool Update(int id,Payment updatedPayment)
        {
            var payment = _context.Payments.FirstOrDefault(x => x.Id == id);
            if(payment == null)
            {
                Console.WriteLine("Payment not found");
                return false;
            }
            else
            {
                payment.Amount = updatedPayment.Amount;
                _context.Update(payment);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Payment> List()
        {
            return _context.Payments.ToList();
        }

        public Payment GetById(int id)
        {
            return _context.Payments
                .Include(p => p.Customer)
                .SingleOrDefault(p => p.Id == id);
        }

        public Payment GetByRef(string reference)
        {
            return _context.Payments
                .Include(p => p.Customer)
                .SingleOrDefault(p => p.Reference == reference);
        }

        public List<Payment> GetByPaymentStatus(bool status)
        {
            return _context.Payments
                .Include(p => p.Customer)
                .Where(p => p.IsPaid == status).ToList();
        } 

        public bool Delete(int id)
        {
            var payment = GetById(id);
            if (payment == null)
            {
                Console.WriteLine("Payment not found");
                return false;
            }
            _context.Payments.Remove(payment);
            _context.SaveChanges();
            return true;
        }

        public bool ChangePaymentStatus(string paymentRef, bool status)
        {
            var payment = GetByRef(paymentRef);
            if (payment == null)
            {
                Console.WriteLine("Payment not found");
                return false;
            }
            else
            {
                payment.IsPaid = status;
                _context.Payments.Update(payment);
                _context.SaveChanges();
                return true;
            }
        }

    }
}
