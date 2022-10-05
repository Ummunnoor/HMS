using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Models.Enum;

namespace HMS.Entities
{
    public class Booking: BaseEntity
    {
        public string Reference { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public BookingStatus Status { get; set; }
        public int Duration { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DateOfArrival { get; set; }
        public bool IsCheckedIn { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

    }
}
