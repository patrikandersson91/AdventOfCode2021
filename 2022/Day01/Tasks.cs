namespace Day01;

internal class Tasks
{
    private List<int> rawList => GetRawList();

    internal int Task1()
    {
        throw new NotImplementedException();
    }

    internal int Task2()
    {
        throw new NotImplementedException();
    }

    private List<int> GetRawList()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
        return new(File.ReadAllText(filePath).Split("\r\n").Select(int.Parse).ToList());
    }
}
