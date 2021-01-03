using System;

namespace PassProgram.Commands
{
    interface ICommand
    {
        string Name {get;}
        string Literal {get;}
        OutsideMessage Execute(OutsideMessage msg);
    }
}
