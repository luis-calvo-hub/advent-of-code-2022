public class Day1 {
    public Day1() {
        string input = File.ReadAllText("day1/input.txt").Replace("\r\n", "-").Replace("--", ",");
        string[] elves = input.Split(',');

        List<int> elfTotalCalories = new();
        for (int i = 0; i < elves.Length; i++) {
            string[] calories = elves[i].Split('-');
            int totalCalores = 0;
            for (int j = 0; j < calories.Length; j++) {
                totalCalores += int.Parse(calories[j]);
            }
            elfTotalCalories.Add(totalCalores);
        }
        elfTotalCalories.Sort();

        int totalLastThreeElves = 0;
        for (int i = elfTotalCalories.Count - 3; i < elfTotalCalories.Count; i++) {
            totalLastThreeElves += elfTotalCalories[i];
        }

        Console.WriteLine("Answer Day 1");
        Console.WriteLine($"Part 1: {elfTotalCalories[^1]}");
        Console.WriteLine($"Part 2: {totalLastThreeElves}");
    }
}