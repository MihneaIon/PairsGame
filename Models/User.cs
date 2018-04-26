using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs.Models
{
    [Serializable]
    public class User
    {
        public User()
        {

        }

        public User(String name,String avatar)
        {
            Name = name;
            Avatar = avatar;
        }

        public string Name { get; set; }
        public string Avatar { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
