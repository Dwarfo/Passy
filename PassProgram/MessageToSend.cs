using System;
using System.Collections.Generic;
using PassProgram.States;

namespace PassProgram
{
    class MessageToSend
    {
        public string messageText;
        public string msgId;

        public MessageToSend(OutsideMessage omsg)
        {
            this.messageText = omsg.messageText;
            this.msgId = omsg.msgId;
        }
    }
}