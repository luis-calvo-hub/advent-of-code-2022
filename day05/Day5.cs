public class Day05 {
    public Day05() {
        string input = File.ReadAllText("day5/input.txt");
        List<char> inputCrates = new();
        bool cratesParsed = false;
        bool columnsParsed = false;
        int columns = 0;
        MoveCommand command = new();
        List<MoveCommand> commands = new();
        for (int i = 0; i < input.Length; i++) {
            if (input[i].Equals('m') && input[i + 1].Equals('o') && input[i + 2].Equals('v') && input[i + 3].Equals('e')) {
                columnsParsed = true;
                if (Char.IsDigit(input[i + 5])) {
                    if (Char.IsDigit(input[i + 5]) && Char.IsDigit(input[i + 6])) {
                        command.amount = int.Parse((input[i + 5]) + (input[i + 6]).ToString());
                    }
                    else {
                        command.amount = int.Parse((input[i + 5]).ToString());
                    }
                }
            }
            else if (input[i].Equals('f') && input[i + 1].Equals('r') && input[i + 2].Equals('o') && input[i + 3].Equals('m')) {
                command.from = int.Parse((input[i + 5]).ToString());
                command.to = int.Parse((input[i + 10]).ToString());
                commands.Add(command);
            }
            if (!columnsParsed) {
                if (Char.IsDigit(input[i])) {
                    cratesParsed = true;
                    columns++;
                }
                if (!cratesParsed) {
                    if (input[i].Equals(' ') && input[i + 1].Equals(' ') && input[i + 2].Equals(' ') && input[i + 3].Equals(' ')){
                        inputCrates.Add('x');
                        i += 3;
                    }
                    else if (input[i].Equals('[')) {
                        inputCrates.Add(input[i + 1]);
                    }
                }
            }
        }

        List<List<char>> cratesSolution1 = GetCrateList(columns, inputCrates);
        foreach (MoveCommand c in commands) {
            for (int i = 0; i < c.amount; i++) {
                List<char> column = cratesSolution1[c.from - 1];
                char crate = column[column.Count - 1]; 
                column.RemoveAt(column.Count - 1);
                cratesSolution1[c.to - 1].Add(crate);
            }
        }
       
        string solutionPart1 = string.Empty;
        foreach (List<char> list in cratesSolution1) {
            solutionPart1 += list[list.Count - 1];
        }

        List<List<char>> cratesSolution2 = GetCrateList(columns, inputCrates);
        foreach (MoveCommand c in commands) {
            for (int i = 0; i < c.amount; i++) {
                List<char> column = cratesSolution2[c.from - 1];
                char crate = column[column.Count - c.amount + i]; 
                column.RemoveAt(column.Count - c.amount + i);
                cratesSolution2[c.to - 1].Add(crate);
            }
        }

        string solutionPart2 = string.Empty;
        foreach (List<char> list in cratesSolution2) {
            solutionPart2 += list[list.Count - 1];
        }

        Console.WriteLine("Solution Day 5");
        Console.WriteLine($"Part 1: {solutionPart1}");
        Console.WriteLine($"Part 2: {solutionPart2}");
    }

    private List<List<char>> GetCrateList(int columns, List<char> inputCrates) {
        List<List<char>> crates = new();
        for (int i = 0; i < columns; i++) {
            crates.Add(new List<char>());
        }
        for (int i = 0; i < inputCrates.Count; i++) {
            crates[i % columns].Add(inputCrates[i]);
        }
        for (int i = 0; i < crates.Count; i++) {
            int inverseI = crates.Count - i - 1;
            for (int j = 0; j < crates[i].Count; j++) {
                int inverseJ = crates[i].Count - j - 1;
                if(crates[inverseI][inverseJ].Equals('x')) {
                    crates[inverseI].Remove('x');
                }
            }
        }
        foreach (List<char> list in crates) {
            list.Reverse();
        }
        return crates;
    }

    private struct MoveCommand {
        public int amount;
        public int from;
        public int to;
    }
}