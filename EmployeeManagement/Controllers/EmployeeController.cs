using ApplicationServices.Models;
using ApplicationServices.Services;

using DataAccess.IConfiguration;

using Domain.Employee;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(
            IUnitOfWork unitOfWork,
            ILogger<EmployeeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Employees.Add(employee);
                await _unitOfWork.CompleteAsync();

                return new JsonResult(employee)
                {
                    StatusCode = 200
                };
            }

            return new JsonResult("Somthing went wrong")
            {
                StatusCode = 500
            };
        }
    }
}
