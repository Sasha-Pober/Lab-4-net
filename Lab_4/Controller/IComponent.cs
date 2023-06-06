using System;
using System.Collections.Generic;
using System.Text;

namespace Controller
{
    public interface IComponent
    {
        void WriteData(string text);
        string ReadData();
    }
}
