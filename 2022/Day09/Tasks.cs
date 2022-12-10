namespace Day09;

internal class Tasks
{
    internal int Task1()
    {
        var grid = new char[1000, 1000];
        (int x, int y) head = (500, 500);
        (int x, int y) tail = head;
        grid[tail.x, tail.y] = '#';

        foreach (var item in Instructions())
        {
            if (item.dir == "L")
            {
                for (int i = 0; i < item.count; i++)
                {
                    head.x--;
                    if (Math.Abs(tail.x - head.x) > 1)
                    {
                        if (tail.y == head.y)
                        {
                            tail.x--;
                        }
                        else if (tail.y < head.y)
                        {
                            tail.x--;
                            tail.y++;
                        }
                        else if (tail.y > head.y)
                        {
                            tail.x--;
                            tail.y--;
                        }
                    }
                    grid[tail.x, tail.y] = '#';
                }
            }
            if (item.dir == "R")
            {
                for (int i = 0; i < item.count; i++)
                {
                    head.x++;
                    if (Math.Abs(head.x - tail.x) > 1)
                    {
                        if (tail.y == head.y)
                        {
                            tail.x++;
                        }
                        else if (tail.y < head.y)
                        {
                            tail.x++;
                            tail.y++;
                        }
                        else if (tail.y > head.y)
                        {
                            tail.x++;
                            tail.y--;
                        }
                    }
                    grid[tail.x, tail.y] = '#';
                }
            }
            if (item.dir == "U")
            {
                for (int i = 0; i < item.count; i++)
                {
                    head.y--;
                    if (Math.Abs(tail.y - head.y) > 1)
                    {
                        if (tail.x == head.x)
                        {
                            tail.y--;
                        }
                        else if (tail.x < head.x)
                        {
                            tail.x++;
                            tail.y--;
                        }
                        else if (tail.x > head.x)
                        {
                            tail.x--;
                            tail.y--;
                        }
                    }
                    grid[tail.x, tail.y] = '#';

                }
            }
            if (item.dir == "D")
            {
                for (int i = 0; i < item.count; i++)
                {
                    head.y++;
                    if (Math.Abs(head.y - tail.y) > 1)
                    {
                        if (tail.x == head.x)
                        {
                            tail.y++;
                        }
                        else if (tail.x < head.x)
                        {
                            tail.x++;
                            tail.y++;
                        }
                        else if (tail.x > head.x)
                        {
                            tail.x--;
                            tail.y++;
                        }
                    }
                    grid[tail.x, tail.y] = '#';
                }
            }
        }

        return CalculatePoints(grid);
    }

    private List<(string dir, int count)> Instructions()
    {
        var rows = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt")).ToList();

        List<(string dir, int count)> list = new();
        foreach (var row in rows)
        {
            list.Add((row.Split(" ")[0], Convert.ToInt32(row.Split(" ")[1])));
        }

        return list;
    }
    private int CalculatePoints(char[,] grid)
    {
        var count = 0;
        for (int y = 0; y < grid.GetLength(1); y++)
        {
            for (int x = 0; x < grid.GetLength(0); x++)
            {
                if (grid[x, y] == '#' || grid[x, y] == 's') { count++; }
            }
        }
        return count;
    }
}