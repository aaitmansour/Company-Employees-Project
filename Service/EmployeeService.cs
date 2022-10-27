using Contracts;
using Service.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObject;
using Entities.Exceptions;
using Entities.Modeles;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper) 
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackchanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackchanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);
            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);
            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            _repository.Save();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackchanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackchanges);
            if (company is null)
                throw new EmployeeNotFoundException(companyId);
            var employeeForCompany = _repository.Employee.GetEmployee(companyId, id, trackchanges);
            if (employeeForCompany is null)
                throw new EmployeeNotFoundException(id);

            _repository.Employee.DeleteEmployee(employeeForCompany);
            _repository.Save();
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackchanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackchanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeesDto = _repository.Employee.GetEmployee(companyId, id, trackchanges);
            if (employeesDto is null)
                throw new EmployeeNotFoundException(id);

            var employee = _mapper.Map<EmployeeDto>(employeesDto);
            return employee;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackchanges)
        {
            var copmpany = _repository.Company.GetCompany(companyId, trackchanges);
            if (copmpany is null)
                throw new CompanyNotFoundException(companyId);

            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackchanges);
            

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return employeesDto;
        }

        public (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeToPAtch(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, compTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = _repository.Employee.GetEmployee(companyId, id, empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(companyId);

            var employeeTopatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);
            return (employeeTopatch, employeeEntity);
        }

        public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            _mapper.Map(employeeToPatch, employeeEntity);
            _repository.Save();
        }

        public void UpdateEmployeeForCompany(Guid compayId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool cmpTrackChanges, bool empTrackChanges)
        {
            var company = _repository.Company.GetCompany(compayId, cmpTrackChanges);
            if (company is null)
                throw new CompanyNotFoundException(compayId);

            var employeeEntity = _repository.Employee.GetEmployee(compayId, id, empTrackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(id);

            _mapper.Map(employeeForUpdate, employeeEntity);
            _repository.Save();
        }
    }
}
