using System.Text.RegularExpressions;

namespace Day01;

internal class Tasks
{
    private List<string> RawList => GetRawList();

    internal int Task1()
    {
        List<int> numbers = new();
        foreach (var row in RawList)
        {
            string nr = Regex.Replace(row, "[^0-9.]", "");
            numbers.Add(int.Parse(nr.First().ToString() + nr.Last().ToString()));
        }
        return numbers.Sum();
    }

    internal int Task2()
    {
        List<int> numbers = new();
        foreach (var row in RawList)
        {
            var nr = string.Empty;
            for (var i = 0; i < row.Length; i++)
            {
                if (char.IsDigit(row[i])) { nr += row[i]; continue; }

                if (i + 4 < row.Length)
                {
                    string word = row.Substring(i, 5);
                    if (word == "three") { nr += "3"; }
                    else if (word == "seven") { nr += "7"; }
                    else if (word == "eight") { nr += "8"; }
                }
                if (i + 3 < row.Length)
                {
                    string word = row.Substring(i, 4);
                    if (word == "four") { nr += "4"; }
                    else if (word == "five") { nr += "5"; }
                    else if (word == "nine") { nr += "9"; }
                }
                if (i + 2 < row.Length)
                {
                    string word = row.Substring(i, 3);
                    if (word == "one") { nr += "1"; }
                    else if (word == "two") { nr += "2"; }
                    else if (word == "six") { nr += "6"; }
                }
            }
            numbers.Add(int.Parse(nr.First().ToString() + nr.Last().ToString()));
        }
        return numbers.Sum();
    }

    private List<string> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        return File.ReadAllText(filePath).Split("\r\n").ToList();
    }
}
