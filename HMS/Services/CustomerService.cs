using HMS.Entities;
using HMS.Models.DTOs;
using HMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public void Register(CreateCustomerDto createCustomerDto)
        {
            var customer = new Customer()
            {
                NextOfKin = createCustomerDto.NextOfKin,
                DathOfBirth = createCustomerDto.DathOfBirth,
                Gender = createCustomerDto.Gender,
                isActive = createCustomerDto.isActive,
                User = new User
                {
                    LastName = createCustomerDto.User.LastName,
                    FirstName = createCustomerDto.User.FirstName,
                    Email = createCustomerDto.User.Email,
                    PhoneNumber = createCustomerDto.User.PhoneNumber,
                    Password = createCustomerDto.User.Password,
                    Address = new Address
                    {
                        City = createCustomerDto.User.City,
                        Country = createCustomerDto.User.Country,
                        State = createCustomerDto.User.State,
                        NumberLine = createCustomerDto.User.NumberLine,
                        PostalCode = createCustomerDto.User.PostalCode,
                        Street = createCustomerDto.User.Street,
                    }
                }
            };
            var response = _repository.Create(customer);
            if(response)
            {
                Console.WriteLine("Customers created Sucessfully");
            }
            else
            {
                Console.WriteLine("Customers not created");
            }
        }
        public void Edit(string email, UpdateCustomerDto updateCustomerDto)
        {
            var updatedCustomer = _repository.GetbyEmail(email);
            if (updatedCustomer != null)
            {
                updatedCustomer.NextOfKin = updateCustomerDto.NextOfKin;
                updatedCustomer.DathOfBirth = updateCustomerDto.DathOfBirth;
                updatedCustomer.Gender = updateCustomerDto.Gender;
                updatedCustomer.User.FirstName = updateCustomerDto.User.FirstName;
                updatedCustomer.User.LastName = updateCustomerDto.User.LastName;
                updatedCustomer.User.PhoneNumber = updateCustomerDto.User.PhoneNumber;
                updatedCustomer.User.Address.NumberLine = updateCustomerDto.User.NumberLine;
                updatedCustomer.User.Address.Street = updateCustomerDto.User.Street;
                updatedCustomer.User.Address.City = updateCustomerDto.User.City;
                updatedCustomer.User.Address.Country = updateCustomerDto.User.Country;
                updatedCustomer.User.Address.PostalCode = updateCustomerDto.User.PostalCode;
                updatedCustomer.User.Address.State = updateCustomerDto.User.State;
                var response = _repository.Update(updatedCustomer);
                if (response)
                {
                    Console.WriteLine("Customer updated sucessfully");
                }
                else
                {
                    Console.WriteLine("Customer update failed");
                }
            }
            else
            {
                Console.WriteLine("Coustomer not found");
            }
            
        }
        public GetCustomerDto Find(string email)
        {
            var customer = _repository.GetbyEmail(email);
            return new GetCustomerDto()
            {
                NextOfKin = customer.NextOfKin,
                DathOfBirth = customer.DathOfBirth,
                Gender = customer.Gender,
                isActive = customer.isActive,
                User = new GetUserDto()
                {
                    Name = $"{customer.User.LastName} {customer.User.FirstName}",
                    Email = customer.User.Email,
                    PhoneNumber = customer.User.PhoneNumber,
                    City = customer.User.Address.City,
                    Country = customer.User.Address.Country,
                    State = customer.User.Address.State,
                    NumberLine = customer.User.Address.NumberLine,
                    PostalCode = customer.User.Address.PostalCode,
                    Street = customer.User.Address.Street
                }
            };
        }
        public List<GetCustomerDto> GetAll()
        {
            var customers = _repository.List();
            return customers.Select(customer => new GetCustomerDto
            {
                NextOfKin = customer.NextOfKin,
                DathOfBirth = customer.DathOfBirth,
                Gender = customer.Gender,
                isActive = customer.isActive,
                User = new GetUserDto()
                {
                    Name = $"{customer.User.LastName} {customer.User.FirstName}",
                    Email = customer.User.Email,
                    PhoneNumber = customer.User.PhoneNumber,
                    City = customer.User.Address.City,
                    Country = customer.User.Address.Country,
                    State = customer.User.Address.State,
                    NumberLine = customer.User.Address.NumberLine,
                    PostalCode = customer.User.Address.PostalCode,
                    Street = customer.User.Address.Street
                }
            }).ToList();
        }
    }
}
