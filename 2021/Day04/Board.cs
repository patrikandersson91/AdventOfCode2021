namespace Day4
{
    public class Board
    {
        public bool Finished { get; set; } = false;
        public List<BoardRow> Rows { get; set; } = new();
    }

    public class BoardRow
    {
        public BoardRow(bool horizontal)
        {
            Horizontal = horizontal;
        }

        public bool Horizontal { get; set; }
        public List<RowNumber> Numbers { get; set; } = new();
    }
    public class RowNumber
    {
        public RowNumber(int number)
        {
            Number = number;
        }

        public int Number { get; set; }
        public bool Marked { get; set; } = false;
    }
}
