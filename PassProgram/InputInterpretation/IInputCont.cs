using System;

namespace PassProgram.InputInterpretation
{
    interface IInputCont
    {
        bool HasCommands {get;}
        OutsideMessage GetNextCommand();
        void SendInfo(OutsideMessage msg);
        void ShutDown();
        void SetContext(Context ctx); 
    }
}
