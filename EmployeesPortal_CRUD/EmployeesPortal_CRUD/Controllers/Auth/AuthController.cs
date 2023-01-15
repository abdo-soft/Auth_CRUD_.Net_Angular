using EmployeesPortal_CRUD.Resource.Requests;
using EmployeesPortal_CRUD.Resource.Responses;
using EmployeesPortal_CRUD.Routes;
using EmployeesPortal_CRUD.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EmployeesPortal_CRUD.Controllers.Auth
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AuthController : ControllerBase
    {
        private IAuthServices _authServices;

        public AuthController(IAuthServices authService)
        {
            _authServices = authService;
        }


        [AllowAnonymous]
        [HttpPost(ApiRoutes.AuthRoute.Login)]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
                return Ok(new AuthResponse
                {
                    Errors = new[] { " Validation Error  " }
                });
            var authResponse = await _authServices.Authenticate(model.Username, model.Password);

            if (!authResponse.Success)  
            {
                return Ok(authResponse);
            }

            return Ok(authResponse);
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.AuthRoute.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (!ModelState.IsValid)
                return Ok(new AuthResponse
                {
                    Errors = new[] { " Validation Error  " }
                });
            var authResponse = await _authServices.Register(model.Email,model.Username, model.Password);

            if (!authResponse.Success)  
            {
                return Ok(authResponse);
            }

            return Ok(authResponse);
        }

    }
}
