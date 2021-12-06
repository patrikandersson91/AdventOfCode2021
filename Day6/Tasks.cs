namespace Day6
{
    public class Tasks
    {
        public int Task1()
        {
            List<int> fishes = GetList();

            for (int i = 0; i < 80; i++)
            {
                List<int> newFishes = new();

                for (int j = 0; j < fishes.Count; j++)
                {
                    if (fishes[j] < 1)
                    {
                        fishes[j] = 6;
                        newFishes.Add(8);
                    }
                    else
                    {
                        fishes[j]--;
                    }
                }
                fishes.AddRange(newFishes);
            }
            return fishes.Count();
        }

        public long Task2()
        {
            List<int> fishes = GetList();

            long[] cycle = new long[9];
            for (int i = 0; i <= 8; i++)
            {
                cycle[i] = fishes.Count(x => x == i);
            }

            for (int i = 0; i < 256; i++)
            {
                long newFishes = 0;
                long[] newCycle = new long[9];
                for (int j = 0; j < cycle.Length; j++)
                {
                    if (j == 0)
                    {
                        newCycle[6] = cycle[0];
                        newFishes += cycle[0];
                    }
                    else
                    {
                        newCycle[j-1] += cycle[j];
                    }
                }
                newCycle[8] = newFishes;
                cycle = newCycle;
            }

            return cycle.Sum();
        }

        private List<int> GetList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllText(filePath).Split(",").Select(int.Parse).ToList());
        }
    }
}