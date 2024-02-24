using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        int Low = -17;
        int High = 15;

        Console.Write("rowCount = ");
        int rowCount = int.Parse(Console.ReadLine());

        Console.Write("colCount = ");
        int colCount = int.Parse(Console.ReadLine());

        int[][] a = new int[rowCount][];
        for (int i = 0; i < rowCount; i++)
            a[i] = new int[colCount];

        Input(a, rowCount, colCount);
        Print(a, rowCount, colCount);

        SortColumnsByCharacteristic(a, rowCount, colCount);
        Console.WriteLine("Matrix after sorting columns by characteristic:");
        Print(a, rowCount, colCount);

        int sum = SumOfColumnsWithNegativeElement(a, rowCount, colCount);
        Console.WriteLine("Sum of elements in columns with at least one negative element: " + sum);
    }
    
    public static void Input(int[][] a, int rowCount, int colCount)
    {
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                Console.Write($"a[{i}][{j}] = ");
                a[i][j] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }
    }

    public static void Print(int[][] a, int rowCount, int colCount)
    {
        Console.WriteLine();
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
                Console.Write($"{a[i][j],4}");
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    public static void SortColumnsByCharacteristic(int[][] a, int rowCount, int colCount)
    {
        List<(int, int)> characteristic = new List<(int, int)>();

        for (int j = 0; j < colCount; j++)
        {
            int sum = 0;
            for (int i = 0; i < rowCount; i++)
            {
                if (a[i][j] < 0 && a[i][j] % 2 != 0)
                {
                    sum += Math.Abs(a[i][j]);
                }
            }
            characteristic.Add((sum, j));
        }

        characteristic.Sort();

        int[][] tempMatrix = new int[rowCount][];
        for (int i = 0; i < rowCount; i++)
            tempMatrix[i] = new int[colCount];

        for (int j = 0; j < colCount; j++)
        {
            int originalColumnIndex = characteristic[j].Item2;
            for (int i = 0; i < rowCount; i++)
            {
                tempMatrix[i][j] = a[i][originalColumnIndex];
            }
        }

        for (int i = 0; i < rowCount; i++)
            for (int j = 0; j < colCount; j++)
                a[i][j] = tempMatrix[i][j];
    }

    public static int SumOfColumnsWithNegativeElement(int[][] a, int rowCount, int colCount)
    {
        int sum = 0;
        for (int j = 0; j < colCount; j++)
        {
            bool hasNegativeElement = false;
            for (int i = 0; i < rowCount; i++)
            {
                if (a[i][j] < 0)
                {
                    hasNegativeElement = true;
                    break;
                }
            }

            if (hasNegativeElement)
            {
                for (int i = 0; i < rowCount; i++)
                {
                    sum += a[i][j];
                }
            }
        }
        return sum;
    }
}