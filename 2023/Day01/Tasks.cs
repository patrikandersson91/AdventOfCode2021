using System.Text.RegularExpressions;

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

        List<int> numbers = new();
        foreach (var row in groups)
        {
            var rows = row.Split("\r\n");
            foreach (var line in rows)
            {
                var numbersOnly = Regex.Replace(line, "[^0-9.]", "");
                char firstNumber = numbersOnly.First();
                char lastNumber = numbersOnly.Last();
                numbers.Add(int.Parse(firstNumber.ToString() + lastNumber.ToString()));
            }
        }

        return numbers;
    }
}
