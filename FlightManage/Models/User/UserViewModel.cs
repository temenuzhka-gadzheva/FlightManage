using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManage.Models.User
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PersonalNo { get; set; }
        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Role { get; set; }
    }
}
