namespace Day14
{
    public class Tasks
    {
        public long Task1()
        {
            var polymers = GetPolymerTemplate();
            var pairs = GetPairInsertions();

            polymers = InsertPairs(polymers, pairs, 10);

            return CountPolymerMaxMin(polymers); // 2891
        }

        public long Task2()
        {
            var polymer = GetPolymerTemplate();
            var pairs = GetPairInsertions();

            polymer = InsertPairs(polymer, pairs, 40);

            return CountPolymerMaxMin(polymer); // 4607749009683
        }

        private List<Pairs> InsertPairs(List<Pairs> polymers, List<(string pair, string insert)> pairs, int steps)
        {
            for (int step = 0; step < steps; step++)
            {
                List<Pairs> tempList = new();
                foreach (var temp in polymers)
                {
                    var insert = pairs.First(x => x.pair == temp.Pair).insert;

                    var combind1 = temp.Pair[0] + insert;
                    var exist = tempList.FirstOrDefault(x => x.Pair == combind1);
                    if (exist is null) { tempList.Add(new Pairs(combind1, temp.Count)); }
                    else { exist.Count += temp.Count; }

                    var combind2 = insert + temp.Pair[1];
                    var exist2 = tempList.FirstOrDefault(x => x.Pair == combind2);
                    if (exist2 is null) { tempList.Add(new Pairs(combind2, temp.Count)); }
                    else { exist2.Count += temp.Count; }
                }
                polymers = new(tempList);
            }
            return polymers;
        }
        private long CountPolymerMaxMin(List<Pairs> polymers)
        {
            List<Pairs> pairs = new();
            foreach (var polymer in polymers)
            {
                string first = polymer.Pair[0].ToString();
                var exist = pairs.FirstOrDefault(x => x.Pair == first);
                if (exist is null) { pairs.Add(new(first, polymer.Count)); }
                else { exist.Count += polymer.Count; }

                string second = polymer.Pair[1].ToString();
                var exist2 = pairs.FirstOrDefault(x => x.Pair == second);
                if (exist2 is null) { pairs.Add(new(second, polymer.Count)); }
                else { exist2.Count += polymer.Count; }
            }

            return (pairs.Max(x => x.Count) - 1) / 2 - (pairs.Min(x => x.Count) / 2);
        }
        private List<Pairs> GetPolymerTemplate()
        {
            var text = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt"));
            var template = text.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)[0];

            List<Pairs> pairs = new();

            int length = template.Length;
            for (int i = 0; i < length - 1; i++)
            {
                var substring = template.Substring(i, 2);

                var exist = pairs.FirstOrDefault(x => x.Pair == substring);
                if (exist is null) { pairs.Add(new(substring, 1)); }
                else { exist.Count++; }
            }
            return pairs;
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