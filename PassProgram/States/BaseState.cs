using System;
using PassProgram.Commands;
using System.Collections.Generic;

namespace PassProgram.States
{   
    class BaseState
    {
        private string id = "base";
        private string parentId;
        private Dictionary<string, ICommand> literal2Command;
        private HashSet<string> navigableStatesSet;

        public BaseState()
        {
            literal2Command = new Dictionary<string, ICommand>();
        }
        public BaseState(string id, IEnumerable<ICommand> commands)
        {
            this.id = id;
            literal2Command = new Dictionary<string, ICommand>();
            navigableStatesSet = new HashSet<string>();
            foreach(var command in commands)
            {
                literal2Command.Add(command.Literal, command);
            }
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

        public bool CanNavigate(string stateId)
        {
            return navigableStatesSet.Contains(stateId) || stateId == parentId;
        }

        public void AddChildState(BaseState childState)
        {
            if(!string.IsNullOrEmpty(childState.parentId))
            {
                Console.WriteLine("Node is already connected, clear parent id to set it again");
                return;
            }
            navigableStatesSet.Add(childState.Id);
            Console.WriteLine("Node " + id + " is now a parent of " + childState.Id);
            childState.ParentId = id;
        }

        public void RemoveChildState(BaseState childState)
        {
            navigableStatesSet.Remove(childState.Id);
        }

        public OutsideMessage ExecuteCommand(OutsideMessage msg)
        {
            var args = msg.messageText.Split(' ');
            if(literal2Command.ContainsKey(args[0]))
            {
                return literal2Command[args[0]].Execute(msg);
            }
            
            return new OutsideMessage(msg.msgId, "No command found");
        }

        public IEnumerable<string> GetNavigableStates()
        {
            return navigableStatesSet;
        }
    }
}