using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Davydova_FormalLang_FirstEx
{
    public class FileStreamer
    {
        Machine myMachine = null;

        public Machine ReadingMachine(string fileName)
        {
            char[] charSeparators = new char[] { '\n' };
            string[] currentTransition = new string[3];
            int currentState = 0;
            Dictionary<KeyValuePair<int, string>, int> machineTransitions = new Dictionary<KeyValuePair<int, string>, int>();
            using (StreamReader fileIn = new StreamReader(fileName))
            {
                string[] readedValues = fileIn.ReadToEnd().Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (int.TryParse(readedValues[0], out int state))
                {
                    currentState = state;
                }
                else
                {
                    throw new FormatException("Wrong value. Current state must be int value.");
                }
                
                for (int i = 1; i<readedValues.Length; i++)
                {
                    currentTransition = readedValues[i].Split(' ');
                    if (int.TryParse(currentTransition[0], out int start))
                    {
                        if (int.TryParse(currentTransition[2], out int finish))
                        {
                            
                            machineTransitions.Add(new KeyValuePair<int, string>(start, currentTransition[1]), finish);
                        }
                        else
                        {
                            throw new FormatException("Wrong values. Enter machine transitions in format <start symbolorsubstring finish>");
                        }
                    }
                }
                
            }
            myMachine = new Machine(machineTransitions, currentState);
            return myMachine;
        }

        public Machine GetMachine(string fileName)
        {
            Machine machine= null;
            using (StreamReader stream = new StreamReader(fileName))
            {
                string inputString = stream.ReadToEnd();
                machine = JsonConvert.DeserializeObject<Machine>(inputString);
            }
            return machine;
        }
    }
}
