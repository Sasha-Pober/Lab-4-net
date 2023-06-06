using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Controller
{
    struct LangLiteral
    {
        public char BigLetter;
        public char SmallLetter;
        public int num;
    }
    public class EncryptionDecorator : FileDataDecorator
    {
        public EncryptionDecorator(IComponent data) : base(data) { }

        private List<LangLiteral> literals => new List<LangLiteral>()
        {
            new LangLiteral{BigLetter = 'A', SmallLetter = 'a', num = 26},
            new LangLiteral{BigLetter = 'А', SmallLetter = 'а', num = 33}
        };

        public override void WriteData(string text)
        {
            string encryptedText;
            if (IsLatin(text))
                encryptedText = EncryptString(text, literals[0].BigLetter, literals[0].SmallLetter, literals[0].num);
            else
                encryptedText = EncryptString(text, literals[1].BigLetter, literals[1].SmallLetter, literals[1].num);
            base.WriteData(encryptedText);
        }

        public override string ReadData()
        {
            string data = base.ReadData();

            if (IsLatin(data))
                return DecryptString(data, literals[0].BigLetter, literals[0].SmallLetter, literals[0].num);
            else
                return DecryptString(data, literals[1].BigLetter, literals[1].SmallLetter, literals[1].num);
        }

        private string EncryptString(string input, char letterBig, char letterSmall, int num)
        {
            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    char baseChar = char.IsUpper(chars[i]) ? letterBig : letterSmall;
                    chars[i] = (char)(((chars[i] - baseChar + 1) % num) + baseChar);
                }
            }

            return new string(chars);
        }

        private string DecryptString(string input, char letterBig, char letterSmall, int num)
        {
           
            char[] chars = input.ToCharArray();

            for (int i = 0; i < chars.Length; i++)
            {
                if (char.IsLetter(chars[i]))
                {
                    char baseChar = char.IsUpper(chars[i]) ? letterBig : letterSmall;
                    chars[i] = (char)(((chars[i] - baseChar - 1 + num) % num) + baseChar);
                }
            }

            return new string(chars);
        }
        private bool IsLatin(string input)
        {
            if (Regex.IsMatch(input[0].ToString(), @"\p{IsBasicLatin}"))
            {
                /*letterBig = literals[0].BigLetter;
                letterSmall = literals[0].SmallLetter;
                num = literals[0].num;*/
                return true;
            }
            else
            {
                return false;
                /*letterBig = literals[1].BigLetter;
                letterSmall = literals[1].SmallLetter;
                num = literals[1].num;*/
            }
        }
    }

    
}
