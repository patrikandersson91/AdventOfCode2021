namespace Day3
{
    public class Tasks
    {
        public int Task1()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            var rawList = new List<string>(File.ReadAllLines(filePath));

            string gamma = "";
            string epsilon = "";

            for (int i = 0; i < 12; i++)
            {
                if (CountBits(rawList, i, true)) { gamma += '1'; epsilon += '0'; }
                else { gamma += '0'; epsilon += '1'; }
            }

            int gammaValue = Convert.ToInt32(gamma, 2);
            int epsilonValue = Convert.ToInt32(epsilon, 2);

            return gammaValue * epsilonValue;
        }

        public int Task2()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            var rawList = new List<string>(File.ReadAllLines(filePath));

            var oxygenFilter = new List<string>(rawList);
            var scrubberFilter = new List<string>(rawList);

            for (int i = 0; i < 12; i++)
            {
                if (oxygenFilter.Count > 1)
                {
                    if (CountBits(oxygenFilter, i, true))
                    {
                        oxygenFilter.RemoveAll(x => x.ToCharArray()[i] == '0');
                    }
                    else
                    {
                        oxygenFilter.RemoveAll(x => x.ToCharArray()[i] == '1');
                    }
                }
                if (scrubberFilter.Count > 1)
                {
                    if (CountBits(scrubberFilter, i, false))
                    {
                        scrubberFilter.RemoveAll(x => x.ToCharArray()[i] == '0');
                    }
                    else
                    {
                        scrubberFilter.RemoveAll(x => x.ToCharArray()[i] == '1');
                    }
                }
            }

            var oxygenValue = Convert.ToInt32(oxygenFilter.FirstOrDefault(), 2);
            var scrubberValue = Convert.ToInt32(scrubberFilter.FirstOrDefault(), 2);

            return oxygenValue * scrubberValue;
        }

        private bool CountBits(List<string> list, int index, bool oxygen)
        {
            var one = 0;
            var zero = 0;

            foreach (var item in list)
            {
                if (item[index] == '1') { one++; }
                else { zero++; }
            }
            return oxygen ? (one >= zero) : (zero > one);
        }
    }
}
