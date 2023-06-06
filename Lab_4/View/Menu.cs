using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;

namespace View
{
    public class Menu : IMenu
    {
        private IComponent data;

        public Menu(IComponent component)
        {
            data = component;
        }

        public void Encrypt(string text)
        {
            var decorator = new EncryptionDecorator(data);
            decorator.WriteData(text);
            Console.WriteLine("Text was successfully encrypted");
        }

        public void Decrypt(string text)
        {
            var decorator = new EncryptionDecorator(data);
            Console.WriteLine(decorator.ReadData());
        }

        public void Translate(string text)
        {
            var decorator = new APIDecorator(data);
            decorator.WriteData(text);
            Console.WriteLine("Text was successfully translated");
        }

        public void ReTranslate(string text)
        {
            var decorator = new APIDecorator(data);
            Console.WriteLine(decorator.ReadData());
        }

        public void TranslateEncrypt(string text)
        {
            var decorator = new EncryptionDecorator(data);
            var decorator2 = new APIDecorator(decorator);
            decorator2.WriteData(text);
            Console.WriteLine("Text was successfully translated and encrypted");
        }

        public void DecryptReTranslate(string text)
        {
            var decorator = new EncryptionDecorator(data);
            var decorator2 = new APIDecorator(decorator);
            Console.WriteLine(decorator2.ReadData());

        }

        public void ReadFile(string text)
        {
            Console.WriteLine(data.ReadData());
        }
    }
}
