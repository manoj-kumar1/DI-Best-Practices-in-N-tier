using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityDemo.Common.Entities.Security;

namespace UnityDemo.Security.EntitiesImp
{
    internal class User : IUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public void UpdateAddress()
        {
            throw new NotImplementedException();
        }
    }
}
