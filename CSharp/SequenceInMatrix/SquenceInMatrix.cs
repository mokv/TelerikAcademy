namespace SequenceInMatrix
{
    using System;

    class SquenceInMatrix
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] inputNumbers = new string[2];
            inputNumbers = input.Split(' ');
            int n = int.Parse(inputNumbers[0]);
            int m = int.Parse(inputNumbers[1]);
            string[,] matrix = new string[n, m];
            for (int rows = 0; rows < n; rows++)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                for (int i = 0; i < m; i++)
                {
                    matrix[rows, i] = numbers[i];
                }
            }

            //Here starts the actual calculating

            int counter = 1;
            int finalResult = 0;

            //On Rows

            for (int rows = 0; rows < n; rows++)
            {
                for (int cols = 0; cols < m - 1; cols++)
                {
                    if (matrix[rows, cols] == matrix[rows, cols + 1])
                    {
                        counter++;
                    }
                    else
                    {
                        if (counter > finalResult)
                        {
                            finalResult = counter;
                        }
                        counter = 1;
                    }
                    if (cols == m - 2)
                    {
                        if (counter > finalResult)
                        {
                            finalResult = counter;
                        }
                        counter = 1;
                    }
                }

            }

            //On Columns

            for (int cols = 0; cols < m; cols++)
            {
                for (int rows = 0; rows < n - 1; rows++)
                {
                    if (matrix[rows, cols] == matrix[rows + 1, cols])
                    {
                        counter++;
                    }
                    else
                    {
                        if (counter > finalResult)
                        {
                            finalResult = counter;
                        }
                        counter = 1;
                    }
                    if (rows == n - 2)
                    {
                        if (counter > finalResult)
                        {
                            finalResult = counter;
                        }
                        counter = 1;
                    }
                }
            }

            //On Diagonal

            for (int rows = 0; rows < n - 1; rows++)
            {
                for (int cols = 0; cols < m - 1; cols++)
                {
                    if (matrix[rows, cols] == matrix[rows + 1, cols + 1])
                    {
                        counter++;
                    }
                    else
                    {
                        if (counter > finalResult)
                        {
                            finalResult = counter;
                        }
                        counter = 1;
                    }
                    if (cols == m - 2)
                    {
                        if (counter > finalResult)
                        {
                            finalResult = counter;
                        }
                        counter = 1;
                    }
                    if (rows == n - 2)
                    {
                        if (counter > finalResult)
                        {
                            finalResult = counter;
                        }
                        counter = 1;
                    }
                }

            }

            Console.WriteLine(finalResult);
        }
    }
}
