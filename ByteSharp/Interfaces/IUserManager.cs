using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteSharp.Entities.User;

namespace ByteSharp.Interfaces
{
    public interface IUserManager
    {
        Task<UserResponse> GetStatusAsync();

        Task<UserResponse> GetAccountAsync();

        Task<UserResponse> UpdateAccountAsync(string description = "", string timezone = "America/New_York");

        Task<UserResponse> DeactivateUserAsync();

        Task<UserResponse> ReactivateUserAsync();
    }
}
