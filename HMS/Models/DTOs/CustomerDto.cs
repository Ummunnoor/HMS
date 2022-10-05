using HMS.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models.DTOs
{
    public class CreateCustomerDto
    {
        public CreateUserDto User { get; set; }
        public bool isActive { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DathOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
    public class UpdateCustomerDto
    {
        public UpdateUserDto User { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DathOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
    public class GetCustomerDto
    {
        public GetUserDto User { get; set; }
        public bool isActive { get; set; }
        public string NextOfKin { get; set; }
        public DateTime DathOfBirth { get; set; }
        public Gender Gender { get; set; }
    }
}
