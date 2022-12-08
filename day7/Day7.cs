public class Day7 {
    public Day7() {
        string input = System.IO.File.ReadAllText("day7/input.txt");
        string[] inputLines = input.Split("\r\n");

        List<Dir> directoriesCache = new();

        Dir cd = new();
        cd.name = "root";
        Dir root = cd;
        foreach(string command in inputLines) {
            if(command.Equals("$ cd ..") && cd.parent != null) {
                cd = cd.parent;
            }
            else if(command.Contains("$ cd") && !command.Equals("$ cd /")) {
                for (int i = 0; i < cd.dirs.Count; i++) {
                    if(command.Substring(5).Contains(cd.dirs[i].name)){
                        cd = cd.dirs[i];
                        break;
                    }
                }
            }
            else if(command.Contains("dir")) {
                Dir d = new Dir();
                d.parent = cd;
                d.name = command.Substring(4);
                cd.dirs.Add(d);
                directoriesCache.Add(d);
            }
            else if(Char.IsDigit(command[0])) {
                string fileSize = string.Empty;
                int i = 0;
                while (Char.IsDigit(command[i])) {
                    fileSize += command[i];
                    i++; 
                }
                File f = new() {
                    size = int.Parse(fileSize)
                };
                cd.files.Add(f);
                cd.size += f.size;

                Dir parent = cd;
                while(parent.parent != null) {
                    parent = parent.parent;
                    parent.size += f.size;
                }
            }
        }

        int answer1 = 0;
        foreach(Dir d in directoriesCache) {
            if(d.size < 100000) {
                answer1 += d.size;
            }
        }

        Dir answer2 = root;
        int requiredSpace = 30000000 - (70000000 - root.size);
        foreach(Dir d in directoriesCache) {
            if(d.size < answer2.size && d.size > requiredSpace) {
                answer2 = d;
            }
        }
        
        Console.WriteLine($"Solution Day 7");
        Console.WriteLine($"Part 1: {answer1}");
        Console.WriteLine($"Part 2: {answer2.size}");
    }

    private class Dir {
        public string name = string.Empty; 
        public Dir? parent;
        public List<Dir> dirs = new();
        public List<File> files = new();
        public int size;
    }
    private class File {
        public int size;
    }
}