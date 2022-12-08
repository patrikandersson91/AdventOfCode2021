namespace Day08;

internal class Tasks
{
    internal int Task1()
    {
        var grid = GetGrid();
        var count = 0;

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                if (IsTreeVisible(x, y, grid)) { count++; }
            }
        }

        return count;
    }
    internal int Task2()
    {
        var grid = GetGrid();

        var highestScore = 0;
        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                var score = HighestScenicScore(x, y, grid);
                if (score > highestScore) { highestScore = score; }
            }
        }

        return highestScore;
    }

    private bool IsTreeVisible(int x, int y, int[,] grid)
    {
        // Edges
        if (x == 0 || x == grid.GetLength(0) - 1 || y == 0 || y == grid.GetLength(1) - 1) { return true; }

        // Left
        for (int i = x; i > 0; i--)
        {
            if (grid[x, y] > grid[i - 1, y])
            {
                if (i == 1) { return true; }
            }
            else { break; }
        }

        // Right
        for (int i = x; i < grid.GetLength(0); i++)
        {
            if (grid[x, y] > grid[i + 1, y])
            {
                if (i == grid.GetLength(0) - 2) { return true; }
            }
            else { break; }
        }

        // Top
        for (int i = y; i > 0; i--)
        {
            if (grid[x, y] > grid[x, i - 1])
            {
                if (i == 1) { return true; }
            }
            else { break; }
        }

        // Bottom
        for (int i = y; i < grid.GetLength(1) - 1; i++)
        {
            if (grid[x, y] > grid[x, i + 1])
            {
                if (i == grid.GetLength(1) - 2) { return true; }
            }
            else { break; }
        }

        return false;
    }
    private int HighestScenicScore(int x, int y, int[,] grid)
    {
        // Edges
        if (x == 0 || x == grid.GetLength(0) - 1 || y == 0 || y == grid.GetLength(1) - 1) { return 0; }

        // Left
        var left = 0;
        for (int i = x; i > 0; i--)
        {
            if (grid[x, y] > grid[i - 1, y]) { left++; }
            else { left++; break; }
        }

        // Right
        var right = 0;
        for (int i = x; i < grid.GetLength(0) - 1; i++)
        {
            if (grid[x, y] > grid[i + 1, y]) { right++; }
            else { right++; break; }
        }

        // Top
        var top = 0;
        for (int i = y; i > 0; i--)
        {
            if (grid[x, y] > grid[x, i - 1]) { top++; }
            else { top++; break; }
        }

        // Bottom
        var bottom = 0;
        for (int i = y; i < grid.GetLength(1) - 1; i++)
        {
            if (grid[x, y] > grid[x, i + 1]) { bottom++; }
            else { bottom++; break; }
        }

        return top * bottom * left * right;
    }
    private int[,] GetGrid()
    {
        var rows = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt")).ToList();

        int[,] grid = new int[rows[0].Length, rows.Count];
        for (int x = 0; x < rows.Count; x++)
        {
            for (int y = 0; y < rows[0].Length; y++)
            {
                grid[x, y] = Convert.ToInt32(rows[y][x].ToString());
            }
        }

        return grid;
    }
}