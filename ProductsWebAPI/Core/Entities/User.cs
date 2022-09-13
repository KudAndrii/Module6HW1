using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    using Core.Enums;
    public class User
    {
        private static int _id = -1;
        public User()
        {
            _id++;
            Id = _id;
        }

        public int Id { get; }
        public string Login { get; init; }
        public int Password { get; init; }
        public Role Role { get; init; }
    }
}
