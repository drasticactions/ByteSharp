using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Flag;

namespace ByteSharp.Interfaces
{
    public interface IFlagsManager
    {
        Task<FlagResponse> FlagByteAsync(string postId, string reason = "");

        Task<FlagResponse> DeleteFlagOnByteAsync(string postId);

        Task<FlagResponse> GetFlagsAsync(string cursor, string scheme = "full");
    }
}
