using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityDemo.Common.Entities.Security;

namespace UnityDemo.Common
{
    public interface IUserDomain
    {
        IUser GetUser(int userId);
    }
}
