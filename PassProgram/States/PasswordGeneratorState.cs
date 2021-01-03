using System;
using PassProgram.Commands;
using System.Collections.Generic;

namespace PassProgram.States
{   
    class PasswordGeneratorState : IState
    {
        private const string id = "pass_gen";
        private string parentId;
        private Dictionary<string, ICommand> literal2Command;

        public PasswordGeneratorState()
        {
            literal2Command = new Dictionary<string, ICommand>();
        }
        public string Id {get {return id;}}
        public string ParentId {get {return parentId;} set {parentId = value;}}

        public List<string> ShowCommands()
        {
            return new List<string>(this.literal2Command.Keys); 
        }
        public void AddCommand(ICommand command)
        {
            literal2Command.Add(command.Name, command); //Add Handling
        }
        public void RemoveCommand(string commandName)
        {
            literal2Command.Remove(commandName);        //Add Handling
        }

        public bool canNavigate(string stateId)
        {
            throw new NotImplementedException();
        }
    }
}