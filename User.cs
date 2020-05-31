using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handbook_numismatist
{
    [Serializable]
    public  class User
    {
        // Имя
        public string Name { set; get; }
        // Пароль
        public int Password { set; get; }
        public User(string name, int password)
        {
            Name = name;
            Password = password;
        }
    }
}
