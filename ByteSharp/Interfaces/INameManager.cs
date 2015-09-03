using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Name;

namespace ByteSharp.Interfaces
{
    public interface INameManager
    {
        Task<NameResponse> GetNamesAsync();

        Task<NameResponse> ValidateNameAsync(string name);
    }
}
