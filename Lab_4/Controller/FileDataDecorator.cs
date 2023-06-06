using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public class FileDataDecorator : IComponent
    {
        protected IComponent wrappee;

        public FileDataDecorator(IComponent data)
        {
            wrappee = data;
        }

        public virtual void WriteData(string text)
        {
            wrappee.WriteData(text);
        }

        public virtual string ReadData()
        {
            return wrappee.ReadData();
        }
    }
}
