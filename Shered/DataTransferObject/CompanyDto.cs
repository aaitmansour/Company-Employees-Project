using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObject
{
    [Serializable]
    public record CompanyDto
    {
        public Guid id { get; init; }
        public string? name { get; init; }
        public string? fulladresse { get; init; }
    }
}
