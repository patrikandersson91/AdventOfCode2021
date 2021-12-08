namespace Day8
{
    public class Tasks
    {
        public int Task1()
        {
            var rows = GetRows();
            var count = 0;
            foreach (var row in rows)
            {
                var output = row.Split(" | ")[1].Split(" ").ToList();

                foreach (var item in output)
                {
                    if (item.Length == 2 || item.Length == 3 || item.Length == 4 || item.Length == 7)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public int Task2()
        {
            var rows = GetRows();
            List<int> finalNumbers = new();

            foreach (var row in rows)
            {
                var patterns = row.Split(" | ")[0].Split(" ").ToList();
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
                var l8 = positions.First(x => x.Number == 8).Letters;

                // 2,5,6 does not contain 1
                // 0,1,2,3,5,6,7 does not contain 4
                // 1,4,5,6 does not contain 7
                // 0,1,2,3,4,5,6,7,9 does not contain 8

                positions.Add(new(6, "")); // 6
                positions.Add(new(0, "")); // 0
                positions.Add(new(9, "")); // 9
                positions.Add(new(2, "")); // 2
                positions.Add(new(3, "")); // 3
                positions.Add(new(5, "")); // 5

                var output = row.Split(" | ")[1];
                foreach (var item in output)
                {
                    var result = "";
                    var nrs = output.Split(" ").ToList();
                    foreach (var nr in nrs)
                    {
                        var arr = nr.ToCharArray();
                        result += positions.First(x => nr.Length == x.Letters.Length && x.Letters.All(c => arr.Contains(c))).Number;
                    }
                    finalNumbers.Add(int.Parse(result));
                }
            }

            return finalNumbers.Sum();
        }


        private List<string> GetRows()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
