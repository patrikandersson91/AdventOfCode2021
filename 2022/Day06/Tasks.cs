namespace Day06;

internal class Tasks
{
    internal int Task1()
    {
        return FindFirstMarker(RawText, 4);
    }
    internal int Task2()
    {
        return FindFirstMarker(RawText, 14);
    }

    private int FindFirstMarker(string text, int amount)
    {
        List<char> list = new();
        var count = 0;
        foreach (var item in text)
        {
            count++;
            list.Add(item);
            if (list.Count == amount && list.Distinct().Count() == amount)
            {
                return count; //new string(list.ToArray());
            }
            if (list.Count >= amount) { list.RemoveAt(0); }
        }
        throw new Exception("Could not find first marker.");
    }
    private string RawText => File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt"));
}
