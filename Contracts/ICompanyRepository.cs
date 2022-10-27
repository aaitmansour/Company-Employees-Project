using Entities.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackchanges);
        Company GetCompany(Guid companyId, bool trackchanges);
        IEnumerable<Company> GetByIds(IEnumerable<Guid> Ids, bool trackChanges);
        void CreateCompany(Company company);
        void DeleteCompany(Company company);
    }
}
