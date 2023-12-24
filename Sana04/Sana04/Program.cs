// See https://aka.ms/new-console-template for more information

Console.WriteLine("Enter matrix height: ");
var height = int.Parse(Console.ReadLine());
Console.WriteLine("Enter matrix width: ");
var width = int.Parse(Console.ReadLine());

var array = new int[height, width];
var random = new Random();

for (int i = 0; i < height; i++)
{
    for (int j = 0; j < width; j++)
    {
        array[i, j] = random.Next(-2, 10);
        Console.Write("{0,3:D}", array[i, j]);
    }
    Console.WriteLine();
}
Console.WriteLine();

CountPositive(array);

FindMaxRepeating(array, height, width);

NoZerosRows(array, height, width);

WithZerosColumns(array, height, width);

FindRowWithLongestSeries(array, height, width);

ProductOfPositiveNumbersInRows(array, height, width);

MaxSumOfMainDiagonalElements(array, height, width);

SumOfPositiveNumbersInColumns(array, height, width);

MinSumOfSideDiagonalElements(array, height, width);

SumOfElementsInRowWhereNegativeNumberAppear(array, height, width);

TransposedMatrix(array, height, width);

static void TransposedMatrix(int[,] matrix, int height, int width)
{
    if (height == width)
    {
        Console.WriteLine("11. Transposed matrix: ");
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write($"{matrix[j, i],3}");
            }
            Console.WriteLine();
        }
    }
    else
    {
        Console.WriteLine("Height and width must be equal!");
    }
}

static void SumOfElementsInRowWhereNegativeNumberAppear(int[,] matrix, int height, int width)
{
    for (int i = 0; i < height; i++)
    {
        var sum = 0;
        var hasNegative = true;
        for (int j = 0; j < width; j++)
        {
            if (!IsNegativeNumberAppear(matrix, i, width))
            {
                hasNegative = false;
                continue;
            }

            sum += matrix[i, j];
        }
        
        if (hasNegative)
            Console.WriteLine("10.{0} Sum in {1} row: {2}", i+1, i+1,  sum);
        else
            Console.WriteLine("10.{0} Only positive numbers", i+1);
    }
}

static bool IsNegativeNumberAppear(int[,] matrix, int row, int width)
{
    for (int j = 0; j < width; j++)
    {
        if (matrix[row, j] < 0)
        {
            return true;
        }
    }
    return false;
}

static void MinSumOfSideDiagonalElements(int[,] matrix, int height, int width)
{
    int minSum = -999;
    
    for (int i = 0; i < height; i++)
    {
        int currentSum = 0;
        int row = i;
        int col = width - 1;

        while (row < height && col >= 0)
        {
            currentSum += Math.Abs(matrix[row, col]);
            row++;
            col--;
        }

        if (currentSum < minSum)
            minSum = currentSum;
    }

    for (int j = width - 2; j >= 0; j--)
    {
        int currentSum = 0;
        int row = 0;
        int col = j;

        while (row < height && col >= 0)
        {
            currentSum += Math.Abs(matrix[row, col]);
            row++;
            col--;
        }

        if (currentSum < minSum)
            minSum = currentSum;
    }

    Console.WriteLine("9. Min sum of side diagonal elements: {0}", minSum);
}

static void SumOfPositiveNumbersInColumns(int[,] matrix, int height, int width)
{
    for (int j = 0; j < width; j++)
    {
        var sum = 0;
        bool foundNegative = false;
        
        for (int i = 0; i < height; i++)
        {
            
            if (matrix[i, j] < 0)
            {
                foundNegative = true;
                break;
            }
            
            sum += matrix[i, j];
        }
        if (!foundNegative)
            Console.WriteLine("8.{0} Sum of elements in {1} row: {2}", j+1, j+1, sum);
        else
            Console.WriteLine("8.{0} Negative element found in {1} column!", j+1, j+1);
    }
}

