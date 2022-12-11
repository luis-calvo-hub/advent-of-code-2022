public class Day2 {
    public Day2(){
        string input = File.ReadAllText("day2/input.txt").Replace(" ", "").Replace("\r\n", ",");
        string[] matches = input.Split(',');

        Console.WriteLine("Solution Day 2");
        Console.WriteLine($"Part 1: {CalculateScore(matches, CalculateScorePart1)}");
        Console.WriteLine($"Part 2: {CalculateScore(matches, CalculateScorePart2)}");
    }

    private int CalculateScore(string[] matches, System.Func<string, int> method) {
        int totalScore = 0;
        for (int i = 0; i < matches.Length; i++) {
            int score = 0;
            score += method(matches[i]);
            totalScore += score;
        }
        return totalScore;
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
            _ => -1
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
            _ => -1
        };
    }
}