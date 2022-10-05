using HMS.Context;
using HMS.Entities;
using HMS.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repositories
{
    public class BookingRepository
    {
        private readonly HMSDbContext _context;

        public BookingRepository(HMSDbContext dbContext)
        {
            _context = dbContext;
        }

        public bool Create(Booking booking)
        {
            if (booking == null)
            {
                Console.WriteLine("Booking can not be null");
                return false;
            }
            else
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return true;
            }
        }

        public bool Update(int bookingId, Booking updatedBooking)
        {
            var booking = _context.Bookings.Find(bookingId);
            if (booking == null)
            {
                Console.WriteLine("Booking can not be null");
                return false;
            }
            else
            {
                booking.Duration = updatedBooking.Duration;
                booking.DateOfArrival = updatedBooking.DateOfArrival;
                _context.Bookings.Update(booking);
                _context.SaveChanges();
                return true;
            }
        }

        public List<Booking> List()
        {
            return _context.Bookings.ToList();
        }

        public List<Booking> GetByBookingStatus(BookingStatus status)
        {
            return _context.Bookings.Where(b => b.Status == status).ToList();
        }

        public Booking GetById(int id)
        {
            return _context.Bookings.FirstOrDefault(b => b.Id == id);
        }

        public Booking GetByBookingRef(string reference)
        {
            return _context.Bookings.FirstOrDefault(b => b.Reference == reference);
        }

        public List<Booking> GetBookingsByCheckedInStatus(bool isCheckedIn)
        {
            return _context.Bookings.Where(b => b.IsCheckedIn == isCheckedIn).ToList();
        }
    }
}
