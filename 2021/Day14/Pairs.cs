namespace Day14
{
    public class Pairs
    {
        public Pairs(string pair, long count)
        {
            Pair = pair;
            Count = count;
        }

        public string Pair { get; set; }
        public long Count { get; set; } = 1;
    }
}
