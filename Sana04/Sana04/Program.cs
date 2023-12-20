// See https://aka.ms/new-console-template for more information


var height = 7;
var width = 7;
var array = new int[height, width];
var random = new Random();

for (int i = 0; i < height; i++)
{
    Console.WriteLine();
    for (int j = 0; j < width; j++)
    {
        array[i, j] = random.Next(-30, 30);
        Console.Write("{0,4:D}", array[i, j]);
    }
}
Console.WriteLine();

CountPositive(array);

FindMaxRepeating(array, height, width);

NoZerosRows(array, height, width);

WithZerosColumns(array, height, width);

FindRowWithLongestSeries(array, height, width);

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
        Console.WriteLine("Row index: {0}", rowWithLongestSeries);
    }
    else
    {
        Console.WriteLine("Not found");
    }
}

static void WithZerosColumns(int[,] matrix, int height, int width)
{
    var withZeros = 0;
    for (int i = 0; i < width; i++)
    {
        for (int j = 0; j < height; j++)
        {
            if (matrix[i, j] == 0)
            {
                withZeros++;
            }
        }
    }

    Console.WriteLine("Columns with zeros: {0}", withZeros);
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

    Console.WriteLine("Lines without zeros: {0}", noZeros);
}

static void FindMaxRepeating(int[,] matrix, int height, int width)
{
    int maxRepeatingElement = int.MinValue;
    
    for (int i = 0; i < width; i++)
    {
        for (int j = 0; j < height; j++)
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

    Console.WriteLine("Max: {0}", maxRepeatingElement);
}

static bool IsRepeating(int[,] matrix, int height, int width, int element)
{
    int count = 0;
    
    for (int i = 0; i < width; i++)
    {
        for (int j = 0; j < height; j++)
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
    
    Console.WriteLine("Positive numbers: {0}", count);
}