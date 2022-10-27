using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyEmployee.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service) => _service = service;

        [HttpGet("{id:guid}", Name = "GetEmployeesForCompany")]
        public IActionResult GetEmployeesForCompany(Guid companyId, Guid id)
        {
            var employees = _service.EmployeeService.GetEmployee(companyId, id, trackchanges: false);
            return Ok(employees);
        }

        [HttpGet]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
                return BadRequest("EmployeeForCreationDto object is null");

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);
            var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackchanges: false);
            return CreatedAtRoute("GetEmployeesForCompany", new {companyId, id = employeeToReturn.Id}, employeeToReturn);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployeeForCompny(Guid companyId, Guid Id)
        {
            _service.EmployeeService.DeleteEmployeeForCompany(companyId, Id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid id, [FromBody] EmployeeForUpdateDto employee)
        {
            if (employee is null)
                return BadRequest("UpdateEmployeeForCompany object is null");
            _service.EmployeeService.UpdateEmployeeForCompany(companyId, id, employee, cmpTrackChanges: false, empTrackChanges: true);
            return NoContent();
        }


        [HttpPut("{id:guid}")]
        public IActionResult PartiallyUpdateEmpoyeeForCompany(Guid companyId, Guid id, [FromBody] JsonPatchDocument<EmployeeForUpdateDto> patchDoc)
        {
            if (patchDoc is null)
                return BadRequest("patchDoc object sent from client is null.");

            var result = _service.EmployeeService.GetEmployeeToPAtch(companyId, id, compTrackChanges: false, empTrackChanges: true);
            patchDoc.ApplyTo(result.employeeToPatch);
            _service.EmployeeService.SaveChangesForPatch(result.employeeToPatch, result.employeeEntity);
            return NoContent();
        }

    }
}
