namespace Day7
{
    public class Tasks
    {
        public int Task1()
        {
            var crabs = GetList();
            List<int> positions = new();

            for (int avg = crabs.Min(); avg <= crabs.Max(); avg++)
            {
                positions.Add(crabs.Sum(x => Math.Abs(x - avg)));
            }

            return positions.Min();
            //return Enumerable.Range(crabs.Min(), crabs.Max() - crabs.Min()).Min(i => crabs.Sum(p => Math.Abs(i - p)));
        }

        public int Task2()
        {
            var crabs = GetList();
            List<int> positions = new();
                        
            for (int avg = crabs.Min(); avg <= crabs.Max(); avg++)
            {
                int fuel = 0;
                for (int j = 0; j < crabs.Count; j++)
                {
                    for (int i = 1; i <= Math.Abs(crabs[j] - avg); i++)
                    {
                        fuel += i;
                    }
                }
                positions.Add(fuel);
            }

            return positions.Min();
            //return Enumerable.Range(crabs.Min(), crabs.Max() - crabs.Min()).Min(i => crabs.Sum(p => Math.Abs(i - p) * (Math.Abs(i - p) + 1) / 2));
        }

        private List<int> GetList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllText(filePath).Split(",").Select(int.Parse).ToList());
        }
    }
}
