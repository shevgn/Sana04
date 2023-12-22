// See https://aka.ms/new-console-template for more information


var height = 6;
var width = 4;
var array = new int[height, width];
var random = new Random();

for (int i = 0; i < height; i++)
{
    Console.WriteLine();
    for (int j = 0; j < width; j++)
    {
        array[i, j] = random.Next(-2, 10);
        Console.Write("{0,4:D}", array[i, j]);
    }
}
Console.WriteLine();

CountPositive(array);

FindMaxRepeating(array, height, width);

NoZerosRows(array, height, width);

WithZerosColumns(array, height, width);

FindRowWithLongestSeries(array, height, width);

ProductOfRowsWithNoNegativeNumbers(array, height, width);



static void ProductOfRowsWithNoNegativeNumbers(int[,] matrix, int height, int width)
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
            Console.WriteLine("Product of row {0}: {1}", i+1, product);
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
        Console.WriteLine("Row with longest series index: {0}", rowWithLongestSeries);
    }
    else
    {
        Console.WriteLine("Not found");
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