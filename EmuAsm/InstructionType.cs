using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuAsm
{
    internal class InstructionType
    {
        internal string Name { get; init; }
        internal byte Opcode { get; init; }
        internal byte Args { get; init; }
    }
}
