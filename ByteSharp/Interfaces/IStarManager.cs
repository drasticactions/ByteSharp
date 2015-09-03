using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Flag;
using ByteSharp.Entities.Star;

namespace ByteSharp.Interfaces
{
    public interface IStarManager
    {
        Task<StarResponse> StarByteAsync(string postId);

        Task<StarResponse> DeleteStarOnByteAsync(string postId);

        Task<StarResponse> GetStarsAsync(string cursor = "", string scheme = "full");
    }
}
