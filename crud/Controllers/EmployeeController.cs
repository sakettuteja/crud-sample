using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crud.Model;
using crud.Repository.Abstraction;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [Route("/employee")]
        [HttpGet]//, Authorize(Roles = "Administrator")]
        public IActionResult GetAllEmployeeDetails()
        {
            try
            {
               var Employees =  this._repoWrapper.Employees.FindAll();
                if (Employees == null)
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
        [Route("/EmployeeWithID")]
        public IActionResult GetEmployeeWithCondition(string id)
        {
            try
            {
                if (id == null)
                    return BadRequest();

                var emp = this._repoWrapper.Employees.FindByCondition(x => x.Id.Equals(int.Parse(id)));
                return Ok(emp);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet]
        [Route("/EmployeeWith")]
        public IActionResult GetEmployeeWithCondition(EmployeeDTO employeeDTO)
        {
            try
            {
                if (employeeDTO == null)
                    return BadRequest();

                var emp = this._repoWrapper.Employees.FindByCondition(x => x.Id.Equals(employeeDTO.Id));
                return Ok(emp);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


    }
}