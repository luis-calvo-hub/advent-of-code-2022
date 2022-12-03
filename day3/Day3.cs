public class Day3 {
    public Day3() {
        string input = File.ReadAllText("day3/input.txt").Replace("\r\n", ",");
        string[] rucksacks = input.Split(',');

        List<string[]> rucksacksGroups = new();
        string[] group = new string[3];

        int totalPriority = 0;
        for(int i = 0; i < rucksacks.Length; i++) {
            string compartment1 = rucksacks[i].Substring(0, rucksacks[i].Length / 2);
            string compartment2 = rucksacks[i].Substring(rucksacks[i].Length / 2, rucksacks[i].Length / 2);
            char common = CommonChar(compartment1, compartment2);
            totalPriority += Priority(common);
            
            group[i % 3] = rucksacks[i];
            if(i % 3 == 2) {
                rucksacksGroups.Add(group);
                group = new string[3];
            }
        }

        int totalGroupPriority = 0;
        foreach (string[] g in rucksacksGroups) {
            totalGroupPriority += Priority(CommonGroupChar(g));
        }
 
        Console.WriteLine("Answer Day 3");
        Console.WriteLine($"Part 1: {totalPriority}");
        Console.WriteLine($"Part 1: {totalGroupPriority}");
    }

    private char CommonChar(string a, string b) {
        foreach(char c in a) {
            if(b.Contains(c)) {
                return c;
            }
        }
        return '_';
    }

    private char CommonGroupChar(string[] group) {
        foreach (char c in group[0]) {
            if (group[1].Contains(c) & group[2].Contains(c)) {
                return c;
            }
        }
        return '_';
    }

    private int Priority(char c) {
        if (char.IsUpper(c)) return (int)(c) - 38;
        else return (int)(c) - 96;
    }
}