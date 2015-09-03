using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.Auth;

namespace ByteSharp.Interfaces
{
    public interface IAuthManager
    {
        Task<bool> RequestCodeAsync(string phoneNumber);

        Task<AuthResponse> RegisterAsync(string phoneNumber, string code, string timezone);
    }
}
