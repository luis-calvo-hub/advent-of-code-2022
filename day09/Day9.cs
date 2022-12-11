public class Day9 {
    public Day9() {
        string input = File.ReadAllText("day9/input.txt").Replace("\r\n", ",").Replace(" ", "");
        List<MoveCommand> commands = ParseCommands(input);

        Console.WriteLine($"Solution Day 9");
        Console.WriteLine($"Part 1: {SimulateTailVisits(commands, 2)}");
        Console.WriteLine($"Part 2: {SimulateTailVisits(commands, 10)}");
    }

    private int SimulateTailVisits(List<MoveCommand> commands, int ropeLength) {
        List<Vector2> rope = new(ropeLength);
        for (int i = 0; i < rope.Capacity; i++) {
            rope.Add(new Vector2());
        }
        
        List<Vector2> tailVisitedPositions = new();

        foreach(MoveCommand c in commands) {
            int moves = c.moves;
            for(int i = 0; i < moves; i++) {
                for(int r = 0; r < rope.Count; r++) {
                    // head
                    if(r == 0) {
                        rope[r] += c.direction;
                    }
                    // rest
                    else {
                        Vector2 distance = new() {
                            x = rope[r - 1].x - rope[r].x,
                            y = rope[r - 1].y - rope[r].y,
                        };
                        if (Math.Abs(distance.x) > 1 || Math.Abs(distance.y) > 1) {
                            Vector2 newPos = new() {
                                x = Math.Sign(distance.x),
                                y = Math.Sign(distance.y)
                            };
                            rope[r] += newPos;
                        }

                        // tail
                        if(r == ropeLength -1 && !tailVisitedPositions.Contains(rope[r]) ) {
                            tailVisitedPositions.Add(rope[r]);
                        }
                    }
                }
            }
        }
        return tailVisitedPositions.Count;
    }

    private List<MoveCommand> ParseCommands(string input) {
        List<MoveCommand> commands = new();
        string[] jaggedInputs = input.Split(',');
        foreach(string s in jaggedInputs) {
            commands.Add(MoveCommand.Parse(s));
        }
        return commands;
    }

    private struct MoveCommand {
        public Vector2 direction;
        public int moves;

        public static MoveCommand Parse(string s) {
            MoveCommand command = new();
            Vector2 direction = new();
            string movesStr = string.Empty;
            int moves = 0;
            foreach(char c in s) {
                if(!char.IsDigit(c)) {
                    direction = Direction(c);
                }
                else {
                    movesStr += c;
                }
            }
            moves = int.Parse(movesStr);
            command.direction = direction;
            command.moves = moves;
            return command;
        }
        private static Vector2 Direction(char d) {
            return d switch {
                'L' => new Vector2(-1, 0),
                'R' => new Vector2(1, 0),
                'D' => new Vector2(0, -1),
                'U' => new Vector2(0, 1),
                _ => new Vector2()
            };
        }
    }

    private struct Vector2 {
        public int x;
        public int y;
        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }
        public static Vector2 operator +(Vector2 a, Vector2 b) {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
    }
}