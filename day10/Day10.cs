public class Day10 {
    public Day10() {
        string[] input = File.ReadAllText("day10/input.txt").Split("\r\n");
        List<Instruction> instructions = CreateInstructions(input);
        
        Console.WriteLine($"Solution Day 10");
        Console.WriteLine($"Part 1: {SolvePart1(instructions)}");
        Console.WriteLine($"Part 2:");
        DrawPart2(instructions);
    }
    private int? ProcessInstruction(Instruction i) {
        if(i.type.Equals("addx")) {
            return i.value;
        }
        return null;
    }

    private List<Instruction> CreateInstructions(string[] input) {
        List<Instruction> list = new(input.Length);
        foreach(string s in input) {
            list.Add(Instruction.Parse(s));
        }
        return list;
    }

    private int SolvePart1(List<Instruction> instructions) {
        int cycle = 1;
        int register = 1;
        int totaslSingalStrength = 0;
        for (int i = 0; i < instructions.Count; i++) {
            int? result = ProcessInstruction(instructions[i]);
            if(result != null) {
                if(IsAmplified(cycle)) {
                    totaslSingalStrength += cycle * register;
                }
                cycle++;
                if(IsAmplified(cycle)) {
                    totaslSingalStrength += cycle * register;
                }
                register += result.Value;
                cycle++;
            }
            else {
                if(IsAmplified(cycle)) {
                    totaslSingalStrength += cycle * register;
                }
                cycle++;
            }
        }
        return totaslSingalStrength;
    }

    private bool IsAmplified(int cycle) {
        if(cycle == 20 || (cycle + 20) % 40 == 0) {
            return true;
        }
        else {
            return false;
        }
    }

    private void DrawPart2(List<Instruction> instructions) {
        int cycle = 1;
        int register = 1;
        List<char> frameBuffer = new();
        for (int i = 0; i < instructions.Count; i++) {
            int? result = ProcessInstruction(instructions[i]);
            if(result != null) {
                cycle += 2;
                frameBuffer.Add(Draw(frameBuffer.Count, register));
                frameBuffer.Add(Draw(frameBuffer.Count, register));
                int num = result.Value;
                register += num;
            }
            else {
                cycle++;
                frameBuffer.Add(Draw(frameBuffer.Count, register));
            }
        }
        DrawFrameBuffer(frameBuffer);
    }

    private void DrawFrameBuffer(List<char> frameBuffer) {
        for (int i = 0; i < frameBuffer.Count; i++) {
            if (i != 0 && i % 40 == 0) {
                Console.WriteLine();
            }
            Console.Write(frameBuffer[i]);
        }
    }

    private char Draw(int fragmentPos, int register) {
        if (fragmentPos % 40 == register - 1 ||
            fragmentPos % 40 == register + 1 ||
            fragmentPos % 40 == register) {
            return '#';
        }
        else {
            return '.';
        }
    }

    private struct Instruction {
        public string type;
        public int value;
        public static Instruction Parse(string s) {
            Instruction instruction = new();
            instruction.type = $"{s[0]}{s[1]}{s[2]}{s[3]}";
            string valueStr = string.Empty;
            if(s.Length > 4) {
                for (int i = 5; i < s.Length; i++) {
                    valueStr += s[i];
                }
                instruction.value = int.Parse(valueStr);
            }
            return instruction;
        }
    }
}