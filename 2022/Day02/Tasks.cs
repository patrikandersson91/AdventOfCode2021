using System.Collections.Generic;

namespace Day02;

internal class Tasks
{
    private List<string[]> RawList => GetRawList();

    internal int Task1()
    {
        return Calculate(RawList);
    }

    internal int Task2()
    {
        return Calculate(Reorganize(RawList));
    }

    private List<string[]> Reorganize(List<string[]> list) 
    {
        List<string[]> newList = new();
        foreach (var item in list)
        {
            if (item[1] == "X") // lose
            {
                if (item[0] == "A") { item[1] = "Z"; }
                else if (item[0] == "B") { item[1] = "X"; }
                else if (item[0] == "C") { item[1] = "Y"; }
            }
            else if (item[1] == "Y") // draw
            {
                if (item[0] == "A") { item[1] = "X"; }
                else if (item[0] == "B") { item[1] = "Y"; }
                else if (item[0] == "C") { item[1] = "Z"; }
            }
            else if (item[1] == "Z") // win
            {
                if (item[0] == "A") { item[1] = "Y"; }
                else if (item[0] == "B") { item[1] = "Z"; }
                else if (item[0] == "C") { item[1] = "X"; }
            }

            newList.Add(item);
        }
        return newList;
    }

    private int Calculate(List<string[]> list)
    {
        var points = 0;
        foreach (var item in list)
        {
            if (item[1] == "X")
            {
                points++;
            }
            else if (item[1] == "Y")
            {
                points += 2;
            }
            else if (item[1] == "Z")
            {
                points += 3;
            }

            if ((item[1] == "Y" && item[0] == "A") ||
                (item[1] == "X" && item[0] == "C") ||
                (item[1] == "Z" && item[0] == "B"))
            {
                points += 6;
            }
            else if ((item[1] == "X" && item[0] == "A") ||
                (item[1] == "Y" && item[0] == "B") ||
                (item[1] == "Z" && item[0] == "C"))
            {
                points += 3;
            }
        }
        return points;
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
