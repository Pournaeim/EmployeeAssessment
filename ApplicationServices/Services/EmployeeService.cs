
using ApplicationServices.Models;
using Domain.IRepositories;
using Domain.Employee;
using Microsoft.Extensions.Logging;

namespace ApplicationServices.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        protected readonly ILogger _logger;

        public EmployeeService(IEmployeeRepository employeeRepository, ILogger logger)
        {
            _employeeRepository = employeeRepository;
            this._logger = logger;
        }
        public int AddNew(EmployeeDto employeeDto)
        {
            var employee = new Employee()
            {
                FirstName = employeeDto.FirstName,
                MiddleName = employeeDto.MiddleName,
                LastName = employeeDto.LastName,
            };

            _employeeRepository.Add(employee);

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

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {

            try
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
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} All method error", typeof(EmployeeService));
                return new List<EmployeeDto>();
            }
        }



        public bool Remove(EmployeeDto entity)
        {


            try
            {
                var removableEntity = _employeeRepository.Get(entity.Id);
                _employeeRepository.Delete(removableEntity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete method error", typeof(EmployeeService));
                return false;
            }
        }

        public bool Update(EmployeeDto employeeDto)
        {
            try
            {
                var employee = new Employee()
                {
                    Id = employeeDto.Id,
                    FirstName = employeeDto.FirstName,
                    MiddleName = employeeDto.MiddleName,
                    LastName = employeeDto.LastName,
                };

                _employeeRepository.Upsert(employee);

                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{Repo} Upsert method error", typeof(EmployeeService));
                return false;
            }
        }
    }
}
