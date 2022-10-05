using HMS.Context;
using HMS.Models.DTOs;
using HMS.Models.Enum;
using HMS.Repositories;
using HMS.Services;

namespace HMS.Menu
{
    public class CustomerMenu
    {
        private readonly CustomerService _service;
        private readonly CustomerRepository customerRepository;


        public CustomerMenu(HMSDbContext dbContext)
        {
            customerRepository = new CustomerRepository(dbContext);
            _service = new CustomerService(customerRepository);
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
            Console.WriteLine("Enter Date of Birth");
            var dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Next of kin Name");
            var nextOfKin = Console.ReadLine();
            var customerDto = new CreateCustomerDto
            {
                User = new CreateUserDto
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
                },
                DathOfBirth = dob,
                isActive = true,
                Gender = GetGender(),
                NextOfKin = nextOfKin,
            };
            _service.Register(customerDto);
        }

        public void Update()
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
            Console.WriteLine("Enter Date of Birth");
            var dob = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Next of kin Name");
            var nextOfKin = Console.ReadLine();
            var updatedCustomer = new UpdateCustomerDto
            {
                User = new UpdateUserDto
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
                },
                DathOfBirth = dob,
                Gender = GetGender(),
                NextOfKin = nextOfKin,
            };
            _service.Edit(email, updatedCustomer);
        }

        public void List()
        {
            var customers = _service.GetAll();
            foreach (var customer in customers)
            {
                Print(customer);
            }
        }

        public void Find()
        {
            Console.WriteLine("Enter Your Email: ");
            var email = Console.ReadLine();
            var customerDto = _service.Find(email);
            Print(customerDto);
        }

        private void Print(GetCustomerDto getCustomerDto)
        {
            Console.WriteLine($"Name: {getCustomerDto.User.Name}\n Phone Number: {getCustomerDto.User.PhoneNumber}\n Email: {getCustomerDto.User.Email}");
        }

        private Gender GetGender()
        {
            Console.WriteLine("Enter 1 For Male and 2 For Female");
            var option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                return Gender.Male;
            }
            else
            {
                return Gender.Female;
            }
        }
    }
}
