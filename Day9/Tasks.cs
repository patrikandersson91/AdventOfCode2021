namespace Day9
{
    public class Tasks
    {
        public int Task1()
        {
            var raw = GetMultidimensional();
            var lowPoints = FindLowPoints(raw);
            return lowPoints.Sum(a => raw[a.x, a.y] + 1);
        }

        public int Task2()
        {
            var raw = GetMultidimensional();
            var lowPoints = FindLowPoints(raw);
            List<(int x, int y, int nr)> basins = new();

            foreach (var lowPoint in lowPoints)
            {
                var newNr = basins.GroupBy(x => x.nr).Distinct().Count() + 1;
                FindBasinPoints(raw, basins, lowPoint.x, lowPoint.y, newNr);
            }

            var basinRange = basins.GroupBy(a => a.nr).Select(x => x.Count()).ToList();
            return basinRange.OrderByDescending(x => x).Take(3).Aggregate((x, y) => x * y);
        }

        List<(int x, int y, int nr)> FindBasinPoints(int[,] raw, List<(int x, int y, int nr)> basins, int x, int y, int basinNr)
        {
            if (basins.Any(a => a.x == x && a.y == y)) { return basins; }
            basins.Add(new(x, y, basinNr));

            int xMax = raw.GetLength(0);
            int yMax = raw.GetLength(1);

            if (y != 0 && raw[x, y - 1] != 9) { FindBasinPoints(raw, basins, x, y - 1, basinNr); } // Top
            if (x < xMax - 1 && raw[x + 1, y] != 9) { FindBasinPoints(raw, basins, x + 1, y, basinNr); } // Right
            if (y < yMax - 1 && raw[x, y + 1] != 9) { FindBasinPoints(raw, basins, x, y + 1, basinNr); } // Bottom
            if (x != 0 && raw[x - 1, y] != 9) { FindBasinPoints(raw, basins, x - 1, y, basinNr); } // Left

            return basins;
        }
        private List<(int x, int y)> FindLowPoints(int[,] raw)
        {
            List<(int x, int y)> lowPoints = new();
            int xMax = raw.GetLength(0);
            int yMax = raw.GetLength(1);

            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    if ((x <= 0 || raw[x, y] < raw[x - 1, y]) &&
                        (x >= xMax - 1 || raw[x, y] < raw[x + 1, y]) &&
                        (y <= 0 || raw[x, y] < raw[x, y - 1]) &&
                        (y >= yMax - 1 || raw[x, y] < raw[x, y + 1]))
                    {
                        lowPoints.Add((x, y));
                    }
                }
            }
            return lowPoints;
        }
        private int[,] GetMultidimensional(int length = 100)
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