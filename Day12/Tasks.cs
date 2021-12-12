namespace Day12
{
    public class Tasks
    {
        private List<Connection> rawPaths => GetRawPaths();

        public int Task1()
        {
            List<List<Connection>> routes = new();
            List<Connection> route = new();

            var path = rawPaths.First(x => x.Start);
            PathFind(routes, path, route);

            return routes.Count(); // 3802
        }

        public int Task2()
        {
            List<List<Connection>> routes = new();
            List<Connection> route = new();

            var path = rawPaths.First(x => x.Start);
            Connection? visitedTwice = null;
            PathFind(routes, path, route, true, visitedTwice);

            return routes.Count(); // 99448
        }

        private void PathFind(List<List<Connection>> routes, Connection path, List<Connection> route, bool checkVisitedTwice = false, Connection? visitedTwice = null)
        {
            if (path.End)
            {
                route.Add(path);
                routes.Add(new(route));
                route.Remove(route.Last());
                return;
            }
            if (path.Small && route.Any(x => x.Node == path.Node))
            {
                if (!checkVisitedTwice || visitedTwice != null) { return; }
                else { visitedTwice = path; }
            }

            route.Add(path);

            var connections = rawPaths.Where(x => x.ConnectedTo == path.Node && !x.Start &&
            !(x.Small && route.Any(r => r.Node == x.Node) && 
            (!checkVisitedTwice || visitedTwice != null))).ToList();
            foreach (var newPath in connections)
            {
                PathFind(routes, newPath, route, checkVisitedTwice, visitedTwice);
            }
            route.Remove(route.Last());
            return;
        }
        private List<Connection> GetRawPaths()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            List<string> rows = new(File.ReadAllLines(filePath));
            List<Connection> connections = new();
            foreach (var row in rows)
            {
                var path = row.Split("-");
                connections.Add(new Connection
                {
                    Node = path[0],
                    ConnectedTo = path[1],
                    Small = path[0].Any(char.IsLower),
                    Start = path[0] == "start",
                    End = path[0] == "end"
                });

                connections.Add(new Connection
                {
                    Node = path[1],
                    ConnectedTo = path[0],
                    Small = path[1].Any(x => char.IsLower(x)),
                    Start = path[1] == "start",
                    End = path[1] == "end"
                });
            }
            return connections;
        }
    }
}
