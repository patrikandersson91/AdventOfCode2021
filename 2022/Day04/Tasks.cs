namespace Day04;

internal class Tasks
{
    private List<string> RawList => GetRawList();

    internal int Task1()
    {
        var pairs = 0;

        foreach (var item in RawList)
        {
            var elf1From = int.Parse(item.Split(",")[0].Split("-")[0]);
            var elf1To = int.Parse(item.Split(",")[0].Split("-")[1]);

            var elf2From = int.Parse(item.Split(",")[1].Split("-")[0]);
            var elf2To = int.Parse(item.Split(",")[1].Split("-")[1]);

            var range1 = Enumerable.Range(elf1From, elf1To - elf1From + 1).ToList();
            var range2 = Enumerable.Range(elf2From, elf2To - elf2From + 1).ToList();

            if (!range1.Except(range2).Any() || !range2.Except(range1).Any())
            {
                pairs++; continue;
            }
        }

        return pairs;
    }

    internal int Task2()
    {
        var pairs = 0;

        foreach (var item in RawList)
        {
            var elf1From = int.Parse(item.Split(",")[0].Split("-")[0]);
            var elf1To = int.Parse(item.Split(",")[0].Split("-")[1]);

            var elf2From = int.Parse(item.Split(",")[1].Split("-")[0]);
            var elf2To = int.Parse(item.Split(",")[1].Split("-")[1]);

            var range1 = Enumerable.Range(elf1From, elf1To - elf1From + 1).ToList();
            var range2 = Enumerable.Range(elf2From, elf2To - elf2From + 1).ToList();

            if (range1.Any(range2.Contains) || range2.Any(range1.Contains))
            {
                pairs++; continue;
            }
        }

        return pairs;
    }

    private List<string> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        return File.ReadLines(filePath).ToList();
    }
}