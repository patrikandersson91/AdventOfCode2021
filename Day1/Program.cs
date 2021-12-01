string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");

int count = 0;
int? previous = null;
var list = new List<int>();

foreach (string nr in File.ReadLines(filePath))
{
    list.Add(Convert.ToInt32(nr));

    if (list.Count == 3)
    {
        int depth = list.Sum();

        if (previous is not null && depth > previous)
        {
            count++;
        }
        previous = depth;
        list.Remove(list.First());
    }
}

Console.WriteLine(count);