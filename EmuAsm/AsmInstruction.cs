using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuAsm
{
    internal class AsmInstruction
    {
        internal InstructionType Type { get; init; }
        internal bool ForceIAFalse { get; init; }
        internal ushort[] Args { get; init; }
        internal byte Size { get => (byte)(Type.Args == 0 ?
            1 :
            Type.Args +
            (
                Args[0] > 255 || ForceIAFalse ? 1 : 0
            ));
        }
    }
}
