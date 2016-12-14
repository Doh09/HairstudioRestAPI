using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HSRestAPI_DLL.Entities
{
    public class User : IEntity
    {
        #region IEntity
        public int ID { get; set; }
        #endregion
        /*User : IEntity
        - Username
        - Password
        - Name
        - Phone Number
        - Email
        - UserType(string)*/

        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string UserType { get; set; }
    }
}
