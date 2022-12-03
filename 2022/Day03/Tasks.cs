namespace Day03;

internal class Tasks
{
    private List<string> RawList => GetRawList();

    internal int Task1()
    {
        var sum = 0;
        foreach (var row in RawList)
        {
            var p1 = row[..(row.Length / 2)];
            var p2 = row.Substring(row.Length / 2, row.Length / 2);

            var letter = p1.Intersect(p2).First();
            sum += GetPriority(letter);
        }
        return sum;
    }

    internal int Task2()
    {
        var sum = 0;
        foreach (var chunk in RawList.Chunk(3).ToList())
        {
            var letter = chunk[0].Intersect(chunk[1]).Intersect(chunk[2]).First();
            sum += GetPriority(letter);
        }
        return sum;
    }

    internal int GetPriority(char c)
    {
        int i = c;
        if (char.IsLower(c)) return i - 96;
        return i - 38;
    }

    private List<string> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        return File.ReadLines(filePath).ToList();
    }
}