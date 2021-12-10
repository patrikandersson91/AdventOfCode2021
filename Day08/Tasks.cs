namespace Day8
{
    public class Tasks
    {
        public int Task1()
        {
            var count = 0;
            foreach (var row in GetRows())
            {
                List<string> output = row.Split(" | ")[1].Split(" ").ToList();
                foreach (var item in output)
                {
                    int lg = item.Length;
                    if (lg == 2 || lg == 3 || lg == 4 || lg == 7) { count++; }
                }
            }
            return count;
        }

        public int Task2()
        {
            List<int> finalNumbers = new();

            foreach (var row in GetRows())
            {
                List<string> patterns = row.Split(" | ")[0].Split(" ").ToList();
                List<Position> positions = GetSignalPatterns(patterns);
                
                var numbers = row.Split(" | ")[1].Split(" ").ToList();
                finalNumbers.Add(GetNumberByRowPositions(positions, numbers));
            }

            return finalNumbers.Sum();
        }

        private int GetNumberByRowPositions(List<Position> positions, List<string> numbers)
        {
            var result = string.Empty;
            foreach (var nr in numbers)
            {
                result += positions.First(x => nr.Length == x.Letters.Length && nr.All(y => x.Letters.Contains(y))).Number;
            }
            return int.Parse(result);
        }

        private List<Position> GetSignalPatterns(List<string> patterns)
        {
            List<Position> positions = new();
            foreach (var item in patterns)
            {
                if (item.Length == 2) { positions.Add(new(1, item)); } // 1
                else if (item.Length == 4) { positions.Add(new(4, item)); } // 4
                else if (item.Length == 3) { positions.Add(new(7, item)); } // 7  
                else if (item.Length == 7) { positions.Add(new(8, item)); } // 8
            }

            var l1 = positions.First(x => x.Number == 1).Letters;
            var l4 = positions.First(x => x.Number == 4).Letters;
            var l7 = positions.First(x => x.Number == 7).Letters;

            positions.Add(new(9, patterns.First(x => x.Length == 6 && l4.All(y => x.Contains(y))))); // 9
            var l9 = positions.First(x => x.Number == 9).Letters;

            positions.Add(new(3, patterns.First(x => x.Length == 5 && l1.Count(y => x.Contains(y)) == 2))); // 3
            var l3 = positions.First(x => x.Number == 3).Letters;

            positions.Add(new(0, patterns.First(x => x.Length == 6 && l7.All(y => x.Contains(y)) && x != l9))); // 0
            var l0 = positions.First(x => x.Number == 0).Letters;

            positions.Add(new(6, patterns.First(x => x.Length == 6 && x != l9 && x != l0))); // 6
            positions.Add(new(5, patterns.First(x => x.Length == 5 && l4.Count(y => x.Contains(y)) == 3 && x != l3))); // 5
            positions.Add(new(2, patterns.First(x => x.Length == 5 && l4.Count(y => x.Contains(y)) == 2))); // 2

            return positions;
        }

        private List<string> GetRows()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
