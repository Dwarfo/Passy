using System;
using PassProgram.Commands;
using System.Collections.Generic;

namespace PassProgram.States
{   
    interface IState
    {
        string Id {get;}
        string ParentId {get;}
        List<string> ShowCommands();
        void AddCommand(ICommand command);
        void RemoveCommand(string commandName);
        bool canNavigate(string stateId);
    }
}
