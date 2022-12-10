namespace Day10;

internal class Tasks
{
    internal int Task1()
    {
        var x = 1;
        var cycle = 1;
        Dictionary<int, int> signalStrength = new();

        foreach (var item in GetList())
        {
            if (item == "noop")
            {
                cycle++;
                signalStrength.Add(cycle, cycle * x);
                continue;
            }

            cycle++;
            signalStrength.Add(cycle, cycle * x);

            cycle++;
            x += Convert.ToInt32(item.Split(' ')[1]);
            signalStrength.Add(cycle, cycle * x);
        }
        return signalStrength.Where(x => x.Key == 20 || x.Key == 60 || x.Key == 100 || x.Key == 140 || x.Key == 180 || x.Key == 220).Sum(x => x.Value);
    }
    internal void Task2()
    {
        var grid = new char[40, 6];
        var x = 1;
        var cycle = 0;
        var row = 0;

        foreach (var item in GetList())
        {
            if (item == "noop")
            {
                if (IsVisible(x, cycle)) { grid[cycle % 40, row] = '#'; }
                (cycle, row) = AddCycle(cycle, row);
                continue;
            }

            if (IsVisible(x, cycle)) { grid[cycle % 40, row] = '#'; }
            (cycle, row) = AddCycle(cycle, row);

            if (IsVisible(x, cycle)) { grid[cycle % 40, row] = '#'; }
            (cycle, row) = AddCycle(cycle, row);

            x += Convert.ToInt32(item.Split(' ')[1]);
        }
        PrintGrid(grid);
    }

    private List<string> GetList()
    {
        var rows = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt")).ToList();
        return rows;
    }
    private (int cycle, int row) AddCycle(int cycle, int row)
    {
        if (cycle != 0 && cycle % 40 == 0) { row++; }
        return (cycle + 1, row);
    }
    private bool IsVisible(int x, int cycle)
    {
        return x >= cycle % 40 - 1 && x <= cycle % 40 + 1;
    }
    private void PrintGrid(char[,] grid)
    {
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                if (grid[x, y] != '\0') { Console.Write(grid[x, y]); }
                else { Console.Write('.'); }
            }
            Console.WriteLine();
        }
    }
}