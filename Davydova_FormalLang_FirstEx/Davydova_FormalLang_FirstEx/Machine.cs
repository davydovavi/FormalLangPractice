using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davydova_FormalLang_FirstEx
{
    public class Machine
    {
        private Dictionary<KeyValuePair<int, string>, int> _machineTransitions;
        public int currentState { get; set; }

        public Machine()
        {
            this._machineTransitions = new Dictionary<KeyValuePair<int, string>, int>();
            this.currentState = 1;
        }
        public Machine(Dictionary<KeyValuePair<int, string>, int> machineTransitions, int currentState)
        {
            this._machineTransitions = machineTransitions;
            this.currentState = currentState;

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
            return new KeyValuePair<bool, int>(isIntValue, countOfSymbol);
        }
    }
}
