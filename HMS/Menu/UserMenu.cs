using HMS.Context;
using HMS.Models.DTOs;
using HMS.Repositories;
using HMS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Menu
{
    public class UserMenu
    {
        private readonly UserService _service;
        private readonly UserRepository userRpository;
        

        public UserMenu(HMSDbContext dbContext)
        {
            userRpository = new UserRepository(dbContext);
            _service = new UserService(userRpository);
        }

        public void Register()
        {
            Console.WriteLine("Register User Here: ");
            Console.WriteLine("Enter Your First Name: ");
            var first_name = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name: ");
            var last_name = Console.ReadLine();
            Console.WriteLine("Enter Your Email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number: ");
            var phone_number = Console.ReadLine();
            Console.WriteLine("Enter Your Password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Enter Your Number Line: ");
            var numberLine = Console.ReadLine();
            Console.WriteLine("Enter Your Street: ");
            var street = Console.ReadLine();
            Console.WriteLine("Enter Your State: ");
            var state = Console.ReadLine();
            Console.WriteLine("Enter Your City: ");
            var city = Console.ReadLine();
            Console.WriteLine("Enter Your Country: ");
            var country = Console.ReadLine();
            Console.WriteLine("Enter Your Postal Code: ");
            var posatal_code = int.Parse(Console.ReadLine());
            var userDto = new CreateUserDto
            {
                FirstName = first_name,
                LastName = last_name,
                Email = email,
                PhoneNumber = phone_number,
                Password = password,
                NumberLine = numberLine,
                Street = street,
                State = street,
                City = city,
                Country = country,
                PostalCode = posatal_code
            };
            _service.Register(userDto);
        }

        public void Update()
        {
            Console.WriteLine("Update User Here: ");
            Console.WriteLine("Enter Your Email: ");
            var email = Console.ReadLine();
            Console.WriteLine("Enter Your First Name: ");
            var first_name = Console.ReadLine();
            Console.WriteLine("Enter Your Last Name: ");
            var last_name = Console.ReadLine();
            Console.WriteLine("Enter Your Phone Number: ");
            var phone_number = Console.ReadLine();
            Console.WriteLine("Enter Your Number Line: ");
            var numberLine = Console.ReadLine();
            Console.WriteLine("Enter Your Street: ");
            var street = Console.ReadLine();
            Console.WriteLine("Enter Your State: ");
            var state = Console.ReadLine();
            Console.WriteLine("Enter Your City: ");
            var city = Console.ReadLine();
            Console.WriteLine("Enter Your Country: ");
            var country = Console.ReadLine();
            Console.WriteLine("Enter Your Postal Code: ");
            var posatal_code = int.Parse(Console.ReadLine());
            var updateUser = new UpdateUserDto
            {
                FirstName = first_name,
                LastName = last_name,
                PhoneNumber = phone_number,
                NumberLine = numberLine,
                Street = street,
                State = street,
                City = city,
                Country = country,
                PostalCode = posatal_code
            };
            _service.Edit(email, updateUser);
        }

        public void List()
        {
            var users = _service.GetAll();
            foreach (var user in users)
            {
                Print(user);
            }
        }

        public void Find()
        {
            Console.WriteLine("Enter Your Email: ");
            var email = Console.ReadLine();
            var user = _service.Find(email);
            Print(user);
        }

        private void Print(GetUserDto getUserDto)
        {
            Console.WriteLine($"Name: {getUserDto.Name}\n Phone Number: {getUserDto.PhoneNumber}\n Email: {getUserDto.Email}");
        }
    }
}
