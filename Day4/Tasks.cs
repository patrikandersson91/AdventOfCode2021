namespace Day4
{
    public static class Tasks
    {
        public static int Task1()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            List<string> rawList = new(File.ReadAllText(filePath).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            // Get all bingo numbers we will run later on
            List<int> bingoNumbers = new(rawList.First().Split(",").Select(int.Parse).ToList());

            // Create all boards
            var number = 0;
            List<Board> boards = new();
            foreach (var item in rawList)
            {
                // Continue if first line (bingo numbers)
                if (number == 0) { number++; continue; }
                var newBoard = new Board(number);

                // Create horizontal rows
                List<string> rawRows = new(item.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
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

                // Create vertical rows from horizontal rows
                List<BoardRow> horizontalRows = new(newBoard.Rows);
                for (int i = 0; i < horizontalRows.Count(); i++)
                {
                    BoardRow newBoardRow = new(false);
                    for (int j = 0; j < horizontalRows.Count(); j++)
                    {
                        newBoardRow.Numbers.Add(new RowNumber(horizontalRows[j].Numbers[i].Number));
                    }
                    newBoard.Rows.Add(newBoardRow);
                }

                boards.Add(newBoard);
                number++;
            }

            // Go number by number until one board wins and return calculated sum
            foreach (var bingoNr in bingoNumbers)
            {
                foreach (var board in boards)
                {
                    foreach (var row in board.Rows)
                    {
                        foreach (var nr in row.Numbers.Where(x => !x.Marked))
                        {
                            if (nr.Number == bingoNr)
                            {
                                nr.Marked = true;
                                if (row.Numbers.All(x => x.Marked))
                                {
                                    return board.Rows.Where(r => r.Horizontal).Sum(x => x.Numbers.Where(i => !i.Marked).Sum(s => s.Number)) * bingoNr;
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }

        public static int Task2()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            List<string> rawList = new(File.ReadAllText(filePath).Split(new string[] { "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries));

            // Get all bingo numbers we will run later on
            List<int> bingoNumbers = new(rawList.First().Split(",").Select(int.Parse).ToList());

            // Create all boards
            var number = 0;
            List<Board> boards = new();
            foreach (var item in rawList)
            {
                // Continue if first line (bingo numbers)
                if (number == 0) { number++; continue; }
                var newBoard = new Board(number);

                // Create horizontal rows
                List<string> rawRows = new(item.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
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

                // Create vertical rows from horizontal rows
                List<BoardRow> horizontalRows = new(newBoard.Rows);
                for (int i = 0; i < horizontalRows.Count(); i++)
                {
                    BoardRow newBoardRow = new(false);
                    for (int j = 0; j < horizontalRows.Count(); j++)
                    {
                        newBoardRow.Numbers.Add(new RowNumber(horizontalRows[j].Numbers[i].Number));
                    }
                    newBoard.Rows.Add(newBoardRow);
                }

                boards.Add(newBoard);
                number++;
            }

            // Go number by number until last board wins and return calculated sum
            foreach (var bingoNr in bingoNumbers)
            {
                foreach (var board in boards.Where(x=>x.Placement is null))
                {
                    foreach (var row in board.Rows)
                    {
                        foreach (var nr in row.Numbers.Where(x => !x.Marked))
                        {
                            if (nr.Number == bingoNr)
                            {
                                nr.Marked = true;
                                if (row.Numbers.All(x => x.Marked))
                                {
                                    if (boards.Count(x => x.Placement is null) > 1)
                                    {
                                        board.Placement = boards.Max(x => x.Placement) == null ? 1 : boards.Max(x => x.Placement).Value + 1;
                                    }
                                    else
                                    {
                                        return board.Rows.Where(r => r.Horizontal).Sum(x => x.Numbers.Where(i => !i.Marked).Sum(s => s.Number)) * bingoNr;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return 0;
        }
    }
}
