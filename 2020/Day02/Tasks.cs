namespace Day02;

internal class Tasks
{
    private List<(int from, int to, char letter, string password)> rawList => GetRawList();

    internal int Task1()
    {
        var validPasswords = 0;
        foreach (var item in rawList)
        {
            var count = item.password.Count(x => x == item.letter);
            if (count >= item.from && count <= item.to)
            {
                validPasswords++;
            }
        }
        return validPasswords;
    }

    internal int Task2()
    {
        var validPasswords = 0;
        foreach (var item in rawList)
        {
            var match = 0;
            if (item.password[item.from - 1] == item.letter) { match++; }
            if (item.password[item.to - 1] == item.letter) { match++; }
            if (match == 1) { validPasswords++; }
        }
        return validPasswords;
    }

    private List<(int from, int to, char letter, string password)> GetRawList()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
        var rows = File.ReadAllText(filePath).Split("\r\n").ToList();

        List<(int from, int to, char letter, string password)> list = new();
        foreach (var row in rows)
        {
            var parts = row.Split(": ");
            int from = Convert.ToInt32(parts[0].Split(" ")[0].Split("-")[0]);
            int to = Convert.ToInt32(parts[0].Split(" ")[0].Split("-")[1]);
            char letter = Convert.ToChar(parts[0].Split(" ")[1]);
            string password = parts[1];

            list.Add(new(from, to, letter, password));
        }

        return list;
    }
}
