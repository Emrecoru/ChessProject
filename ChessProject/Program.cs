using System;
using System.Collections;

class ChessProject
{
    static List<Tuple<int, int>> Algorithm(Tuple<int, int, int, int>parameters)
    {
        int x = parameters.Item1, y = parameters.Item2, a = parameters.Item3, b = parameters.Item4;

        Queue<Tuple<int, int>> queue = new Queue<Tuple<int, int>>();
        HashSet<Tuple<int, int>> visited = new HashSet<Tuple<int, int>>();
        Dictionary<Tuple<int, int>, Tuple<int, int>> parent = new Dictionary<Tuple<int, int>, Tuple<int, int>>();

        queue.Enqueue(new Tuple<int, int>(x, y));
        visited.Add(new Tuple<int, int>(x, y));

        int[] dx = { 1, 1, 2, 2, -1, -1, -2, -2 };
        int[] dy = { 2, -2, 1, -1, 2, -2, 1, -1 };

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            x = current.Item1;
            y = current.Item2;

            if (x == a && y == b)
                break;

            for (int i = 0; i < dx.Length; i++)
            {
                int nx = x + dx[i];
                int ny = y + dy[i];

                if (nx >= 1 && nx <= 8 && ny >= 1 && ny <= 8 && !visited.Contains(new Tuple<int, int>(nx, ny)))
                {
                    visited.Add(new Tuple<int, int>(nx, ny));
                    parent[new Tuple<int, int>(nx, ny)] = current;
                    queue.Enqueue(new Tuple<int, int>(nx, ny));
                }
            }
        }

        List<Tuple<int, int>> path = new List<Tuple<int, int>>();
        Tuple<int, int> target = new Tuple<int, int>(a, b);

        while (target != null)
        {
            path.Add(target);
            target = parent.ContainsKey(target) ? parent[target] : null;
        }

        path.Reverse();
        return path;
    }

    static void PrintValues(List<Tuple<int, int>> myList)
    {
        Console.WriteLine("\n--------------------------------------------------------------\n");
        Console.WriteLine("Path :" + "\n");
        for (int i = 0; i < myList.Count; i++)
        {
            Console.Write(myList[i]);
            if (!(myList.Count - 1 == i))
            {
                Console.Write(" --> ");
            }
        }
        Console.WriteLine($"\n\nThe goal has been reached in {myList.Count} steps.");
        Console.WriteLine("\n--------------------------------------------------------------\n");
    }

    static Tuple<int, int, int, int> GetInputCoordinates()
    {
        Console.WriteLine("\n-------------------Find Knight's Path-------------------------\n");
        Console.WriteLine("Please enter the value of the starting point's x-index");
        int startInputx = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please enter the value of the starting point's y-index");
        int startInputy = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please enter the value of the target point's x-index");
        int targetInputx = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Please enter the value of the target point's y-index");
        int targetInputy = Convert.ToInt16(Console.ReadLine());

        return new Tuple<int, int, int, int>(startInputx, startInputy, targetInputx, targetInputy);
    }

    static void Main(string[] args)
    {
        List<Tuple<int, int>> path = Algorithm(GetInputCoordinates());
        PrintValues(path);
    }
}