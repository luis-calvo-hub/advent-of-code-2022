public class Day1 {
    public Day1() {
        string input = File.ReadAllText("day1/input.txt").Replace("\r\n", "-").Replace("--", ",");
        string[] elves = input.Split(',');

        List<int> elfCalories = new();
        for (int i = 0; i < elves.Length; i++) {
            string[] totalCalories = elves[i].Split('-');
            int calories = 0;
            for (int j = 0; j < totalCalories.Length; j++) {
                calories += int.Parse(totalCalories[j]);
            }
            elfCalories.Add(calories);
        }
        elfCalories.Sort();

        int totalLastThreeElves = 0;
        for (int i = elfCalories.Count - 3; i < elfCalories.Count; i++) {
            totalLastThreeElves += elfCalories[i];
        }

        Console.WriteLine("Solution Day 1");
        Console.WriteLine($"Part 1: {elfCalories[^1]}");
        Console.WriteLine($"Part 2: {totalLastThreeElves}");
    }
}