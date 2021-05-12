using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CursoMVC.Models.Users
{
    public class UserModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }
        public string Profile { get; set; }
        public string Password { get; set; }

    }
}