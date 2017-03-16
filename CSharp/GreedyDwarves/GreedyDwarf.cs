namespace GreedyDwarves
{
    using System;

    class GreedyDwarves
    {
        static void Main()
        {
            string[] inputValley = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            int[] valley = new int[inputValley.Length];
            for (int i = 0; i < inputValley.Length; i++)
            {
                valley[i] = int.Parse(inputValley[i]);
            }
            long bestPath = 0;
            bool end = false;
            bool[] valleyChecker = new bool[valley.Length];
            for (int i = 1; i < valleyChecker.Length; i++)
            {
                valleyChecker[i] = false;
            }
            valleyChecker[0] = true;
            int n = int.Parse(Console.ReadLine());
            long counter = valley[0];
            int currentIndex = 0;
            for (int k = 1; k <= n; k++)
            {
                string[] inputString = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                int[] pattern = new int[inputString.Length];
                for (int i = 0; i < inputString.Length; i++)
                {
                    pattern[i] = int.Parse(inputString[i]);
                }
                counter = valley[0];
                currentIndex = 0;
                while (!end)
                {
                    for (int i = 0; i < pattern.Length; i++)
                    {
                        currentIndex += pattern[i];
                        if (currentIndex >= valley.Length || currentIndex < 0)
                        {
                            end = true;
                            break;
                        }
                        else if (valleyChecker[currentIndex])
                        {
                            end = true;
                            break;
                        }
                        counter += valley[currentIndex];
                        valleyChecker[currentIndex] = true;
                    }
                }
                for (int i = 1; i < valleyChecker.Length; i++)
                {
                    valleyChecker[i] = false;
                }
                valleyChecker[0] = true;
                if (counter > bestPath && end)
                {
                    bestPath = counter;
                }
                end = false;
            }

            Console.WriteLine(bestPath);
        }
    }
}

