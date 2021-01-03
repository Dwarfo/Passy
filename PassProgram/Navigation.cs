using System;
using System.Collections.Generic;
using PassProgram.States;

namespace PassProgram
{
    class Navigation
    {
        private IState rootState;
        private Dictionary<string, IState> stateId2State; 

        public Navigation(List<IState> states)
        {
            stateId2State = new Dictionary<string, IState>();
            foreach (var state in states)
            {
                stateId2State.Add(state.Id, state);
            }
        }
    
        public void BuildCustomNav()
        {
            HashSet<string> statesLeftSet = new HashSet<string>(stateId2State.Keys);
            Console.WriteLine("Select root state");
            WriteAvailableStates(statesLeftSet);
        }

        private void ReceiveState(string stateQuerry)
        {

        }
        private void WriteAvailableStates(HashSet<string> stateNames)
        {
            int i = 1;
            foreach(var stateName in stateNames)
            {
                Console.WriteLine(i + ": " + stateName);
                i++;
            }
        }

        public void BuildNavFromConf(string confAddr)
        {

        }
    }
}