namespace Day11;

internal class Tasks
{
    internal int Task1()
    {
        return 0;
    }
    internal int Task2()
    {
        return 0;
    }

    private List<string> GetList()
    {
        var rows = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt")).ToList();
        return rows;
    }
}