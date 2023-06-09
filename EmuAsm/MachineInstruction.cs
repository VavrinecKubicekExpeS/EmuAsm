using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuAsm
{
    internal class MachineInstruction
    {
        internal AsmInstruction BaseInstruction { get; init; }
        internal ushort[] Code
        { 
            get
            {
                byte opcode = BaseInstruction.Type.Opcode;
                bool ia = BaseInstruction.Args.Any() && BaseInstruction.Args[0] < 256 && !BaseInstruction.ForceIAFalse;
                ushort[] args = BaseInstruction.Args;

                ushort[] result = new ushort[BaseInstruction.Size];
                result[0] = (ushort)((ia ? 0b1000000000000000 : 0) | opcode << 8 | (ia ? args[0] : 0));
                for(int i = 1; i < BaseInstruction.Size; i++)
                {
                    result[i] = args[i - (ia ? 0 : 1)];
                }

                return result;
            }
        }
    }
}
