using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davydova_FormalLang_SecondEx
{
    public class Lexer
    {
        List<Machine> _machines;
        Dictionary<Machine, string> _tokens;

        public Lexer (List<Machine> machines)
        {
            this._machines = machines;
            _tokens = new Dictionary<Machine, string>();
            _tokens.Add(machines[0], "integer");
            _tokens.Add(machines[1], "float");
            _tokens.Add(machines[2], "id");
            _tokens.Add(machines[3], "boolean");
            _tokens.Add(machines[4], "whitespace");
            _tokens.Add(machines[5], "operation");
            _tokens.Add(machines[6], "keyword");
        }

        public HashSet<KeyValuePair<string, string>> GetTokensList(string inputString, ref int offset)
        {
            HashSet<KeyValuePair<string, string>> result = new HashSet<KeyValuePair<string, string>>();
            Machine machine = null;
            string currentSubstring = "";
            int max = -1;
            bool isIntValue = false;
            while (offset < inputString.Length)
            {
                machine = null;
                currentSubstring = "";
                max = -1;
                isIntValue = false;
                foreach (var currentMachine in _machines)
                {
                    KeyValuePair<bool, int> currentResult = currentMachine.GetIntValues(inputString, offset);
                    if (currentResult.Key == true)
                    {
                        isIntValue = true;
                        if (currentResult.Value > max)
                        {
                            max = currentResult.Value;
                            machine = currentMachine;
                            currentSubstring = inputString.Substring(offset, currentResult.Value);
                        }
                        if (currentResult.Value == max)
                        {
                            if (currentMachine.priority > machine.priority)
                            {
                                machine = currentMachine;
                                currentSubstring = inputString.Substring(offset, currentResult.Value);
                            }
                        }
                    }
                }
                if (isIntValue)
                {
                    result.Add(new KeyValuePair<string, string>(currentSubstring, _tokens[machine]));
                    offset += max;
                }
                else
                {
                    offset++;
                }

            }
            return result;
        }
    }
}
