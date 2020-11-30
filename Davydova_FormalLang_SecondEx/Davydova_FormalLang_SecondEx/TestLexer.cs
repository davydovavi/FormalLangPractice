using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davydova_FormalLang_SecondEx
{
    public class TestLexer
    {
        public void IntegerTest()
        {
            FileStreamer fileStreamer = new FileStreamer();
            Machine machine = fileStreamer.GetMachine("integermachine.txt");
            int offset = 6;
            string inputString = "qwerty12345ghkk";
            KeyValuePair<bool, int> supposedPair = new KeyValuePair<bool, int>(true, 5);
            string supposedString = "12345";
            KeyValuePair<bool, int> realPair = machine.GetIntValues(inputString, offset);
            string realString = inputString.Substring(offset, realPair.Value);
            Console.WriteLine("Integer test:");
            Console.WriteLine("pairs: {0}", realPair.ToString().Equals(supposedPair.ToString()));
            Console.WriteLine("strings: {0}", realString.Equals(supposedString));
        }
        public void FloatTest()
        {
            FileStreamer fileStreamer = new FileStreamer();
            Machine machine = fileStreamer.GetMachine("floatmachine.txt");
            string inputString = "yui-1.45e2iop";
            int offset = 3;
            KeyValuePair<bool, int> supposedPair = new KeyValuePair<bool, int>(true, 7);
            var supposedString = "-1.45e2";
            KeyValuePair<bool, int> realPair = machine.GetIntValues(inputString, offset);
            string realString = inputString.Substring(offset, realPair.Value);
            Console.WriteLine("Float test:");
            Console.WriteLine("pairs: {0}", realPair.ToString().Equals(supposedPair.ToString()));
            Console.WriteLine("strings: {0}", realString.Equals(supposedString));
        }
        public void BooleanTest()
        {
            FileStreamer fileStreamer = new FileStreamer();
            Machine machine = fileStreamer.GetMachine("booleanmachine.txt");
            string inputString = "7896false";
            int offset = 4;
            KeyValuePair<bool, int> supposedPair = new KeyValuePair<bool, int>(true, 5);
            var supposedString = "false";
            KeyValuePair<bool, int> realPair = machine.GetIntValues(inputString, offset);
            string realString = inputString.Substring(offset, realPair.Value);
            Console.WriteLine("Boolean test:");
            Console.WriteLine("pairs: {0}", realPair.ToString().Equals(supposedPair.ToString()));
            Console.WriteLine("strings: {0}", realString.Equals(supposedString));
        }
    }
}
