using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davydova_FormalLang_FirstEx
{
    public class StaticStreamer
    {
        Machine myMachine = null;
        public Machine GetNewMachine()
        {
            int currentState = 1;
            Dictionary<KeyValuePair<int, string>, int> machineTransitions = new Dictionary<KeyValuePair<int, string>, int>();
            machineTransitions.Add(new KeyValuePair<int, string>(1, "0"), 2);
            machineTransitions.Add(new KeyValuePair<int, string>(1, "1"), 2);
            for (int i = 1; i < 5; i++)
            {
                machineTransitions.Add(new KeyValuePair<int, string>(1, i.ToString()), 3);
            }
            for (int i = 2; i < 4; i++)
            {
                machineTransitions.Add(new KeyValuePair<int, string>(2, i.ToString()), 3);
            }
            for (int i = 3; i < 5; i++)
            {
                machineTransitions.Add(new KeyValuePair<int, string>(3, i.ToString()), 3);
            }
            myMachine = new Machine(machineTransitions, currentState);
            return myMachine;
        }
    }
}
