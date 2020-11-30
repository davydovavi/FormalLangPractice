using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Davydova_FormalLang_SecondEx
{
    public class FileStreamer
    {
        public Machine GetMachine(string fileName)
        {
            Machine machine = null;
            string message;
            using (StreamReader stream = new StreamReader(fileName))
            {
                message = stream.ReadToEnd();
                machine = JsonConvert.DeserializeObject<Machine>(message);
            }
            return machine;
        }

        public Lexer GetLexer()
        {
            List<Machine> machines = new List<Machine>();
            Machine machine1 = GetMachine("integermachine.txt");
            Machine machine2 = GetMachine("floatmachine.txt");
            Machine machine3 = GetMachine("idmachine.txt");
            Machine machine4 = GetMachine("booleanmachine.txt");
            Machine machine5 = GetMachine("whitespacemachine.txt");
            Machine machine6 = GetMachine("operationmachine.txt");
            Machine machine7 = GetMachine("keywordmachine.txt");
            
            machines.Add(machine1);
            machines.Add(machine2);
            machines.Add(machine3);
            machines.Add(machine4);
            machines.Add(machine5);
            machines.Add(machine6);
            machines.Add(machine7);

            return new Lexer(machines);
        }
    }
}
