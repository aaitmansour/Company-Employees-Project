using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObject;
using CompanyEmployee.Presentation.ModelBinders;

namespace CompanyEmployee.Presentation.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompaniesControllor : ControllerBase
    {
        private readonly IServiceManager _service;

        public CompaniesControllor(IServiceManager service) =>
            _service = service;

        [HttpGet("{id:Guid}", Name = "CompanyById")]
        public IActionResult GetCompanies()
        {
            //throw new Exception("excptin");
            var companies = _service.CompanyService.GetAllCompanies(trackchanges: false);
            return Ok(companies);
        }


        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyForCreationDto company)
        {
            if (company is null)
                return BadRequest("CompanyForCreationDto object is null");

            var createdCompany = _service.CompanyService.CreateCompany(company);
            return CreatedAtRoute("CompanyById", new { id = createdCompany.id }, createdCompany);
        }


        [HttpGet("collection/({ids})", Name ="CompanyCollection")]
        public IActionResult GetCompanyCollection([ModelBinder(BinderType = typeof(ArrayModelBider))] IEnumerable<Guid> ids)
        {
            var compamies = _service.CompanyService.GetByIds(ids, trackChanges: false);
            return Ok(compamies);
        }


        [HttpPost("collection")]
        public IActionResult CreateCompanyCollection([FromBody] IEnumerable<CompanyForCreationDto> companycollection)
        {
            var result = _service.CompanyService.CreateCompanyCollection(companycollection);
            return CreatedAtRoute("CompanyCollection", new { result.ids }, result.companies);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteCompany(Guid id)
        {
            _service.CompanyService.DeleteCompany(id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public IActionResult CompanyUpdate(Guid id, [FromBody] CompanyForUpdateDto company)
        {
            if (company is null)
                return BadRequest("CompanyForUpdateDto  object is null");

            _service.CompanyService.UpdateCompany(id, company, trackChanges: true);
            return NoContent();
        }
    }
}

