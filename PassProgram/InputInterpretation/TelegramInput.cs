using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace PassProgram.InputInterpretation
{
    class TelegramInput : IInputCont
    {
        private TelegramBotClient client;
        private string token;
        private Context context;
        private Dictionary<string, string> commandId2sourceId;
        private Queue<OutsideMessage> commandQueue;
        public bool HasCommands { get {return commandQueue.Count > 0;}}
        public TelegramInput(string token)
        {
            this.token = token;
            commandId2sourceId = new Dictionary<string, string>();
            commandQueue = new Queue<OutsideMessage>();
            client = new TelegramBotClient(token);
		    client.OnMessage += BotOnMessageReceived;
		    //client.OnMessageEdited += BotOnMessageReceived;
		    client.StartReceiving();
        }

        private void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;         
            if (message?.Type == MessageType.Text)
            {
                //await client.SendTextMessageAsync(message.Chat.Id, message.Text);
                Console.WriteLine("Inside ID: " + message.MessageId);
                commandId2sourceId.Add((message.MessageId).ToString(), (message.Chat.Id).ToString());
                commandQueue.Enqueue(new OutsideMessage((message.MessageId).ToString(), message.Text));
                //context.Execute(message.Text);
            }
        } 
        public OutsideMessage GetNextCommand()
        {
            if(commandQueue.Count > 0)
            {
                return commandQueue.Dequeue();
            }
            else
            return new OutsideMessage();
        }
        public async void SendInfo(OutsideMessage msg)
        {
            Console.WriteLine("ID: " + msg.msgId + " msg: " + msg.messageText);

            await client.SendTextMessageAsync(commandId2sourceId[msg.msgId], msg.messageText);

        }

        public void ShutDown()
        {
            client.StopReceiving();
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
