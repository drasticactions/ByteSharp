using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.ComputerResult;
using ByteSharp.Entities.Computers;
using ByteSharp.Entities.ComputerSelectionResult;

namespace ByteSharp.Interfaces
{
    public interface IComputerManager
    {
        Task<ComputersResponse> GetComputersAsync();

        Task<ComputerSelectionResultResponse> GetSelectedComputerAsync(string subdomain);

        Task<ComputerResultResponse> SendQueryToComputerAsync(string subdomain, string query);
    }
}
