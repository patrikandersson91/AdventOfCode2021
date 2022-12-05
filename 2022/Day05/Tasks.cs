using System.Text.RegularExpressions;

namespace Day05;

internal class Tasks
{
    internal string Task1()
    {
        var containers = Containers();
        var digits = @"(\d+) from (\d+) to (\d+)";
        foreach (var instruction in Instructions)
        {
            var match = Regex.Match(instruction, digits);
            var count = int.Parse(match.Groups[1].ToString());
            var from = int.Parse(match.Groups[2].ToString()) - 1;
            var to = int.Parse(match.Groups[3].ToString()) - 1;

            for (int i = 0; i < count; i++)
            {
                if (containers[from].Count == 0) { break; }
                containers[to].Insert(0, containers[from].First());
                containers[from].RemoveAt(0);
            }
        }

        return Result(containers);
    }
    internal string Task2()
    {
        var containers = Containers();
        var digit = @"(\d+) from (\d+) to (\d+)";
        foreach (var line in Instructions)
        {
            var match = Regex.Match(line, digit);
            var count = int.Parse(match.Groups[1].ToString());
            var from = int.Parse(match.Groups[2].ToString()) - 1;
            var to = int.Parse(match.Groups[3].ToString()) - 1;

            if (containers[from].Count == 0) { break; }
            containers[to].InsertRange(0, containers[from].Take(count));
            containers[from].RemoveRange(0, count);
        }

        return Result(containers);
    }

    private string Result(List<List<char>> containers)
    {
        var result = "";
        foreach (var c in containers) { result += c.First(); }
        return result;
    }
    private List<List<char>> Containers()
    {
        var rows = RawText.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)[0].Split("\r\n").ToList();
        var containers = new List<List<char>>();

        foreach (var item in rows)
        {
            var count = 0;
            foreach (var column in item.Chunk(4))
            {
                var match = Regex.Match(new string(column), @"[a-zA-Z]");
                if (match.Success)
                {
                    if (containers.Count <= count) { containers.Add(new List<char> { char.Parse(match.Value) }); }
                    else { containers[count].Add(char.Parse(match.Value)); }
                }
                else if (containers.Count <= count) { containers.Add(new List<char>()); }
                count++;
            }
        }

        return containers;
    }
    private List<string> Instructions => RawText.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)[1].Split("\r\n").ToList();
    private string RawText => File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));
}
