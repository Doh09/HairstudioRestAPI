using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;

namespace HSRestAPI_DLL
{
    public class User : AbstractEntity
    {
        /*User : AbstractEntity
        - Username
        - Password
        - Name
        - Phone Number
        - Email
        - UserType(string)*/
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
