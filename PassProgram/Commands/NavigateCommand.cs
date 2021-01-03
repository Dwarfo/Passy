using System;
using PassProgram;

namespace PassProgram.Commands
{
    public class NavigateCommand : ICommand
    {
        private string name = "Navigate";
        private string literal = "goto";

        public NavigateCommand(){}

        public string Name {get {return name;}}
        public string Literal {get {return literal;}}

        public OutsideMessage Execute(OutsideMessage msg)
        {
            var args = msg.messageText.Split(' ');
            string errorMsg;
            if(!ValidateCommand(msg, out errorMsg))
            {
                return new OutsideMessage(msg.msgId, errorMsg);
            }
            bool navSuccess = Context.Instance.Navigate(args[1]);
            
            return new OutsideMessage(msg.msgId, navSuccess ? "Navigated to " + args[1] : "Cannot navigate to " + args[1]);
        }

        private bool ValidateCommand(OutsideMessage msg, out string errorMsg){

            var args = msg.messageText.Split(' ');
            if(args.Length < 2)
            {
                errorMsg = "No destination specified";
                return false;
            }

            errorMsg = "success";
            return true;
        }
    }
}
