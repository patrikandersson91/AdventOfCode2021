namespace Day12
{
    public class Tasks
    {
        private List<(string from, string to)> rawPaths => GetRawPaths();

        public int Task1()
        {
            List<List<string>> totalRoutes = new();
            List<string> route = new();

            PathFind(totalRoutes, route, "start");

            return totalRoutes.Count; // 3802
        }
        public int Task2()
        {
            List<List<string>> totalRoutes = new();
            List<string> route = new();
            string? visitedTwice = null;

            PathFind(totalRoutes, route, "start", true, visitedTwice);

            return totalRoutes.Count; // 99448
        }

        private void PathFind(List<List<string>> totalRoutes, List<string> route, string path, bool checkTwice = false, string? visitedTwice = null)
        {
            if (path == "end")
            {
                route.Add(path);
                totalRoutes.Add(new(route));
                route.RemoveAt(route.Count - 1);
                return;
            }

            if (path.Any(char.IsLower) && route.Any(x => x == path))
            {
                if (!checkTwice || visitedTwice != null) { return; }
                else { visitedTwice = path; }
            }

            route.Add(path);

            var connections = rawPaths.Where(x => x.from == path && x.to != "start" &&
                !(x.to.Any(char.IsLower) && route.Any(r => r == x.to) && (!checkTwice || visitedTwice != null)))
                .Select(x => x.to).ToList();

            foreach (var newPath in connections)
            {
                PathFind(totalRoutes, route, newPath, checkTwice, visitedTwice);
            }

            route.RemoveAt(route.Count - 1);
            return;
        }
        private List<(string from, string to)> GetRawPaths()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            List<string> rows = new(File.ReadAllLines(filePath));
            List<(string from, string to)> connections = new();
            foreach (var row in rows)
            {
                var path = row.Split("-");
                connections.Add(new(path[0], path[1]));
                connections.Add(new(path[1], path[0]));
            }
            return connections;
        }
    }
}
