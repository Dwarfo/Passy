using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PassProgram.InputInterpretation
{
    class TestInput : IInputCont
    {
        private Context context;
        private int i = 0;

        public bool HasCommands { get {return true;}}

        public TestInput()
        {

        }

        private void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;         
            if (message?.Type == MessageType.Text)
            {
                Console.WriteLine("Inside ID: " + message.MessageId);
            }
        } 
        public OutsideMessage GetNextCommand()
        {
            string cmd = Console.ReadLine();
            i++;
            return new OutsideMessage(i.ToString(), cmd);            
        }
        public void SendInfo(OutsideMessage msg)
        {
            Console.WriteLine("ID: " + msg.msgId);
            Console.WriteLine(msg.messageText);
        }

        public void ShutDown()
        {
            
        }

        public void SetContext(Context ctx)
        {
            this.context = ctx;
        }

        private void generateId()
        {

        }
    }
}
