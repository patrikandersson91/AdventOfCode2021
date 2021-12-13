namespace Day13
{
    public class Tasks
    {
        private List<string> rawList => GetList();

        public int Task1()
        {
            return 0;
        }

        public int Task2()
        {
            return 0;
        }

        private List<string> GetList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllLines(filePath));
        }
    }
}
