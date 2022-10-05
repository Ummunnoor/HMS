using HMS.Models.Enum;

namespace HMS.Entities
{
    public class Customer : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public bool isActive { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DathOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
