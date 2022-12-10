public class Day4
{
    public Day4() {
        string input = File.ReadAllText("day4/input.txt").Replace(",", ".").Replace("\r\n", ",");
        string[] assignments = input.Split(",");
        List<ElfTaskPair> tasks = new();

        foreach (string a in assignments) {
            string[] elfPair = a.Split(".");
            string[] elf1 = elfPair[0].Split("-");
            string[] elf2 = elfPair[1].Split("-");
            ElfTaskPair pair = new() {
                elf1First = int.Parse(elf1[0]),
                elf1Last = int.Parse(elf1[1]),
                elf2First = int.Parse(elf2[0]),
                elf2Last = int.Parse(elf2[1]),
            };
            tasks.Add(pair);
        }
        
        int fullyContainedAssignments = 0;
        foreach (ElfTaskPair p in tasks) {
            if(p.elf1First <= p.elf2First && p.elf1Last >= p.elf2Last) {
                fullyContainedAssignments++;
            }
            else if(p.elf2First <= p.elf1First && p.elf2Last >= p.elf1Last) {
                fullyContainedAssignments++;
            }
        }

        int overlaps = 0;
        foreach (ElfTaskPair p in tasks) {
            if(p.elf1First <= p.elf2First && p.elf1Last >= p.elf2First) {
                overlaps++;
            }
            else if(p.elf2First <= p.elf1First && p.elf2Last >= p.elf1First) {
                overlaps++;
            }
        }
        
        Console.WriteLine("Solution Day 4");
        Console.WriteLine($"Part 1: {fullyContainedAssignments}");
        Console.WriteLine($"Part 2: {overlaps}");
    }

    private struct ElfTaskPair {
        public int elf1First;
        public int elf1Last;
        public int elf2First;
        public int elf2Last;
    }
}