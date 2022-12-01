namespace Day02;

internal class Tasks
{
    private List<string> RawList => GetRawList();

    internal int Task1()
    {
        throw new NotImplementedException();
    }

    internal int Task2()
    {
        throw new NotImplementedException();
    }

    private List<string> GetRawList()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
        var rows = File.ReadAllText(filePath).Split("\r\n").ToList();

        // ReadAllLines
        // .Select(int.Parse)
        // Sum()

        return rows;
    }
}
