namespace Day14
{
    public class Tasks
    {
        public int Task1()
        {
            var polymer = GetPolymerTemplate();
            var pairs = GetPairInsertions();

            polymer = InsertPairs(polymer, pairs, 10);

            return CountPolymerMaxMin(polymer); // 2891
        }

        public int Task2()
        {
            var polymer = GetPolymerTemplate();
            var pairs = GetPairInsertions();

            polymer = InsertPairs(polymer, pairs, 40);

            return CountPolymerMaxMin(polymer);
        }

        private string InsertPairs(string polymer, List<(string pair, string insert)> pairs, int steps)
        {
            for (int step = 0; step < steps; step++)
            {
                int length = polymer.Length;
                for (int i = 1; i < length; i++)
                {
                    var substring = polymer.Substring(length - 1 - i, 2);
                    var pair = pairs.First(x => x.pair == substring);
                    polymer = polymer.Insert(length - i, pair.insert);
                }
                Console.WriteLine("[Step " + (step + 1) + "] --> [Count " + polymer.Length + "]");
            }
            return polymer;
        }
        private int CountPolymerMaxMin(string polymer)
        {
            var occured = polymer.GroupBy(x => x)
                .Select(group => new { group.Key, Count = group.Count() })
                .OrderBy(x => x.Count);
            var min = occured.First().Count;
            var max = occured.Last().Count;
            return max - min;
        }
        private string GetPolymerTemplate()
        {
            var text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt"));
            var template = text.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)[0];

            return template;
        }
        private List<(string pair, string insert)> GetPairInsertions()
        {
            var text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt"));
            var rows = text.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)[1].Split("\r\n").ToList();

            List<(string pair, string insert)> pairInsertions = new();
            foreach (var row in rows)
            {
                var parts = row.Split(" -> ");
                pairInsertions.Add(new(parts[0], parts[1]));
            }

            return pairInsertions;
        }
    }
}