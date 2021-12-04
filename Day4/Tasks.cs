namespace Day4
{
    public static class Tasks
    {
        public static int Task1()
        {
            List<string> rawList = GetRawList();

            List<int> bingoNumbers = GetBingoNumbers(rawList);

            List<Board> boards = CreateBoards(rawList);

            foreach (var bingoNr in bingoNumbers)
            {
                 var result = CheckBingoNumber(boards, bingoNr, true);
                if (result is not null) { return result.Value; }
            }

            throw new Exception("Could not find winning board.");
        }

        public static int Task2()
        {
            List<string> rawList = GetRawList();

            List<int> bingoNumbers = GetBingoNumbers(rawList);

            List<Board> boards = CreateBoards(rawList);

            foreach (var bingoNr in bingoNumbers)
            {
                var result = CheckBingoNumber(boards, bingoNr, false);
                if(result is not null) { return result.Value; }
            }
            
            throw new Exception("Could not find last winning board.");
        }


        private static List<string> GetRawList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllText(filePath).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries));
        }

        private static List<int> GetBingoNumbers(List<string> rawList)
        {
            return new(rawList.First().Split(",").Select(int.Parse).ToList());
        }

        private static List<Board> CreateBoards(List<string> rawList)
        {
            List<Board> boards = new();
            foreach (var item in rawList)
            {
                if (rawList.First() == item) { continue; }
                var newBoard = new Board();
                List<string> rawRows = new(item.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));

                // Create horizontal rows
                foreach (var rawRow in rawRows)
                {
                    List<int> row = new(rawRow.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
                    BoardRow newBoardRow = new(true);
                    foreach (var nr in row)
                    {
                        newBoardRow.Numbers.Add(new RowNumber(nr));
                    }
                    newBoard.Rows.Add(newBoardRow);
                }

                // Create vertical rows
                List<BoardRow> horizontalRows = new(newBoard.Rows);
                for (int i = 0; i < horizontalRows.Count; i++)
                {
                    BoardRow newBoardRow = new(false);
                    for (int j = 0; j < horizontalRows.Count; j++)
                    {
                        newBoardRow.Numbers.Add(new RowNumber(horizontalRows[j].Numbers[i].Number));
                    }
                    newBoard.Rows.Add(newBoardRow);
                }

                boards.Add(newBoard);
            }
            return boards;
        }

        private static int? CheckBingoNumber(List<Board> boards, int number, bool winning)
        {
            foreach (var board in boards.Where(x => !x.Finished))
            {
                foreach (var row in board.Rows)
                {
                    foreach (var nr in row.Numbers.Where(x => !x.Marked))
                    {
                        if (nr.Number == number)
                        {
                            nr.Marked = true;
                            if (IsBingo(row))
                            {
                                if (!winning && boards.Count(x => !x.Finished) > 1)
                                {
                                    board.Finished = true;
                                }
                                else
                                {
                                    return CalculateBoard(board) * number;
                                }
                            }
                        }
                    }
                }
            }
            return null;
        }

        private static bool IsBingo(BoardRow row)
        {
            return row.Numbers.All(x => x.Marked);
        }

        private static int CalculateBoard(Board board)
        {
            return board.Rows.Where(x=>x.Horizontal).Sum(x => x.Numbers.Where(y => !y.Marked).Sum(y => y.Number));
        }
    }
}
