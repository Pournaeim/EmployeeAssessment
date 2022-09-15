
using ApplicationServices.Models;
using ApplicationServices.Services;

using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                _employeeService.AddNew(employeeDto);

                return new JsonResult(employeeDto)
                {
                    StatusCode = 200
                };
            }

            return new JsonResult("Somthing went wrong")
            {
                StatusCode = 500
            };
        }

        [HttpPost]
        public IActionResult UpdateEmployee(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Update(employeeDto);

                return new JsonResult(employeeDto)
                {
                    StatusCode = 200
                };
            }

            return new JsonResult("Somthing went wrong")
            {
                StatusCode = 500
            };
        }
        [HttpGet]
        public IActionResult GetEmployee(int id)
        {
            var employeeDto = _employeeService.Get(id);

            if (employeeDto == null)
            {
                return new JsonResult(employeeDto)
                {
                    StatusCode = 200
                };
            }

            return new JsonResult("Somthing went wrong")
            {
                StatusCode = 500
            };
        }

        [HttpPost]
        public IActionResult DeleteEmployee(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                _employeeService.Remove(employeeDto);

                return Ok();
            }

            return new JsonResult("Somthing went wrong")
            {
                StatusCode = 500
            };
        }
    }
}
