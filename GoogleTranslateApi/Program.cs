using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTranslateApi
{
    class Program
    {
        static void Main(string[] args)
        {
            while(true)
            {
                Console.WriteLine("Введите слово для перевода");
                Console.WriteLine($"Перевод:{Translator.Translate(Console.ReadLine())}");
                Console.WriteLine("Хотите ввести перевести что-нибудь еще?(Y/N)");
                string res = Console.ReadLine().ToUpper();
                switch(res)
                {
                    case "Y":
                        continue;
                    case "N":
                        break;
                    default:
                        break;
                }
                break;
                    
                   
                    
                    

            }
            
        }
    }
}
