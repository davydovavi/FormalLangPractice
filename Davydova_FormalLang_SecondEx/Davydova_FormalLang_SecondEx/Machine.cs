using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davydova_FormalLang_SecondEx
{
    public class Machine
    {
        private Dictionary<KeyValuePair<int, string>, int> _machineTransitions;
        public int currentState { get; set; }
        public int startState { get; set; }
        public int priority { get; set; }
        public HashSet<int> stopState { get; set; }

        public Machine()
        {
            this._machineTransitions = new Dictionary<KeyValuePair<int, string>, int>();
            this.startState = 1;
        }
        public Machine(Dictionary<KeyValuePair<int, string>, int> machineTransitions, int startState, HashSet<int> stopState)
        {
            this._machineTransitions = machineTransitions;
            this.startState = startState;
            this.stopState = stopState;
        }

        public KeyValuePair<KeyValuePair<int, string>, int>[] MachineTransitions
        {
            get
            {
                return this._machineTransitions.ToArray();
            }
            set
            {
                this._machineTransitions = value.ToDictionary(x => x.Key, y => y.Value);
            }
        }

        public KeyValuePair<bool, int> GetIntValues(string inputString, int offset)
        {
            currentState = startState;
            bool isIntValue = false;
            int countOfSymbol = 0;
            int currentIndex = offset;
            while (currentIndex < inputString.Length)
            {
                string substring = inputString[currentIndex].ToString();
                if (_machineTransitions.ContainsKey(new KeyValuePair<int, string>(currentState, substring)))
                {
                    isIntValue = true;
                    countOfSymbol++;
                    currentState = _machineTransitions[new KeyValuePair<int, string>(currentState, substring)];
                    currentIndex++;
                }
                else
                {
                    break;
                }
            }
            if (!stopState.Contains(currentState))
            {
                isIntValue = false;
                countOfSymbol = 0;
            }
            return new KeyValuePair<bool, int>(isIntValue, countOfSymbol);
        }
    }
}
