namespace Day6
{
    public class Tasks
    {
        public long Task1()
        {
            List<int> fishes = GetList();
            long[] cycles = InsertCycles(fishes);

            cycles = GetFishCyclesAfterDays(cycles, 80);

            return cycles.Sum();
        }

        public long Task2()
        {
            List<int> fishes = GetList();
            long[] cycles = InsertCycles(fishes);

            cycles = GetFishCyclesAfterDays(cycles, 256);

            return cycles.Sum();
        }

        private List<int> GetList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllText(filePath).Split(",").Select(int.Parse).ToList());
        }

        private long[] InsertCycles(List<int> fishes)
        {
            long[] cycles = new long[9];

            for (int i = 0; i <= 8; i++)
            {
                cycles[i] = fishes.Count(x => x == i);
            }

            return cycles;
        }

        private long[] GetFishCyclesAfterDays(long[] cycle, int days)
        {
            for (int i = 0; i < days; i++)
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
                        newCycle[j - 1] += cycle[j];
                    }
                }
                newCycle[8] = newFishes;
                cycle = newCycle;
            }
            return cycle;
        }
    }
}