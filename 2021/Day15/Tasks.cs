namespace Day15
{
    /// <summary>
    /// I have taken inspiration from other people since I didn't know Dijkstras algorithm.
    /// I have also tested new ways of writing code, also inspired by other people.
    /// </summary>
    public class Tasks
    {
        public int Task1() => Dijkstra(GetMap()); // 595
        public int Task2() => Dijkstra(Scale(GetMap())); // 2914

        int Dijkstra(Dictionary<Point, int> map)
        {
            var first = new Point(0, 0);
            var last = new Point(map.Keys.MaxBy(p => p.x).x, map.Keys.MaxBy(p => p.y).y);

            var queue = new PriorityQueue<Point, int>();
            var totalMap = new Dictionary<Point, int>();

            totalMap[first] = 0;
            queue.Enqueue(first, 0);

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();

                foreach (var n in Neighbours(p))
                {
                    if (map.ContainsKey(n) && !totalMap.ContainsKey(n))
                    {
                        var totalRisk = totalMap[p] + map[n];
                        totalMap[n] = totalRisk;
                        if (n == last) { break; }
                        queue.Enqueue(n, totalRisk);
                    }
                }
            }

            return totalMap[last];
        }
        Dictionary<Point, int> Scale(Dictionary<Point, int> map)
        {
            var (col, row) = (map.Keys.MaxBy(p => p.x).x + 1, map.Keys.MaxBy(p => p.y).y + 1);

            var res = new Dictionary<Point, int>(
                from y in Enumerable.Range(0, row * 5)
                from x in Enumerable.Range(0, col * 5)

                let tileY = y % row
                let tileX = x % col
                let tileRiskLevel = map[new Point(tileX, tileY)]

                let tileDistance = (y / row) + (x / col)

                let riskLevel = (tileRiskLevel + tileDistance - 1) % 9 + 1
                select new KeyValuePair<Point, int>(new Point(x, y), riskLevel)
            );

            return res;
        }
        Dictionary<Point, int> GetMap()
        {
            var lines = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt"));
            return new Dictionary<Point, int>(
                from y in Enumerable.Range(0, lines[0].Length)
                from x in Enumerable.Range(0, lines.Length)
                select new KeyValuePair<Point, int>(new Point(x, y), int.Parse(lines[x][y].ToString()))
            );
        }

        IEnumerable<Point> Neighbours(Point point) =>
            new[] {
               point with {y = point.y + 1},
               point with {y = point.y - 1},
               point with {x = point.x + 1},
               point with {x = point.x - 1},
            };
        record Point(int x, int y);
    }
}