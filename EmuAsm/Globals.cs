using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmuAsm
{
    internal static class Globals
    {
        internal static HashSet<DirectiveType> Directives => new()
        {
            new()
            {
                Name="ins",
                Parser = (args) => new[]{Util.ParseNum(args[0]) }
            },
            new()
            {
                Name="dec",
                Parser = (args) =>
                {
                    Identifiers.Add(new()
                    {
                        Name = args[0],
                        Value = CurrentAddress
                    });
                    return new ushort[] { Util.ParseNum(args[1]) };
                }
            },
            new()
            {
                Name="let",
                Parser = (args) =>
                {
                    Identifiers.Add(new()
                    {
                        Name = args[0],
                        Value = Util.ParseNum(args[1])
                    });
                    return Array.Empty<ushort>();
                }
            },
            new()
            {
                Name=":",
                Parser = (args) =>
                {
                    Identifiers.Add(new()
                    {
                        Name = args[0],
                        Value = CurrentAddress
                    });
                    return Array.Empty<ushort>();
                }
            },
            new()
            {
                Name="org",
                Parser = (args) =>
                {
                    CurrentAddress = Util.ParseNum(args[0]);
                    return Array.Empty<ushort>();
                }
            }
        };
        internal static HashSet<InstructionType> Instructions => new()
        {
                new InstructionType{Name="nop",Opcode=0x0,Args=0},
new InstructionType{Name="mov",Opcode=0x8,Args=2},
new InstructionType{Name="lod",Opcode=0x9,Args=2},
new InstructionType{Name="add",Opcode=0x10,Args=0},
new InstructionType{Name="adi",Opcode=0x50,Args=1},
new InstructionType{Name="sub",Opcode=0x11,Args=0},
new InstructionType{Name="sbi",Opcode=0x51,Args=1},
new InstructionType{Name="not",Opcode=0x18,Args=0},
new InstructionType{Name="noi",Opcode=0x58,Args=1},
new InstructionType{Name="or",Opcode=0x19,Args=0},
new InstructionType{Name="ori",Opcode=0x59,Args=1},
new InstructionType{Name="and",Opcode=0x1a,Args=0},
new InstructionType{Name="ani",Opcode=0x5a,Args=1},
new InstructionType{Name="xor",Opcode=0x1b,Args=0},
new InstructionType{Name="xoi",Opcode=0x5b,Args=1},
new InstructionType{Name="shl",Opcode=0x20,Args=0},
new InstructionType{Name="shr",Opcode=0x21,Args=0},
new InstructionType{Name="rol",Opcode=0x22,Args=0},
new InstructionType{Name="ror",Opcode=0x23,Args=0},
new InstructionType{Name="inx",Opcode=0x28,Args=0},
new InstructionType{Name="dex",Opcode=0x29,Args=0},
new InstructionType{Name="jmp",Opcode=0x30,Args=1},
new InstructionType{Name="jpo",Opcode=0x31,Args=1},
new InstructionType{Name="jpz",Opcode=0x32,Args=1},
new InstructionType{Name="jno",Opcode=0x33,Args=1},
new InstructionType{Name="jnz",Opcode=0x34,Args=1},
new InstructionType{Name="rso",Opcode=0x38,Args=0},
new InstructionType{Name="rsz",Opcode=0x39,Args=0}
            };
        internal static HashSet<Identifier> Identifiers { get; set; } = new();
        internal static ushort[] Memory { get; set; } = new ushort[ushort.MaxValue];
        internal static ushort CurrentAddress { get; set; } = 6;
    }
}
