namespace Day5
{
    public class Tasks
    {
        public int Task1()
        {
            List<string> rawList = GetRawList();
            List<Coordinate> coordinates = new();

            foreach (var line in rawList)
            {
                var separator = line.Split(" -> ");
                int x1 = Convert.ToInt32(separator[0].Split(",")[0]);
                int y1 = Convert.ToInt32(separator[0].Split(",")[1]);
                int x2 = Convert.ToInt32(separator[1].Split(",")[0]);
                int y2 = Convert.ToInt32(separator[1].Split(",")[1]);

                if (x1 != x2 && y1 != y2) { continue; }

                coordinates.AddRange(GetLinearCoordinates(x1, y1, x2, y2));
            }

            return CountDuplicateCoordinates(coordinates);
        }

        public int Task2()
        {
            List<string> rawList = GetRawList();
            List<Coordinate> coordinates = new();

            foreach (var line in rawList)
            {
                var separator = line.Split(" -> ");
                int x1 = Convert.ToInt32(separator[0].Split(",")[0]);
                int y1 = Convert.ToInt32(separator[0].Split(",")[1]);
                int x2 = Convert.ToInt32(separator[1].Split(",")[0]);
                int y2 = Convert.ToInt32(separator[1].Split(",")[1]);

                if (x1 != x2 && y1 != y2)
                {
                    if (Math.Max(x1, x2) - Math.Min(x1, x2) == Math.Max(y1, y2) - Math.Min(y1, y2))
                    {
                        coordinates.AddRange(GetDiagonalCoordinates(x1, y1, x2, y2));
                    }
                }
                else
                {
                    coordinates.AddRange(GetLinearCoordinates(x1, y1, x2, y2));
                }
            }

            return CountDuplicateCoordinates(coordinates);
        }


        private List<string> GetRawList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllLines(filePath));
        }

        private List<Coordinate> GetLinearCoordinates(int x1, int y1, int x2, int y2)
        {
            List<Coordinate> coordinates = new();

            int xMin = Math.Min(x1, x2);
            int xMax = Math.Max(x1, x2);
            int yMin = Math.Min(y1, y2);
            int yMax = Math.Max(y1, y2);

            var xRange = Enumerable.Range(xMin, xMax - xMin + 1).ToList();
            var yRange = Enumerable.Range(yMin, yMax - yMin + 1).ToList();

            foreach (var x in xRange)
            {
                foreach (var y in yRange)
                {
                    coordinates.Add(new Coordinate(x, y));
                }
            }

            return coordinates;
        }

        private List<Coordinate> GetDiagonalCoordinates(int x1, int y1, int x2, int y2)
        {
            List<Coordinate> coordinates = new();

            int xMin = Math.Min(x1, x2);
            int xMax = Math.Max(x1, x2);

            for (int i = 0; i <= xMax - xMin; i++)
            {
                if (x1 > x2 && y1 > y2)
                {
                    coordinates.Add(new Coordinate(x1 - i, y1 - i));
                }
                else if (x1 < x2 && y1 < y2)
                {
                    coordinates.Add(new Coordinate(x1 + i, y1 + i));
                }
                else if (x1 > x2 && y1 < y2)
                {
                    coordinates.Add(new Coordinate(x1 - i, y1 + i));
                }
                else
                {
                    coordinates.Add(new Coordinate(x1 + i, y1 - i));
                }
            }

            return coordinates;
        }

        private int CountDuplicateCoordinates(List<Coordinate> coordinates)
        {
            return coordinates
                     .GroupBy(m => new { m.X, m.Y })
                     .Where(g => g.Count() > 1)
                     .Count();
        }
    }
}