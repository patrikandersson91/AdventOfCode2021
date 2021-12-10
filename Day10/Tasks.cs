using System.Linq;

namespace Day10
{
    public class Tasks
    {
        Dictionary<char, char> pairs = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };

        public int Task1()
        {
            var raw = GetList();
            List<char> illegal = new();
            foreach (var line in GetList())
            {
                string tempCharacters = "";
                foreach (var c in line)
                {
                    if (pairs.Keys.Contains(c)) { tempCharacters += c; }
                    else if (pairs.TryGetValue(tempCharacters.Last(), out char x) && x == c)
                    {
                        tempCharacters = tempCharacters.Remove(tempCharacters.Length - 1);
                    }
                    else { illegal.Add(c); break; }
                }
            }
            var points = new Dictionary<char, int> { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            return illegal.Sum(x => points[x]); // 367227
        }

        public long Task2()
        {
            var raw = GetList();
            List<string> incompleted = new(raw);
            foreach (var line in raw)
            {
                string tempCharacters = "";
                foreach (var c in line)
                {
                    if (pairs.Keys.Contains(c)) { tempCharacters += c; }
                    else if (pairs.TryGetValue(tempCharacters.Last(), out char x) && x == c)
                    {
                        tempCharacters = tempCharacters.Remove(tempCharacters.Length - 1);
                    }
                    else
                    {
                        incompleted.Remove(incompleted.First(x => x == line));
                        break;
                    }
                }
            }

            List<List<char>> addedRows = new();
            foreach (var line in incompleted)
            {
                string tempCharacters = "";
                foreach (var c in line)
                {
                    if (pairs.Keys.Contains(c)) { tempCharacters += c; }
                    else { tempCharacters = tempCharacters.Remove(tempCharacters.Length - 1); }
                }

                if (tempCharacters.Length > 0)
                {
                    List<char> addedChars = tempCharacters.Reverse().Select(x => pairs[x]).ToList();
                    addedRows.Add(tempCharacters.Reverse().Select(x => pairs[x]).ToList());
                }
            }

            var points = new Dictionary<char, int> { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };
            var results = addedRows.Select(x => x.Aggregate(0L, (x, y) => x * 5 + points[y])).ToList(); 
            return results.OrderBy(x => x).Skip((addedRows.Count - 1) / 2).First(); // 3583341858 
        }

        private List<string> GetList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllLines(filePath));
        }
    }
}