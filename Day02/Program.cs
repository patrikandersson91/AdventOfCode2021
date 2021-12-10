string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");

var depth = 0;
var distance = 0;
var aim = 0;

foreach (string line in File.ReadLines(filePath))
{
    var separator = line.Split(" ");
    var command = separator[0];
    var amount = Convert.ToInt32(separator[1]);

    switch (command)
    {
        case "forward":
            distance += amount;
            depth += amount * aim;
            break;
        case "down":
            aim += amount;
            break;
        case "up":
            aim -= amount;
            break;
    }
}
Console.WriteLine(depth * distance);