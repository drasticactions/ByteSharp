using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Activity;

namespace ByteSharp.Interfaces
{
    public interface IActivityManager
    {
        Task<ActivityResponse> GetMessagesAsync(string cursor);
    }
}
