namespace Day11
{
    public class Tasks
    {
        public int Task1()
        {
            int[,] octopuses = GetGrid();
            int xMax = octopuses.GetLength(0);
            int yMax = octopuses.GetLength(1);

            var total = 0;
            for (int count = 0; count < 100; count++)
            {
                List<(int x, int y)> alreadyFlashed = new();
                for (int y = 0; y < yMax; y++)
                {
                    for (int x = 0; x < xMax; x++)
                    {
                        RaiseOctopusEnergy(octopuses, alreadyFlashed, x, y);
                    }
                }
                total += alreadyFlashed.Count();
            }

            return total; // 1732
        }

        public int Task2()
        {
            int[,] octopuses = GetGrid();
            int xMax = octopuses.GetLength(0);
            int yMax = octopuses.GetLength(1);

            var count = 1;
            while (true)
            {
                List<(int x, int y)> alreadyFlashed = new();
                for (int y = 0; y < yMax; y++)
                {
                    for (int x = 0; x < xMax; x++)
                    {
                        RaiseOctopusEnergy(octopuses, alreadyFlashed, x, y);
                    }
                }
                if (alreadyFlashed.Count == xMax * yMax)
                {
                    return count; // 290
                }
                count++;
            }
        }

        private void RaiseOctopusEnergy(int[,] octopuses, List<(int x, int y)> alreadyFlashed, int x, int y)
        {
            if (alreadyFlashed.Any(c => c.x == x && c.y == y)) { return; }
            octopuses[x, y]++;
            if (octopuses[x, y] <= 9) { return; }

            octopuses[x, y] = 0;
            alreadyFlashed.Add(new(x, y));

            int xMax = octopuses.GetLength(0) - 1;
            int yMax = octopuses.GetLength(1) - 1;

            for (int xx = x - 1; xx <= x + 1; xx++)
            {
                for (int yy = y - 1; yy <= y + 1; yy++)
                {
                    if (xx >= 0 && yy >= 0 && xx <= xMax && yy <= yMax)
                    {
                        RaiseOctopusEnergy(octopuses, alreadyFlashed, xx, yy);
                    }
                }
            }
            return;
        }

        private int[,] GetGrid(int length = 10)
        {
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt"));
            var array = new int[length, length];
            for (int y = 0; y < length; y++)
            {
                for (int x = 0; x < length; x++)
                {
                    array[x, y] = int.Parse(lines[y][x].ToString());
                }
            }
            return array;
        }
    }
}
