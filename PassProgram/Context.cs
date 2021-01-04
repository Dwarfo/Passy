using System;
using System.Collections.Generic;
using PassProgram.Commands;
using PassProgram.States;


namespace PassProgram
{
    class Context : Singleton<Context>
    {
        public delegate void SampleEventHandler(object sender, OutsideMessage e);
        public event SampleEventHandler messageEvent;
        private BaseState currentState;
        private Dictionary<string, BaseState> id2State;
        public string CurrentStateName {get {return currentState.Id;}}
        public Context()
        {
            //TODO: Make nav manager
            Init(this);
            id2State = new Dictionary<string, BaseState>();
            id2State.Add("start", new BaseState("start", new List<ICommand>{
                new NavigateCommand(),
                new HelpCommand()
                }));
            id2State.Add("genPass", new BaseState("genPass", new List<ICommand>{
                new NavigateCommand(),
                new HelpCommand()
                }));

            id2State["start"].AddChildState(id2State["genPass"]);
            id2State["genPass"].AddChildState(new BaseState("TestState1", new List<ICommand>()));
            id2State["genPass"].AddChildState(new BaseState("TestState2", new List<ICommand>()));

            currentState = id2State["start"];
        }
        public void testMethod()
        {
            Console.WriteLine("Current id: " + currentState.Id);
            Console.WriteLine(currentState.ShowCommands());
        }

        public bool Navigate(string navstate)
        {
            if(currentState.CanNavigate(navstate))
            {
                currentState = id2State[navstate];
                currentState.ShowCommands();
                return true;
            }
            else 
            {
                //Console.WriteLine("Cannot navigate");
                return false;
            }
        }

        public void Execute(OutsideMessage command)
        {
            if(command.msgId == null)
                return;
            try
            {
                OutsideMessage response = currentState.ExecuteCommand(command);
                messageEvent?.Invoke(this, response);
            }
            catch(Exception e)
            {
                Console.WriteLine("Something went wrong");
                messageEvent?.Invoke(this, new OutsideMessage(command.msgId, "Error occured: " + e.StackTrace + "\n" + e.Message));
            }
            //Console.WriteLine("Response: " + response.msgId + " | " + response.messageText);
        }

        public NavInfo GetNavigableStates()
        {
            return new NavInfo(currentState.GetNavigableStates(), currentState.ParentId);
        }
    }
}
