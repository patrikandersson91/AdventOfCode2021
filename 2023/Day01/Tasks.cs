namespace Day01;

internal class Tasks
{
    private List<int> RawList => GetRawList();

    internal int Task1()
    {
        return RawList.Sum();
    }

    internal int Task2()
    {
        return RawList.Sum();
    }

    private List<int> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        var groups = File.ReadAllText(filePath).Split("\r\n\r\n").ToList();

        List<int> sizes = new();
        foreach (var item in groups)
        {
            sizes.Add(item.Split("\r\n").Select(int.Parse).Sum());
        }

        return sizes;
    }
}
