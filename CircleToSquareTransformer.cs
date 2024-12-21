using System;
using System.Drawing;

namespace CircleToSquare
{
    class CircleToSquareTransformer
    {
        public static Bitmap TransformToEllipse(string inputImagePath, string outputImagePath)
        {
            Bitmap inputImage = new(inputImagePath);
            Bitmap outputImage = TransformToEllipse(inputImage);
            outputImage.Save(outputImagePath);
            return outputImage;
        }

        public static Bitmap TransformToEllipse(string filename)
        {
            Bitmap inputImage = new(filename);
            Bitmap outputImage = TransformToEllipse(inputImage);
            return outputImage;
        }

        public static Bitmap TransformToEllipse(Bitmap inputImage)
        {
            int width = inputImage.Width;
            int height = inputImage.Height;

            Bitmap outputImage = new(width, height);
            int centerX = width / 2;
            int centerY = height / 2;

            double radiusX = width / 2.0;
            double radiusY = height / 2.0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    double normX = (x - centerX) / radiusX;
                    double normY = (y - centerY) / radiusY;
                    double distance = Math.Sqrt(normX * normX + normY * normY);

                    double squareX = normX * Math.Sqrt(1 - (normY * normY / 2));
                    double squareY = normY * Math.Sqrt(1 - (normX * normX / 2));

                    int sourceX = (int)(squareX * radiusX + centerX);
                    int sourceY = (int)(squareY * radiusY + centerY);

                    sourceX = Math.Clamp(sourceX, 0, width - 1);
                    sourceY = Math.Clamp(sourceY, 0, height - 1);

                    outputImage.SetPixel(x, y, inputImage.GetPixel(sourceX, sourceY));
                }
            }

            return outputImage;
        }
    }
}
