using Entities.Modeles;
using Shared.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackchanges);
        EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackchanges);
        EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackchanges);
        void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges);
        void UpdateEmployeeForCompany(Guid compayId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool cmpTrackChanges, bool empTrackChanges);

        (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeToPAtch(Guid companyId, Guid id, bool compTrackChanges, bool empTrackChanges);
        void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
    }
}