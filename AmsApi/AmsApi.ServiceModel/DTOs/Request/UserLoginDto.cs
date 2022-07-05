using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.ServiceModel.DTOs.Request
{
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
