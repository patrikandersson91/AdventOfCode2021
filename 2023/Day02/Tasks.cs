namespace Day02;

internal class Tasks
{
    List<string> RawList => GetRawList();
    internal int Task1()
    {
        List<int> possibleGames = new();
        foreach (var row in RawList)
        {
            int gameId = int.Parse(row.Split(":")[0].Remove(0, 5));
            string[] gameSets = row.Split(": ")[1].Split("; ");
            bool invalidGame = false;
            foreach (var set in gameSets)
            {
                if (invalidGame) { break; }
                string[] hands = set.Split(", ");
                for (int i = 0; i < hands.Length; i++)
                {
                    int setNumber = int.Parse(hands[i].Split(" ")[0]);
                    string setColor = hands[i].Split(" ")[1];

                    if ((setColor == "red" && setNumber > 12) || (setColor == "green" && setNumber > 13) || (setColor == "blue" && setNumber > 14))
                    {
                        invalidGame = true; break;
                    }
                }
            }
            if (!invalidGame) { possibleGames.Add(gameId); }
        }
        return possibleGames.Sum();
    }

    internal int Task2()
    {
        List<int> gameScore = new();
        foreach (var row in RawList)
        {
            string[] gameSets = row.Split(": ")[1].Split("; ");
            int highestRed = 1;
            int highestGreen = 1;
            int highestBlue = 1;
            foreach (var set in gameSets)
            {
                string[] hands = set.Split(", ");
                for (int i = 0; i < hands.Length; i++)
                {
                    int setNumber = int.Parse(hands[i].Split(" ")[0]);
                    string setColor = hands[i].Split(" ")[1];

                    if (setColor == "red" && setNumber > highestRed) { highestRed = setNumber; }
                    if (setColor == "green" && setNumber > highestGreen) { highestGreen = setNumber; }
                    if (setColor == "blue" && setNumber > highestBlue) { highestBlue = setNumber; }
                }
            }
            var score = highestRed * highestGreen * highestBlue;
            gameScore.Add(score);
        }
        return gameScore.Sum();
    }

    private List<string> GetRawList()
    {
        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "input.txt");
        return File.ReadAllText(filePath).Split("\r\n").ToList();
    }
}
