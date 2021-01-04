using System;
using System.Collections.Generic;
using PassProgram.States;

namespace PassProgram
{
    public class NavInfo
    {
        private IEnumerable<string> children;
        private string parent;

        public NavInfo(IEnumerable<string> children, string parent)
        {
            this.children = children;
            this.parent = parent;
        }
        public IEnumerable<string> Children { get {return children;}}
        public string Parent { get {return parent;}}
    }
}