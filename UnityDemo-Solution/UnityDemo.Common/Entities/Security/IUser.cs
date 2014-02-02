using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityDemo.Common.Entities.Security
{
    public interface IUser
    {
        int Id { get; }
        string Name { get; set; }
        int Age { get; set; }

        void UpdateAddress();
    }
}
