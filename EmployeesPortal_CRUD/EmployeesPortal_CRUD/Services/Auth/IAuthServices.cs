using EmployeesPortal_CRUD.Resource.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesPortal_CRUD.Services.Auth
{
    public interface IAuthServices
    {
        Task<AuthResponse> Authenticate(string username, string password);
        Task<AuthResponse> Register(string email,string username, string password);
    }
}
