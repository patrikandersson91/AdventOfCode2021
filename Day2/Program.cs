using Day2;

string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
var sub = new Submarine();

foreach (string line in File.ReadLines(filePath))
{
    var separator = line.Split(" ");
    var command = separator[0];
    var amount = Convert.ToInt32(separator[1]);

    switch (command)
    {
        case "forward":
            sub.Distance += amount;
            sub.Depth += amount * sub.Aim;
            break;
        case "down":
            sub.Aim += amount;
            break;
        case "up":
            sub.Aim -= amount;
            break;
    }
}
Console.WriteLine(sub.Depth * sub.Distance);