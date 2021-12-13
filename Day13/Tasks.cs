namespace Day13
{
    public class Tasks
    {
        private (bool[,] coordinates, List<(string position, int line)> instructions) raw => GetInstructions();

        public int Task1()
        {
            bool[,] coordinates = raw.coordinates;

            coordinates = Fold(coordinates, raw.instructions.First().position, raw.instructions.First().line);

            return CalculateCoordinates(coordinates); // 638
        }

        public void Task2()
        {
            bool[,] coordinates = raw.coordinates;

            foreach (var instruction in raw.instructions)
            {
                coordinates = Fold(coordinates, instruction.position, instruction.line);
            }

            PrintCoordinates(coordinates);
            return;
        }


        void PrintCoordinates(bool[,] coordinates)
        {
            var xMax = coordinates.GetLength(0);
            var yMax = coordinates.GetLength(1);

            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    Console.Write(coordinates[x, y] ? "#" : ".");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
        int CalculateCoordinates(bool[,] coordinates)
        {
            var xMax = coordinates.GetLength(0);
            var yMax = coordinates.GetLength(1);

            int count = 0;
            for (int y = 0; y < yMax; y++)
            {
                for (int x = 0; x < xMax; x++)
                {
                    if (coordinates[x, y]) { count++; }
                }
            }
            return count;
        }
        private bool[,] Fold(bool[,] coordinates, string position, int line)
        {
            var xMax = coordinates.GetLength(0);
            var yMax = coordinates.GetLength(1);

            if (position == "x")
            {
                var newCords = new bool[line, yMax];
                for (int y = 0; y < yMax; y++)
                {
                    for (int x = 0; x < xMax; x++)
                    {
                        if (x > line) { newCords[line * 2 - x, y] |= coordinates[x, y]; }
                        else if (x < line) { newCords[x, y] = coordinates[x, y]; }
                    }
                }
                return newCords;
            }
            else
            {
                var newCords = new bool[xMax, line];
                for (int y = 0; y < yMax; y++)
                {
                    for (int x = 0; x < xMax; x++)
                    {
                        if (y > line) { newCords[x, line * 2 - y] |= coordinates[x, y]; }
                        else if (y < line) { newCords[x, y] = coordinates[x, y]; }
                    }
                }
                return newCords;
            }
        }
        private (bool[,] coordinates, List<(string position, int line)> instructions) GetInstructions()
        {
            var text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt"));
            var split = text.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

            var part1 = split[0].Split("\r\n").Select(s => s.Split(",").Select(a => int.Parse(a)).ToList()).ToList();
            var part2 = split[1].Split("\r\n").ToList();

            var xMax = part1.Max(a => a[0] + 1);
            var yMax = part1.Max(a => a[1] + 1);

            bool[,] coordinates = new bool[xMax, yMax];
            foreach (var c in part1) { coordinates[c[0], c[1]] = true; }

            List<(string position, int line)> instructions = new();
            foreach (var item in part2)
            {
                var folding = item.Split(" ").Last().Split("=");
                instructions.Add(new(folding[0], int.Parse(folding[1])));
            }

            return (coordinates, instructions);
        }
    }
}
