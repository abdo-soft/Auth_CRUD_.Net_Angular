using EmployeesPortal_CRUD.DBContext;
using EmployeesPortal_CRUD.Helpers;
using EmployeesPortal_CRUD.Models;
using EmployeesPortal_CRUD.Resource.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EmployeesPortal_CRUD.Services.Auth
{
    public class AuthServices : IAuthServices
    {
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly UserManager<ApplicationPetrolUser> _petrolUserManager;
        private readonly AppSettings _appSettings;
        private readonly CrudUserDbContext _crudUserDBContext;


        public AuthServices(IOptions<AppSettings> appSettings, UserManager<ApplicationUser> userManager, CrudUserDbContext userDDContext) {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _crudUserDBContext = userDDContext;
        }

        public async Task<AuthResponse> Authenticate(string username, string password)
        {

            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new HttpResponseException()
                {
                    Status = 401,
                    Value = new ErrorResponse
                    {
                        Errors = new[] { " UserName Is Wrong " },
                        Code = 1
                    },
                };

            }

 
                var userHasValidPasswd = await _userManager.CheckPasswordAsync(user, password);
                if (!userHasValidPasswd)
                {
                    throw new HttpResponseException()
                    {
                        Status = 401,
                        Value = new ErrorResponse
                        {
                            Errors = new[] { " Passord  Is Wrong " },
                            Code = 2
                        }
                    };
                }




            var Tokenusr = CreateToken(user);

            return new AuthResponse
            {
                Token = Tokenusr.ToString(),
                Success = true,
            };

        }

        public async Task<AuthResponse> Register(string email,string username, string password)
        {
            var UserExsits = await _userManager.FindByNameAsync(username);

            if(UserExsits != null)
            {
                throw new HttpResponseException()
                {
                    Status = 401,
                    Value = new ErrorResponse
                    {
                        Errors = new[] { " User Already Exsits " },
                        Code = 0
                    }
                };
            }

            var NewUser = new ApplicationUser() {
                Email = email,
                UserName = username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await _userManager.CreateAsync(NewUser , password);

            if (!result.Succeeded)
            {
                throw new HttpResponseException()
                {
                    Status = 401,
                    Value = new ErrorResponse
                    {
                        Errors = new[] { " User Creation Fail " },
                        Code = 0
                    }
                };
            }

            return new AuthResponse
            {
                Token = NewUser.Id,
                Success = true,
            };

        }


        private string CreateToken(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var claimid = new ClaimsIdentity(new Claim[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                    new Claim("id",user.Id),
                    new Claim("UserName",user.UserName),
                });


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimid,
                Expires = DateTime.UtcNow.AddDays(360),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var Tokenusr = tokenHandler.WriteToken(token);

            return Tokenusr;
        }
    }
}
