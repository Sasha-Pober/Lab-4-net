using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface IMenu
    {
        void Encrypt(string text);
        void Decrypt(string text);
        void Translate(string text);
        void ReTranslate(string text);
        void TranslateEncrypt(string text);
        void DecryptReTranslate(string text);
        void ReadFile(string text);

    }
}