static void MaxSumOfMainDiagonalElements(int[,] matrix, int height, int width)
{
    int maxSum = -999;
    for (int i = 0; i < height; i++)
    {
        int currentSum = 0;
        int row = i;
        int col = 0;

        while (row < height && col < width)
        {
            currentSum += matrix[row, col];
            row++;
            col++;
        }

        if (currentSum > maxSum)
            maxSum = currentSum;
    }
    
    for (int j = 1; j < width; j++)
    {
        int currentSum = 0;
        int row = 0;
        int col = j;

        while (row < height && col < width)
        {
            currentSum += matrix[row, col];
            row++;
            col++;
        }

        if (currentSum > maxSum)
            maxSum = currentSum;
    }

    Console.WriteLine("7. Max sum of main diagonal elements: {0}", maxSum);
}

static void ProductOfPositiveNumbersInRows(int[,] matrix, int height, int width)
{
    for (int i = 0; i < height; i++)
    {
        int product = 1;
        bool hasNegative = false;
        
        for (int j = 0; j < width; j++)
        {
            if (matrix[i, j] < 0)
            {
                product = 0;
                break;
            }
            product *= matrix[i, j];
        }
        
        if (!hasNegative)
            Console.WriteLine("6.{0} Product of row {1}: {2}", i+1, i+1, product);
    }
}

static void FindRowWithLongestSeries(int[,] matrix, int height, int width)
{
    var longestSeriesLength = 0;
    var currentSeriesLength = 0;
    var rowWithLongestSeries = -1;

    for (int i = 0; i < height; i++)
    {
        for (int j = 1; j < width; j++)
        {
            if (matrix[i, j] == matrix[i, j - 1])
            {
                currentSeriesLength++;
            }
            else
            {
                currentSeriesLength = 1;
                continue;
            }

            if (currentSeriesLength > longestSeriesLength)
            {
                longestSeriesLength = currentSeriesLength;
                rowWithLongestSeries = i;
            }
        }
    }

    if (rowWithLongestSeries != -1)
    {
        Console.WriteLine("5. Row with longest series index: {0}", rowWithLongestSeries);
    }
    else
    {
        Console.WriteLine("5. Not found");
    }
}

static void WithZerosColumns(int[,] matrix, int height, int width)
{
    var withZeros = 0;
    var column = 0;
    for (int j = 0; j < width; j++)
    {
        bool foundZero = false;
        for (int i = 0; i < height; i++)
        {
            if (matrix[i, column] == 0 && column < width)
            {
                withZeros++;
                column++;
                foundZero = true;
                break;
            }
        }
        if (!foundZero)
            column++;
    }

    Console.WriteLine("4. Columns with zeros: {0}", withZeros);
}

static void NoZerosRows(int[,] matrix, int height, int width)
{
    var noZeros = height;
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (matrix[i, j] == 0)
            {
                noZeros--;
                break;
            }
        }
    }

    Console.WriteLine("3. Lines without zeros: {0}", noZeros);
}

static void FindMaxRepeating(int[,] matrix, int height, int width)
{
    int maxRepeatingElement = -999;
    
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            int currentElement = matrix[i, j];
            
            if (IsRepeating(matrix, height, width, currentElement))
            {
                if (currentElement > maxRepeatingElement)
                {
                    maxRepeatingElement = currentElement;
                }
            }
        }
    }

    Console.WriteLine("2. Repeating max: {0}", maxRepeatingElement);
}

static bool IsRepeating(int[,] matrix, int height, int width, int element)
{
    int count = 0;
    
    for (int i = 0; i < height; i++)
    {
        for (int j = 0; j < width; j++)
        {
            if (matrix[i, j] == element)
            {
                count++;
            }
        }
    }
    return count > 1;
}

static void CountPositive(int[,] matrix)
{
    var count = 0;
    foreach (var number in matrix)
    {
        if (number > 0)
        {
            count++;
        }
    }
    
    Console.WriteLine("1. Positive numbers: {0}", count);
}