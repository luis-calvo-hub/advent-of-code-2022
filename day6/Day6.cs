public class Day6 {
    public Day6() {
        string input = File.ReadAllText("day6/input.txt");

        Console.WriteLine($"Solution Day 6");
        Console.WriteLine($"Part 1: {LookForCombination(input, 4)}");
        Console.WriteLine($"Part 2: {LookForCombination(input, 14)}");
    }

    private int LookForCombination(string input, int length) {
        string combination = string.Empty;
        for (int i = 0; i < input.Length; i++) {
            if(combination.Contains(input[i])) {
                i -= combination.Length - 1;
                combination = string.Empty;
                combination += input[i];
            }
            else {
                combination += input[i];
                if(combination.Length == length) {
                    return i + 1;
                }
            }
        }
        return 0;
    }
}