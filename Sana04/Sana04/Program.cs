// See https://aka.ms/new-console-template for more information

var height = 5;
var width = 5;
var array = new int[height, width];
var random = new Random();

for (int i = 0; i < height; i++)
{
    Console.WriteLine();
    for (int j = 0; j < width; j++)
    {
        array[i, j] = random.Next(-10, 10);
        Console.Write("{0,4:D}", array[i, j]);
    }
}