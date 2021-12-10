using System.Linq;

namespace Day10
{
    public class Tasks
    {
        Dictionary<char, char> pairs = new Dictionary<char, char> { { '(', ')' }, { '[', ']' }, { '{', '}' }, { '<', '>' } };

        public int Task1()
        {
            var raw = GetList();
            List<char> illegal = GetIllegal(GetList()).Item1;
            var points = new Dictionary<char, int> { { ')', 3 }, { ']', 57 }, { '}', 1197 }, { '>', 25137 } };
            return illegal.Sum(x => points[x]); // 367227
        }

        public long Task2()
        {
            var raw = GetList();
            List<string> incompleted = raw.Where(x=> !GetIllegal(raw).Item2.Contains(x)).ToList();
            List<List<char>> complementaryList = GetComplementaryCharactersList(incompleted);

            var points = new Dictionary<char, int> { { ')', 1 }, { ']', 2 }, { '}', 3 }, { '>', 4 } };
            var results = complementaryList.Select(x => x.Aggregate(0L, (x, y) => x * 5 + points[y])).ToList();
            return results.OrderBy(x => x).Skip((complementaryList.Count - 1) / 2).First(); // 3583341858 
        }

        private List<List<char>> GetComplementaryCharactersList(List<string> list) {
            List<List<char>> complementaryList = new();
            foreach (var row in list)
            {
                string tempCharacters = "";
                foreach (var c in row)
                {
                    if (pairs.Keys.Contains(c)) { tempCharacters += c; }
                    else { tempCharacters = tempCharacters.Remove(tempCharacters.Length - 1); }
                }
                if (tempCharacters.Length > 0)
                {
                    complementaryList.Add(tempCharacters.Reverse().Select(x => pairs[x]).ToList());
                }
            }
            return complementaryList;
        }
        private (List<char>, List<string>) GetIllegal(List<string> list)
        {
            List<char> illegalChars = new();
            List<string> illegalList = new();
            foreach (var row in list)
            {
                string tempCharacters = "";
                foreach (var c in row)
                {
                    if (pairs.Keys.Contains(c)) { tempCharacters += c; }
                    else if (pairs.TryGetValue(tempCharacters.Last(), out char x) && x == c)
                    {
                        tempCharacters = tempCharacters.Remove(tempCharacters.Length - 1);
                    }
                    else
                    {
                        illegalChars.Add(c);
                        illegalList.Add(row);
                        break;
                    }
                }
            }
            return (illegalChars, illegalList);
        }
        private List<string> GetList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllLines(filePath));
        }
    }
}