using System;
using System.Collections.Generic;
using PassProgram;

namespace PassProgram.Commands
{
    public class HelpCommand : ICommand
    {
        private string name = "Show helpful information";
        private string literal = "help";

        public HelpCommand(){}

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

            return new OutsideMessage(msg.msgId, HelpDetails(args[1]));
        }

        private bool ValidateCommand(OutsideMessage msg, out string errorMsg){

            var args = msg.messageText.Split(' ');
            if(args.Length < 2)
            {
                errorMsg = "Write what you want help for";
                return false;
            }

            errorMsg = "success";
            return true;
        }

        private string HelpDetails(string argument)
        {
            string details;
            switch (argument)
            {
                case "navigation":
                case "nav":
                    NavInfo navInfo = Context.Instance.GetNavigableStates();
                    details = navInfo.Parent == null ? "" : navInfo.Parent + "\n";
                    details += "|>" + Context.Instance.CurrentStateName + ":";
                    foreach (string navState in navInfo.Children)
                    {
                        details += "\n|--" + navState;
                    }
                    break;
                default:
                    details = " 'help' + any other command you want help with";
                    break;
            }

            return details;
        }
    }
}
