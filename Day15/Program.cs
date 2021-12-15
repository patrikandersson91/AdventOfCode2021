using Day15;
using System.Diagnostics;

Tasks tasks = new();
Stopwatch watch = new();

watch.Start();
Console.WriteLine("Task1: " + tasks.Task1() + " --> " + watch.ElapsedMilliseconds + "ms");
watch.Restart();
Console.WriteLine("Task2: " + tasks.Task2() + " --> " + watch.ElapsedMilliseconds + "ms");
watch.Stop();
