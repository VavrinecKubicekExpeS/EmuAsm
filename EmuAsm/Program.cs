using EmuAsm;
using System.Text.Json;

var assemblyLines = File.ReadAllLines(args[0])
    .Select(line => 
        line.Trim()
        .Replace(" a", " 0")
        .Replace(" b", " 1")
        .Replace(" s", " 2")
        .Replace(" c", " 3")
        .Replace(" d", " 5")
        .Replace(" x", " 6"))
    .ToArray();

foreach(string line in assemblyLines)
{
    var newMemory = Globals.Directives.Any(dir => line.StartsWith(dir.Name)) ?
        Globals.Directives.Where(dir => line.StartsWith(dir.Name)).Single().Parser(line.Split(' ').Skip(1).ToArray()) :
        new MachineInstruction
        {
            // god what have i created
            BaseInstruction = ((Func<AsmInstruction>)(() =>
            {
                bool forceBig = false;
                return new AsmInstruction
                {
                    Type = Globals.Instructions.Where(type => type.Name == line.Split(' ')[0]).Single(),
                    Args = line.Split(' ').Skip(1).Select((item, index) =>
                    {
                        try { return Util.ParseNum(item); }
                        catch
                        {
                            forceBig = index == 0;
                            return (ushort)(Globals.Identifiers.Single(id => id.Name == item).Value);
                        }
                    }).ToArray(),
                    ForceIAFalse = forceBig
                };
            }))()
        }.Code;
    for(int i = 0; i < newMemory.Length; i++)
    {
        Globals.Memory[i + Globals.CurrentAddress] = newMemory[i];
    }
    Globals.CurrentAddress += (ushort)newMemory.Length;
}

JSONMemory mem = new JSONMemory
{
    memory = Globals.Memory.Select((value, index) => new Cell { address = index, data = value }).Take(Globals.CurrentAddress + 1).ToArray()
};

var json = JsonSerializer.Serialize(mem);

File.WriteAllText(args[1], json);

Console.WriteLine(); //FOR BREAKPOINT