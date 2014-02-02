using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityDemo.Security.EntitiesImp;

namespace UnityDemo.Security.Mappers
{
    static class MapperExtensions
    {
        internal static User MapTo(this Data.User user)
        {
            return new User { Id = user.Id, Name = user.Name, Age = user.Age };
        }

        internal static Data.User MapFrom(this User user)
        {
            return new Data.User { Id = user.Id, Name = user.Name, Age = user.Age };
        }
    }
}
