using System;
using System.Numerics;

namespace BitShiftMatrix
{
    class BigShiftMatrixClass
    {
        static void Main()
        {
            int rowMatrix = int.Parse(Console.ReadLine());
            int colMatrix = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            string[] codesInput = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            decimal[] codes = new decimal[codesInput.Length];
            for (int i = 0; i < codesInput.Length; i++)
            {
                codes[i] = decimal.Parse(codesInput[i]);
            }
            
            BigInteger[,] theMatrix = new BigInteger[rowMatrix, colMatrix];
            theMatrix[rowMatrix - 1, 0] = 1;
            for (int row = rowMatrix - 1; row >= 0; row--)
            {
                if (row < rowMatrix - 1)
                {
                    theMatrix[row, 0] = theMatrix[row + 1, 0] * 2;
                }
                for (int col = 1; col < colMatrix; col++)
                {
                    theMatrix[row, col] = theMatrix[row, col - 1] * 2;
                }
            }
            bool[,] theMatrixBool = new bool[rowMatrix, colMatrix];
            for (int row = 0; row < rowMatrix; row++)
            {
                for (int col = 0; col < colMatrix; col++)
                {
                    theMatrixBool[row, col] = false;
                }
            }
            
            int coef = 0;
            int rowTarget = 0;
            int colTarget = 0;
            int rowCurrent = rowMatrix - 1;
            int colCurrent = 0;
            BigInteger counter = 0;
            if (rowMatrix >= colMatrix)
            {
                coef = rowMatrix;
            }
            else if (colMatrix > rowMatrix)
            {
                coef = colMatrix;
            }
            int[] currentPosition = new int[2];
            bool rowDirectionDown = true; 
            bool colDirectionRight = true;         

            for (int i = 0; i < codes.Length; i++)
            {

                rowTarget = ((int)codes[i]) / coef;
                colTarget = ((int)codes[i]) % coef;

                if(colTarget > colCurrent)
                {
                    colDirectionRight = true;
                }
                else
                {
                    colDirectionRight = false;
                }
                if(rowTarget > rowCurrent)
                {
                    rowDirectionDown = true;
                }
                else
                {
                    rowDirectionDown = false;
                }

                if (colDirectionRight)
                {
                    for (int col = colCurrent; col <= colTarget; col++)
                    {
                        if(!theMatrixBool[rowCurrent, col])
                        {
                            counter += theMatrix[rowCurrent, col];
                            theMatrixBool[rowCurrent, col] = true;
                        }
                    }
                }
                else
                {
                    for (int col = colCurrent; col >= colTarget; col--)
                    {
                        if (!theMatrixBool[rowCurrent, col])
                        {
                            counter += theMatrix[rowCurrent, col];
                            theMatrixBool[rowCurrent, col] = true;
                        }
                    }
                }
                colCurrent = colTarget;
                if (rowDirectionDown)
                {
                    for (int row = rowCurrent; row <= rowTarget; row++)
                    {
                        if (!theMatrixBool[row, colCurrent])
                        {
                            counter += theMatrix[row, colCurrent];
                            theMatrixBool[row, colCurrent] = true;
                        }
                    }
                }
                else
                {
                    for (int row = rowCurrent; row >= rowTarget; row--)
                    {
                        if (!theMatrixBool[row, colCurrent])
                        {
                            counter += theMatrix[row, colCurrent];
                            theMatrixBool[row, colCurrent] = true;
                        }
                    }
                }
                rowCurrent = rowTarget;

            }

            Console.WriteLine(counter);
        }
    }
}