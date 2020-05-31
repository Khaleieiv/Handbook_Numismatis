using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Handbook_numismatist
{
    [Serializable]
    public class Handbook
    {
        
        public List<User> Users { private set; get; }
        
        public Handbook()
        {
            Users = new List<User>();         
        }
        // Метод сохранения User
        public void Save()
        {
            new Dao(this).Save();
            SaveUsers();
        }
        private void SaveUsers()
        {
            using (var wr = new StreamWriter("Users.txt"))
            {
                wr.WriteLine(Users.Count);
                foreach (var b in Users)
                {
                    wr.WriteLine(b.Name);
                    wr.WriteLine(b.Password);
                }
            }
        }
        // Метод поиска User в файлах
        public void Load()
        {
            new Dao(this).Load();
        }
    }
}
