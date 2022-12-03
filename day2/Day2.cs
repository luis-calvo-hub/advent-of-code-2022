public class Day2 {
    public Day2(){
        string input = File.ReadAllText("day2/input.txt").Replace(" ", "").Replace("\r\n", ",");
        string[] matches = input.Split(',');

        int totalScorePart1 = 0;
        for (int i = 0; i < matches.Length; i++) {
            int score = 0;
            score += CalculateScorePart1(matches[i]);
            totalScorePart1 += score;
        }

        int totalScorePart2 = 0;
        for (int i = 0; i < matches.Length; i++) {
            int score = 0;
            score += CalculateScorePart2(matches[i]);
            totalScorePart2 += score;
        }

        Console.WriteLine("Answer Day 2");
        Console.WriteLine($"Part 1: {totalScorePart1}");
        Console.WriteLine($"Part 2: {totalScorePart2}");
    }

    private int CalculateScorePart1(string s) {
        return s switch {
            "AX" => 1 + 3,
            "AY" => 2 + 6,
            "AZ" => 3 + 0,
            "BX" => 1 + 0,
            "BY" => 2 + 3,
            "BZ" => 3 + 6,
            "CX" => 1 + 6,
            "CY" => 2 + 0,
            "CZ" => 3 + 3,
            _ => 0
        };
    }
    private int CalculateScorePart2(string s) {
        return s switch {
            "AX" => 3 + 0,
            "AY" => 1 + 3,
            "AZ" => 2 + 6,
            "BX" => 1 + 0,
            "BY" => 2 + 3,
            "BZ" => 3 + 6,
            "CX" => 2 + 0,
            "CY" => 3 + 3,
            "CZ" => 1 + 6,
            _ => 0
        };
    }
}   