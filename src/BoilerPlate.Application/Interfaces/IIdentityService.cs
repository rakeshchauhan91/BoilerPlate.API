using BoilerPlate.Application.DTO;
using BoilerPlate.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlate.Application.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);

        Task<ApplicationUserDto> CheckUserPassword(string userName, string password);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<bool> UserIsInRole(string userId, string role);

        Task<Result> DeleteUserAsync(string userId);
    }
}
