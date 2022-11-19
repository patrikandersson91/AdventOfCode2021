string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");

int count = 0;

foreach (string nr in File.ReadLines(filePath))
{
    count++;
}

Console.WriteLine(count);

// Prepared for first day of 2022