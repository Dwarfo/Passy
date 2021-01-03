using System;
using System.Collections.Generic;
using PassProgram.States;

namespace PassProgram
{
    public class OutsideMessage
    {
        public string messageText;
        public string msgId;
        private bool error = false;

        public OutsideMessage(string msgId, string messageText)
        {
            this.messageText = messageText;
            this.msgId = msgId;
        }

        public OutsideMessage(string msgId)
        {
            this.msgId = msgId;
            error = true;
        }
        public OutsideMessage()
        {
            msgId = null;
            messageText = null;
        }
    }
}