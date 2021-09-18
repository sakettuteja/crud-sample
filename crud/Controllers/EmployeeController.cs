using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using crud.Model;
using crud.Repository.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json;

namespace crud.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IRepositoryWrapper _repoWrapper;

        public EmployeeController(IRepositoryWrapper repositoryWrapper)
        {
            _repoWrapper = repositoryWrapper;
        }

        [Route("/users")]
        [HttpGet]//, Authorize(Roles = "Administrator")]
        public IActionResult GetAllEmployeeDetails()
        {
            try
            {
               var Employees =  this._repoWrapper.Employees.FindAll();

                if (!Employees.Any())
                    return NotFound();
                else
                    return Ok(Employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/user/query/{id:int?}")]
        public IActionResult GetEmployeeWithCondition([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "404", ErrorDescription = "Employee with id not found" };
                    return NotFound(er);
                }
                    
                var emp = this._repoWrapper.Employees.FindByCondition(x => x.Id.Equals(id));

                if (!emp.Any())
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "404", ErrorDescription = "Employee with id not found" };
                    return NotFound(er);
                }

                return Ok(emp);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/restaurant/query/{city?}")]
        public IActionResult GetEmployeeWithcityCondition([FromQuery] string city)
        {
            try
            {
                if (city == null)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "404", ErrorDescription = "Employee with city not found, city name required" };
                    return NotFound(er);
                }

                var emp = this._repoWrapper.Employees.FindByCondition(x => x.FirstName.Equals(city));

                if (!emp.Any())
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "404", ErrorDescription = "Employee with city not found" };
                    return NotFound(er);
                }

                return Ok(emp);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpDelete]
        [Route("/user/{id:int?}")]
        public IActionResult deleteemployee([FromQuery] int id)
        {
            try
            {
                if (id == 0)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "404", ErrorDescription = "Employee with id not found" };
                    return NotFound(er);
                }

                var emp = this._repoWrapper.Employees.FindByCondition(x => x.Id.Equals(id));

                if (!emp.Any())
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "404", ErrorDescription = "Employee with id not found" };
                    return NotFound(er);
                }
                
                this._repoWrapper.Employees.Delete(emp.FirstOrDefault());
                object obj = new { statuscode = "200", description = "Employee Deleted Successfully" };
                this._repoWrapper.Save();
                return Ok(obj);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("/user/{id:int?}")]
        public IActionResult updateemployee([FromQuery] int id, [FromBody] UpdateEmployeeDTO updateEmployeeDTO)
        {
            try
            {

                if (id == 0)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "404", ErrorDescription = "Employee with id not found" };
                    return NotFound(er);
                }

                if (updateEmployeeDTO == null)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "400", ErrorDescription = "Employee Details required" };
                    return BadRequest(er);
                }

                if (!ModelState.IsValid)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "400", ErrorDescription = "Employee Details required" };
                    return BadRequest(er);
                }

                var emp = this._repoWrapper.Employees.FindByCondition(x => x.Id.Equals(id));

                if (!emp.Any())
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "404", ErrorDescription = "Employee with id not found to update" };
                    return NotFound(er);
                }


                Employee employee = new Employee()
                {
                    Age = updateEmployeeDTO.Age,
                    Email = emp.FirstOrDefault().Email,
                    FirstName = emp.FirstOrDefault().FirstName,
                    Id = emp.FirstOrDefault().Id,
                    LastName = emp.FirstOrDefault().LastName,
                    Password = updateEmployeeDTO.Password
                };

                //emp.FirstOrDefault().Age = updateEmployeeDTO.Age;
                //emp.FirstOrDefault().Password = updateEmployeeDTO.Password;

                

                this._repoWrapper.Employees.Update(employee);
                this._repoWrapper.Save();
                return Ok(emp);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPost("content")]
        [Route("/import")]
        public IActionResult AddEmployee ([FromBody] byte[] json)
        {
            try
            {
                if (json == null)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "400", ErrorDescription = "Employee Details required" };
                    return BadRequest(er);
                }

                string jsonStr = Encoding.UTF8.GetString(json);
                EmployeeDTO employee = null;

                

                employee = JsonConvert.DeserializeObject<EmployeeDTO>(jsonStr);

                if (employee== null)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "400", ErrorDescription = "Employee Details required" };
                    return BadRequest(er);
                }

                if (!ModelState.IsValid)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "400", ErrorDescription = "Employee Details required" };
                    return BadRequest(er);
                }

                if (this._repoWrapper.Employees.FindByCondition(x => x.Id.Equals(employee.Id)).Count()> 0)
                {
                    ErrorResponse er = new ErrorResponse() { ErrorCode = "400", ErrorDescription = "Employee already exists" };
                    return BadRequest(er);
                }

                Employee employee1 = new Employee()
                {
                    Age = employee.Age,
                    Email = employee.Email,
                    FirstName = employee.FirstName,
                    //Id = employee.Id,
                    LastName = employee.LastName,
                    Password = employee.Password
                };

                this._repoWrapper.Employees.Create(employee1);
                this._repoWrapper.Save();
                return Ok(employee1);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
           
        }

    }
}