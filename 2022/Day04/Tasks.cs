namespace Day04;

internal class Tasks
{
    private List<string> RawList => GetRawList();

    internal int Task1()
    {
        var pairs = 0;

        foreach (var item in RawList)
        {
            var (range1, range2) = GetRange(item);
            if (!range1.Except(range2).Any() || !range2.Except(range1).Any()) { pairs++; }
        }

        return pairs;
    }

    internal int Task2()
    {
        var pairs = 0;

        foreach (var item in RawList)
        {
            var (range1, range2) = GetRange(item);
            if (range1.Any(range2.Contains) || range2.Any(range1.Contains)) { pairs++; }
        }

        return pairs;
    }

    private (List<int> range1, List<int> range2) GetRange(string item)
    {
        var x1 = int.Parse(item.Split(",")[0].Split("-")[0]);
        var x2 = int.Parse(item.Split(",")[0].Split("-")[1]);

        var y1 = int.Parse(item.Split(",")[1].Split("-")[0]);
        var y2 = int.Parse(item.Split(",")[1].Split("-")[1]);

        var range1 = Enumerable.Range(x1, x2 - x1 + 1).ToList();
        var range2 = Enumerable.Range(y1, y2 - y1 + 1).ToList();

        return (range1, range2);
    }

    private List<string> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        return File.ReadLines(filePath).ToList();
    }
}