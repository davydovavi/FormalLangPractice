using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davydova_FormalLang_FirstEx
{
    class Program
    {
        static void Main(string[] args)
        {
            Machine myMachine = null;
            FileStreamer fileStreamer = new FileStreamer();
            StaticStreamer staticStreamer = new StaticStreamer();

            myMachine = fileStreamer.GetMachine("maininput.txt");
            //myMachine = staticStreamer.GetNewMachine();

            /*foreach (var elem in myMachine.MachineTransitions)
            {
                Console.WriteLine("{0}: {1}", elem.Key.ToString(), elem.Value.ToString());
            }
            while (true)
            {
                Console.WriteLine("Enter your text");
                string inputText = Console.ReadLine();
                Console.WriteLine("Eneter offset:");
                if (int.TryParse(Console.ReadLine(), out var offset))
                {
                    var result = myMachine.GetIntValues(inputText, offset);
                    Console.WriteLine(result);
                    if (result.Key)
                    {
                        Console.WriteLine(inputText.Substring(offset, result.Value));
                    }
                }
                else
                {
                    Console.WriteLine("Incorrect offset");
                }
                Console.WriteLine("Enter...");
                Console.ReadLine();
            }*/

            while(true)
            {
                Console.WriteLine("Enter string for recognize: ");
                string message = Console.ReadLine();
                Console.WriteLine("Enter offset: ");
                if (int.TryParse(Console.ReadLine(), out int offset))
                {
                    var result = myMachine.GetIntValues(message, offset);
                    Console.WriteLine(result);
                    Console.WriteLine(message.Substring(offset, result.Value));
                }
                else
                {
                    Console.WriteLine("Incorrect offset");
                }
                Console.ReadLine();
            }
        }
    }
}
