namespace Day01;

internal class Tasks
{
    private List<int> RawList => GetRawList();

    internal int Task1()
    {
        return RawList.Max();
    }

    internal int Task2()
    {
        return RawList.OrderByDescending(x=>x).Take(3).Sum();
    }

    private List<int> GetRawList()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
        var groups = File.ReadAllText(filePath).Split("\r\n\r\n").ToList();

        var sizes = new List<int>();
        foreach (var item in groups)
        {
            sizes.Add(item.Split("\r\n").Select(int.Parse).Sum());
        }

        return sizes;
    }
}
