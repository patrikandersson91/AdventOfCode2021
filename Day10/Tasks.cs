using System.Linq;

namespace Day10
{
    public class Tasks
    {
        public int Task1()
        {
            var raw = GetRawList();
            List<char> illegalChars = new();

            var startTags = new List<char> { '(', '[', '{', '<' };
            var endTags = new List<char> { ')', ']', '}', '>' };

            foreach (var line in raw)
            {
                string charText = "";
                foreach (var c in line)
                {
                    if (startTags.Contains(c))
                    {
                        charText += c;
                    }
                    else
                    {
                        var last = charText.Last();
                        if ((c == ')' && last == '(') ||
                            (c == ']' && last == '[') ||
                            (c == '}' && last == '{') ||
                            (c == '>' && last == '<'))
                        {
                            charText = charText.Remove(charText.Length - 1);
                        }
                        else
                        {
                            illegalChars.Add(c);
                            break;
                        }
                    }
                }
            }

            var sum = 0;
            sum += illegalChars.Count(x => x == ')') * 3;
            sum += illegalChars.Count(x => x == ']') * 57;
            sum += illegalChars.Count(x => x == '}') * 1197;
            sum += illegalChars.Count(x => x == '>') * 25137;
            return sum;
        }

        public long Task2()
        {
            var raw = GetRawList();
            var startTags = new List<char> { '(', '[', '{', '<' };
            var endTags = new List<char> { ')', ']', '}', '>' };

            List<string> incompletedList = new(raw);
            foreach (var line in raw)
            {
                string charText = "";
                foreach (var c in line)
                {
                    if (startTags.Contains(c))
                    {
                        charText += c;
                    }
                    else
                    {
                        var last = charText.Last();
                        if ((c == ')' && last == '(') ||
                            (c == ']' && last == '[') ||
                            (c == '}' && last == '{') ||
                            (c == '>' && last == '<'))
                        {
                            charText = charText.Remove(charText.Length - 1);
                        }
                        else
                        {
                            var item = incompletedList.Find(x => x == line);
                            incompletedList.Remove(item);
                            break;
                        }
                    }
                }
            }


            List<List<char>> addedRows = new();
            foreach (var line in incompletedList)
            {
                List<char> addedChars = new();
                string charText = "";
                foreach (var c in line)
                {
                    if (startTags.Contains(c))
                    {
                        charText += c;
                    }
                    else
                    {
                        charText = charText.Remove(charText.Length - 1);
                    }
                }
                foreach (var c in charText.Reverse())
                {
                    if (c == '(') { addedChars.Add(')'); }
                    else if (c == '[') { addedChars.Add(']'); }
                    else if (c == '{') { addedChars.Add('}'); }
                    else if (c == '<') { addedChars.Add('>'); }
                }

                if (addedChars.Any()) { addedRows.Add(addedChars); };
            }

            List<long> sums = new();
            foreach (var addedChars in addedRows)
            {
                long sum = 0;
                foreach (var c in addedChars)
                {
                    sum *= 5;
                    if (c == ')') { sum += 1; }
                    else if (c == ']') { sum += 2; }
                    else if (c == '}') { sum += 3; }
                    else if (c == '>') { sum += 4; }
                }
                sums.Add(sum);
            }
            var median = sums.OrderBy(x => x);

            return median.Skip((sums.Count - 1) / 2).First();
        }

        private List<string> GetRawList()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\input.txt");
            return new(File.ReadAllLines(filePath));
        }
    }
}