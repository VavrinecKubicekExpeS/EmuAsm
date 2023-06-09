using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuAsm
{
    internal class Util
    {
        public static ushort ParseNum(string input) => Stringify(input.Take(2)) switch
        {
            "0x" => Convert.ToUInt16(Stringify(input.Skip(2)), 16),
            "0b" => Convert.ToUInt16(Stringify(input.Skip(2)), 2),
            _ => Convert.ToUInt16(input)
        };

        public static string Stringify(IEnumerable<char> src) => new(src.ToArray());
    }
}
