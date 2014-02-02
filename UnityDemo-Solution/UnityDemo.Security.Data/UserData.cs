using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityDemo.Security.Data
{
    internal class UserData : IUserData
    {
        public User GetUser(int id)
        {
            //Just instantiate and pass..Ideally can come from a database
            return new User
                {
                    Id = id,
                    Name = "Manoj Kumar",
                    Age = 28
                };
        }
    }
}
