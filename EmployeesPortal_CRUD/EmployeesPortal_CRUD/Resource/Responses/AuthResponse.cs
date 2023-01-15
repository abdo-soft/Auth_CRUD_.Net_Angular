using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesPortal_CRUD.Resource.Responses
{
    public class AuthResponse
    {

        public string Token { get; set; }
        public bool Success { get; set; }
        // public string ErrorMessage {get ; set ;}
        public IEnumerable<string> Errors { get; set; }

    }
}
