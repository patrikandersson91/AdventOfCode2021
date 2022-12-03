namespace Day04;

internal class Tasks
{
    private List<string> RawList => GetRawList();

    internal int Task1()
    {
        return 0;
    }

    internal int Task2()
    {
        return 0;
    }

    private List<string> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        return File.ReadLines(filePath).ToList();
    }
}