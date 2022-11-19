namespace Day01;

internal class Tasks
{
    private List<int> rawList => GetRawList();

    internal int Task1()
    {
        foreach (var x in rawList)
        {
            foreach (var y in rawList)
            {
                if (x + y == 2020)
                {
                    return x * y;
                }
            }
        }

        throw new Exception("Could not find numbers.");
    }

    internal int Task2()
    {
        foreach (var x in rawList)
        {
            foreach (var y in rawList)
            {
                foreach (var z in rawList)
                {
                    if (x + y + z == 2020)
                    {
                        return x * y * z;
                    }
                }
            }
        }

        throw new Exception("Could not find numbers.");
    }

    private List<int> GetRawList()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
        return new(File.ReadAllText(filePath).Split("\r\n").Select(int.Parse).ToList());
    }
}
