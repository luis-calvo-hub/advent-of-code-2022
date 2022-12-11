public class Day8 {
    public Day8() {
        string input = File.ReadAllText("day8/input.txt").Replace("\r\n", ",");

        int[,] map = CreateMap(input);
        int visibleTreeCount = CalculateVisibleTrees(map);
        int highestScenicTreeScore = CalculateHighestScenicTreeScore(map);
        Console.WriteLine($"Solution Day 8");
        Console.WriteLine($"Part 1: {visibleTreeCount}");
        Console.WriteLine($"Part 2: {highestScenicTreeScore}");
    }

    private int CalculateVisibleTrees(int [,] map) {
        int visibleTreeCount = 0;
        for (int y = 0; y < map.GetLength(1); y++) {
            for (int x = 0; x <  map.GetLength(0); x++) {
                if(x == 0 || x == map.GetLength(0) - 1) {
                    visibleTreeCount++;
                }
                else if(y == 0 || y == map.GetLength(1) - 1) {
                    visibleTreeCount++;
                }
                else {
                    // Look Left
                    bool tallerTreeFound = false;
                    for(int i = 0; i < x; i++) {
                        if(map[x, y] <= map[i, y]) {
                            tallerTreeFound = true;
                        }
                    }
                    if(!tallerTreeFound) {
                        visibleTreeCount++;
                    }
                    else {
                        tallerTreeFound = false;
                        // Look Right
                        for(int i = x + 1; i < map.GetLength(0); i++) {
                            if(map[x, y] <= map[i, y]) {
                                tallerTreeFound = true;
                            }
                        }
                        if(!tallerTreeFound) {
                            visibleTreeCount++;
                        }
                        else {
                            tallerTreeFound = false;
                            // Look Top
                            for(int i = 0; i < y; i++) {
                                if(map[x, y] <= map[x, i]) {
                                    tallerTreeFound = true;
                                }
                            }
                            if(!tallerTreeFound) {
                                visibleTreeCount++;
                            }
                            else {
                                tallerTreeFound = false;
                                // Look Bottom
                                for(int i = y + 1; i < map.GetLength(1); i++) {
                                    if(map[x, y] <= map[x, i]) {
                                        tallerTreeFound = true;
                                    }
                                }
                                if(!tallerTreeFound) {
                                    visibleTreeCount++;
                                }
                            }
                        }
                    }
                }
            }
        }
        return visibleTreeCount;
    }

    private int CalculateHighestScenicTreeScore(int [,] map) {
        int highestScore = 0;
        for (int y = 0; y < map.GetLength(1); y++) {
            for (int x = 0; x <  map.GetLength(0); x++) {
                int treeScore = 1;
                int directionScore = 0;
                int i = 1;
                while (x - i >= 0) {
                    directionScore++;
                    if (map[x, y] <= map[x - i, y]) {
                        break;
                    }
                    i++;
                }
                if(directionScore > 1) {
                    treeScore *= directionScore;
                }
                directionScore = 0;
                i = 1;
                while (x + i < map.GetLength(0)) {
                    directionScore++;
                    if (map[x, y] <= map[x + i, y]) {
                        break;
                    }
                    i++;
                }
                if(directionScore > 1) {
                    treeScore *= directionScore;
                }
                directionScore = 0;
                i = 1;
                while (y - i >= 0) {
                    directionScore++;
                    if (map[x, y] <= map[x, y - i]) {
                        break;
                    }
                    i++;
                }
                if(directionScore > 1) {
                    treeScore *= directionScore;
                }
                directionScore = 0;
                i = 1;
                while (y + i < map.GetLength(1)) {
                    directionScore++;
                    if (map[x, y] <= map[x, y + i]) {
                        break;
                    }
                    i++;
                }
                if(directionScore > 1) {
                    treeScore *= directionScore;
                }
                
                if(treeScore > highestScore) {
                    highestScore = treeScore;
                }
            }
        }
        return highestScore;
    }

    private int[,] CreateMap(string input) {
        Vector2 size = CalculateMapSize(input);
        int[,] map = new int[size.x, size.y];
        Vector2 pos = new();
        for(int i = 0; i < input.Length; i++) {
            if(input[i].Equals(',')) {
                pos.y++;
                pos.x = 0;
            }
            else {
                map.SetValue(input[i] - '0', pos.x, pos.y);
                pos.x++;
            }
        }
        return map;
    }

    private Vector2 CalculateMapSize(string input) {
        Vector2 size = new();
        for(int i = 0; i < input.Length; i++) {
            if(input[i].Equals(',')) {
                if(size.x == 0) size.x = i;
                size.y++;
            }
        }
        size.y += 1;
        return size;
    }

    private struct Vector2 {
        public int x;
        public int y;
    }
}