public class Day6 {
    public Day6() {
        string input = File.ReadAllText("day6/input.txt");

        Console.WriteLine($"Solution Day 6");
        Console.WriteLine($"Part 1: {CharactersProcessedForMaker(input, 4)}");
        Console.WriteLine($"Part 2: {CharactersProcessedForMaker(input, 14)}");
    }

    private int CharactersProcessedForMaker(string input, int length) {
        string marker = string.Empty;
        for (int i = 0; i < input.Length; i++) {
            if(marker.Contains(input[i])) {
                i -= marker.Length - 1;
                marker = string.Empty;
                marker += input[i];
            }
            else {
                marker += input[i];
                if(marker.Length == length) {
                    return i + 1;
                }
            }
        }
        return 0;
    }
}