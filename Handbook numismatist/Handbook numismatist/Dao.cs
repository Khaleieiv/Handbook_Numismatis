using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Handbook_numismatist
{
    class Dao
    {
        Handbook list;
        const string filePath = "list.bin";

        public Dao(Handbook list)
        {
            this.list = list;
        }
        // Метод создания файла для User
        public void Save()
        {
            using (Stream stream = File.Create(filePath))
            {
                var serializer = new BinaryFormatter();
                serializer.Serialize(stream, list);
            }
        }
        // Метод открытия файла для User
        public void Load()
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                var serializer = new BinaryFormatter();
                Handbook st = (Handbook)serializer.Deserialize(stream);
                Copy(st.Users, list.Users);
            }

            void Copy<T>(List<T> from, List<T> to)
            {
                to.AddRange(from);
            }
        }
    }
}
