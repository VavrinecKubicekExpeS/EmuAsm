using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuAsm
{
    internal class Identifier
    {
        internal string Name { get; init; }
        internal ushort Value { get; set; }
        internal bool IsBig { get => Value > 255; }
    }
}
