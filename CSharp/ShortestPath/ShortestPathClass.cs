namespace ShortestPath
{
    using System;
    using System.Collections.Generic;

    class ShortestPathClass
    {
        static void Main()
        {
            string input = Console.ReadLine();
            char[] map = input.ToCharArray();
            char[] directions = new char[] { 'L', 'R', 'S' };
            List<string> pathList = new List<string>();
            FindingPath(map, 0, pathList, directions, input);
            Console.WriteLine(pathList.Count);
            foreach(var item in pathList)
            {
                Console.WriteLine(item);
            }

        }

        public static void FindingPath(char[] map, int index, List<string> pathList, char[] directions, string input)
        {
            if (index >= map.Length)
            {
                string newMap = new string(map);
                pathList.Add(newMap);
                return;
            }
            else
            {
                if (input[index] == '*')
                {
                    for (int i = 0; i < directions.Length; i++)
                    {
                        map[index] = directions[i];
                        FindingPath(map, index + 1, pathList, directions, input);
                    }
                }
                else
                {
                    map[index] = input[index];
                    FindingPath(map, index + 1, pathList, directions, input);
                }

            }
        }
    }
}
