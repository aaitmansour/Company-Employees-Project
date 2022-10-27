using Entities.Modeles;
using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)

        {
        }

        public void CreateCompany(Company company) => Create(company);

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)=>
            FindAll(trackChanges)
            .OrderBy(c => c.name)
            .ToList();

        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackchanges) =>
            FindByCondition(x => ids.Contains(x.id), trackchanges)
            .ToList();
        

        public Company GetCompany(Guid companyId, bool trackchanges) =>
            FindByCondition(c => c.id.Equals(companyId), trackchanges)
            .SingleOrDefault();

        public void DeleteCompany(Company company) => Delete(company);
        
    }
}
