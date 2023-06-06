using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controller;

namespace View
{
    public class ProgramRunner : IProgramRunner
    {
        private IMenu menu;

        public void SetMenu(IComponent comp)
        {
            menu = new Menu(comp);
        }

        public void Run()
        {
            IComponent component = new FileData("C:\\Users\\HP\\Documents\\kpi\\.NET\\Lab_4\\Controller\\file.txt");
            SetMenu(component);

            Dictionary<MenuItem, Action<string>> command = new Dictionary<MenuItem, Action<string>>()
            {
                { MenuItem.Encrypt, menu.Encrypt},
                { MenuItem.Decrypt, menu.Decrypt},
                { MenuItem.Translate, menu.Translate},
                { MenuItem.ReTranslate, menu.ReTranslate},
                { MenuItem.EncryptTranslate, menu.TranslateEncrypt},
                { MenuItem.DecryptRetranslate, menu.DecryptReTranslate},
                { MenuItem.ReadFile, menu.ReadFile}
            };

            Console.WriteLine("Enter a text");
            string text = Console.ReadLine();

            string ans = "";
            //Console.WriteLine("1. Insert Card\n2. Eject Card\n3. Enter PIN\n4. Get Cash");



            while (!ans.ToLower().Contains("yes"))
            {
                Console.WriteLine("Enter a number of option:");
                int num = int.Parse(Console.ReadLine());
                if (Enum.TryParse((num - 1).ToString(), out MenuItem queryType) && command.ContainsKey(queryType))
                {
                    command[queryType](text);
                }
                else
                {
                    Console.WriteLine("Invalid option number.");
                }
                Console.WriteLine("Do you wish to exit?");
                ans = Console.ReadLine();
            }
        }

        public enum MenuItem
        {
            Encrypt,
            Decrypt,
            Translate,
            ReTranslate,
            EncryptTranslate,
            DecryptRetranslate,
            ReadFile
        }
    }
}
