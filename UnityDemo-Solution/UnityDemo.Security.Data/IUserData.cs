using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityDemo.Security.Data
{
    public interface IUserData
    {
        User GetUser(int id);
    }
}
