using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Davydova_FormalLang_SecondEx
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStreamer fileStreamer = new FileStreamer();
            Lexer lexer = fileStreamer.GetLexer();
            string newMessage = "";
            using (StreamReader stream = new StreamReader("input.txt"))
            {
                newMessage = stream.ReadToEnd();
            }

            int offset = 0;
            HashSet<KeyValuePair<string, string>> result = lexer.GetTokensList(newMessage, ref offset);
            foreach (var pair in result)
            {
                Console.WriteLine(pair);
            }

            //TestLexer testLexer = new TestLexer();
            //testLexer.IntegerTest();
            //testLexer.FloatTest();
            //testLexer.BooleanTest();
            Console.ReadLine();
        }
    }
}
