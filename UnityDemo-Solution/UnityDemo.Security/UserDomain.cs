using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityDemo.Common;
using UnityDemo.Common.Entities.Security;
using UnityDemo.Security.Data;
using UnityDemo.Security.Mappers;

namespace UnityDemo.Security
{
    using Data = UnityDemo.Security.Data;

    internal class UserDomain : IUserDomain
    {
        public readonly IUserData _data;

        public UserDomain(IUserData data)
        {
            _data = data;
        }

        public IUser GetUser(int userId)
        {
            var user = _data.GetUser(userId);

            return user.MapTo();
        }
    }
}
