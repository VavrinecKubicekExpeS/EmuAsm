using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuAsm
{
    internal delegate ushort[] DirectiveParser(string[] args);
    internal class DirectiveType
    {
        internal string Name { get; init; }
        internal DirectiveParser Parser { get; init; }
    }
}
