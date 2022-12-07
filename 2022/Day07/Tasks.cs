using System.Text.RegularExpressions;

namespace Day07;

internal class Tasks
{
    internal int Task1()
    {
        return GetLevels().Where(x => x.Size < 100000).Sum(x => x.Size);
    }
    internal int Task2()
    {
        var levels = GetLevels();

        var usedSpace = 70000000 - levels.First().Size;
        foreach (var item in levels.OrderBy(x => x.Size))
        {
            if (usedSpace + item.Size >= 30000000) { return item.Size; }
        }

        throw new Exception("Could not find folder.");
    }

    private List<string> RawText => File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt")).ToList();
    private List<Level> GetLevels()
    {
        List<Level> levels = new();
        string path = string.Empty;

        foreach (var item in RawText)
        {
            if (item.Contains("$ ls") || item.Contains("dir ")) { continue; }
            else if (item.Contains("$ cd .."))
            {
                var newPath = Regex.Replace(path, @"/[a-z]*/$", "/");
                if (path.Contains(newPath))
                {
                    levels.First(x => x.Path == newPath).Size += levels.First(x => x.Path == path).Size;
                }
                path = newPath;
                continue;
            }
            else if (item.Contains("$ cd "))
            {
                path += string.IsNullOrEmpty(path) ? "/" : item.Split(" ")[2] + "/";
                levels.Add(new Level { Path = path, Size = 0 });
                continue;
            }

            if (levels.Any(x => x.Path == path))
            {
                levels.First(x => x.Path == path).Size += Convert.ToInt32(item.Split(" ")[0]);
            }
        }

        var c = path.Count(x => x == '/');
        for (int i = 1; i < c; i++)
        {
            var newPath = Regex.Replace(path, @"/[a-z]*/$", "/");
            if (path.Contains(newPath))
            {
                levels.First(x => x.Path == newPath).Size += levels.First(x => x.Path == path).Size;
            }
            path = newPath;
        }

        return levels;
    }
    private class Level
    {
        public required string Path { get; set; }
        public int Size { get; set; }
    }
}