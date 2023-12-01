namespace Day02;

internal class Tasks
{
    private List<string> RawList => GetRawList();

    internal int Task1()
    {
        return -1;
    }

    internal int Task2()
    {
        return -1;
    }

    private List<string> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        return File.ReadAllText(filePath).Split("\r\n").ToList();
    }
}
