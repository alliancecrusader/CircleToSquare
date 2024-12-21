using System;

namespace CircleToSquare
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputImagePath = args[0];
            string outputImagePath = args[1];

            try
            {
                CircleToSquareTransformer.TransformToEllipse(inputImagePath, outputImagePath);
                Console.WriteLine($"Successfully transformed {inputImagePath} to {outputImagePath}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}