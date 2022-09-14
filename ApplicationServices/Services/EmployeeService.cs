using ApplicationServices.Models;

using Domain.Employee;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public int AddNew(EmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                FirstName = employeeDto.FirstName,
                MiddleName = employeeDto.MiddleName,
                LastName = employeeDto.LastName,
            };

            _employeeRepository.Create(employee);
            _employeeRepository.SaveChanges();

            return employee.Id;
        }

        public EmployeeDto Get(int id)
        {
            var employee = _employeeRepository.Get(id);
            EmployeeDto employeeDto = new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,

            };
            employeeDto.Id = id;

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> Get(Expression<Func<EmployeeDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var employeeList = _employeeRepository.GetAll();
            var employeeDtoList = from e in employeeList
                                  select new EmployeeDto
                                  {
                                      Id = e.Id,
                                      FirstName = e.FirstName,
                                      LastName = e.LastName,
                                      MiddleName = e.MiddleName,
                                  };

            return employeeDtoList;
        }

        public void Remove(int id)
        {
            var employee = _employeeRepository.Get(id);

            _employeeRepository.Delete(employee);
        }


        public void Update(EmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                Id = employeeDto.Id,
                FirstName = employeeDto.FirstName,
                MiddleName = employeeDto.MiddleName,
                LastName = employeeDto.LastName,
            };

            _employeeRepository.Update(employee);

        }
        public void SaveChanges()
        {
            _employeeRepository.SaveChanges();
        }
    }
}
