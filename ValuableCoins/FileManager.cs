using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ValuableCoins
{
    class FileManager
    {
        string FilePath { get; set; }

        public FileManager(string filePath)
        {
            FilePath = filePath;
        }

        public void Save(object obj)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.OpenWrite(FilePath);
                bf.Serialize(file, obj);
                file.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public object Load()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                object result = null;
                if (File.Exists(FilePath))
                {
                    FileStream file = File.Open(FilePath, FileMode.Open);

                    result = bf.Deserialize(file);
                    file.Close();

                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
