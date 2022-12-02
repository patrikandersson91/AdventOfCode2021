using System.Collections.Generic;

namespace Day03;

internal class Tasks
{
    private List<string[]> RawList => GetRawList();

    internal int Task1()
    {
        throw new NotImplementedException();
    }

    internal int Task2()
    {
        throw new NotImplementedException();
    }


    private List<string[]> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        var rows = File.ReadLines(filePath).ToList();

        List<string[]> result = new();
        foreach (var row in rows)
        {
            result.Add(row.Split(" "));
        }

        return result;
    }
}
