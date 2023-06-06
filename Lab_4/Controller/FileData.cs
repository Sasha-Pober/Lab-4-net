using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Controller
{
    public class FileData : IComponent
    {
        private string path;
        
        public FileData(string path)
        {
            this.path = path;
        }

        public void WriteData(string text)
        {
            using(StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(text);
            }
        }

        public string ReadData()
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
