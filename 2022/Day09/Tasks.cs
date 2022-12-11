namespace Day09;

internal class Tasks
{
    internal int Task1()
    {
        (int x, int y) head = (0, 0);
        (int x, int y) tail = (0, 0);
        List<(int x, int y)> visited = new() { (0, 0) };

        foreach (var item in Instructions())
        {
            for (int i = 0; i < item.count; i++)
            {
                if (item.dir == 'L') { head.x--; }
                if (item.dir == 'R') { head.x++; }
                if (item.dir == 'U') { head.y--; }
                if (item.dir == 'D') { head.y++; }

                (head, tail) = Reposition(head, tail);
                if (!visited.Contains(tail)) { visited.Add(tail); }
            }
        }

        return visited.Count();
    }

    // With inspiration from https://github.com/OskarPersson
    internal int Task2()
    {
        (int x, int y) head = (0, 0);
        List<(int, int)> tail = new() { (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), (0, 0), };
        List<(int x, int y)> visited = new() { (0, 0) };

        foreach (var item in Instructions())
        {
            for (int i = 0; i < item.count; i++)
            {
                if (item.dir == 'L') { head.x--; }
                if (item.dir == 'R') { head.x++; }
                if (item.dir == 'U') { head.y--; }
                if (item.dir == 'D') { head.y++; }

                for (int j = 0; j < 9; j++)
                {
                    var x1 = head;
                    if (j > 0) { x1 = tail[j - 1]; }
                    var x2 = tail[j];

                    (x1, x2) = Reposition(x1, x2);

                    if (j > 0) { tail[j - 1] = x1; }
                    tail[j] = x2;

                    if (!visited.Contains(tail[8])) { visited.Add(tail[8]); }
                }
            }
        }

        return visited.Count();
    }

    private List<(char dir, int count)> Instructions()
    {
        var rows = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt")).ToList();

        List<(char dir, int count)> list = new();
        foreach (var row in rows)
        {
            list.Add((row.Split(" ")[0][0], Convert.ToInt32(row.Split(" ")[1])));
        }

        return list;
    }
    ((int x, int y) head, (int x, int y) tail) Reposition((int x, int y) head, (int x, int y) tail)
    {
        if (tail.x < head.x - 1)
        {
            tail.x += 1;
            if (tail.y == head.y) return (head, tail);

            if (tail.y < head.y) tail.y += 1;
            else tail.y -= 1;
        }
        else if (tail.x > head.x + 1)
        {
            tail.x -= 1;
            if (tail.y == head.y) return (head, tail);

            if (tail.y < head.y) tail.y += 1;
            else tail.y -= 1;
        }
        else if (tail.y < head.y - 1)
        {
            tail.y += 1;
            if (tail.x == head.x) return (head, tail);

            if (tail.x < head.x) tail.x += 1;
            else tail.x -= 1;
        }
        else if (tail.y > head.y + 1)
        {
            tail.y -= 1;
            if (tail.x == head.x) return (head, tail);

            if (tail.x < head.x) tail.x += 1;
            else tail.x -= 1;
        }

        return (head, tail);
    }
}