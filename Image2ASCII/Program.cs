using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace Image2ASCII
{
    internal class Program
    {
        private const string brightnessMap = @".'`^,:;Il!i><~+_-?][}{1)(|\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";

        private static void Main(string[] args)
        {
            PrintlnColored("[INFO] Cleaning up.", ConsoleColor.Yellow, (1, 5));

            if (File.Exists("output.txt"))
            {
                File.Delete("output.txt");
            }

            string input;
            if (args.Length == 0)
            {
                Console.Write("\nEnter the path to the image: ");
                input = Console.ReadLine();
            }
            else
            {
                input = args[0];
            }

            if (!File.Exists(input) || input == "")
            {
                PrintlnColored("[ERROR] Input file doesn't exitst!", ConsoleColor.Red, (1, 6));
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey(true);
                return;
            }

            PrintlnColored("[INFO] Resizing image...", ConsoleColor.Yellow, (1, 5));

            var originalImage = new Bitmap(input);

            float imageAspectRatio = originalImage.Width / (float)originalImage.Height;
            float consoleAspectRatio = Console.WindowWidth / (float)Console.WindowHeight;

            int newWidth;
            int newHeight;
            if (imageAspectRatio > consoleAspectRatio)
            {
                // Image is wider than console, so scale based on width
                newWidth = Console.WindowWidth;
                newHeight = (int)(Console.WindowWidth / imageAspectRatio);
            }
            else
            {
                // Image is taller than console, so scale based on height
                newWidth = (int)(Console.WindowHeight * imageAspectRatio);
                newHeight = Console.WindowHeight;
            }

            Bitmap scaledImage = new Bitmap(originalImage, new Size(newWidth, newHeight));

            float strecthFactor = 2f;

            Bitmap stretchedImage = new Bitmap((int)(scaledImage.Width * strecthFactor), (int)(scaledImage.Height * strecthFactor));
            using (Graphics g = Graphics.FromImage(stretchedImage))
            {
                g.ScaleTransform(strecthFactor, 1.0f);
                g.DrawImage(scaledImage, 0, 0);
            }

#if DEBUG
            stretchedImage.Save("output.jpg");
#endif

            PrintlnColored("[INFO] Converting to ascii...", ConsoleColor.Yellow, (1, 5));

            StringBuilder stringBuilder = new StringBuilder();

            for (int y = 0; y < stretchedImage.Height / 2; y++)
            {
                for (int x = 0; x < stretchedImage.Width; x++)
                {
                    int bIndex = (int)(stretchedImage.GetPixel(x, y).GetBrightness() * brightnessMap.Length);

                    if (bIndex < 0)
                    {
                        bIndex = 0;
                    }
                    else if (bIndex >= brightnessMap.Length)
                    {
                        bIndex = brightnessMap.Length - 1;
                    }

                    stringBuilder.Append(brightnessMap[bIndex]);
                }
                stringBuilder.AppendLine();
            }

            if (File.Exists("output.txt"))
                File.Delete("output.txt");

            Console.WriteLine();
            Console.Write(stringBuilder.ToString());

            var text = File.CreateText("output.txt");

            text.Write(stringBuilder.ToString());

            PrintlnColored("\n[SUCCESS] Created the output int 'output.txt'", ConsoleColor.Green, (2, 9));

            text.Close();

            Console.ReadKey(true);
        }

        private static void PrintlnColored(string text, ConsoleColor color, (int startIndex, int endIndex) position)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (i == position.startIndex)
                {
                    Console.ForegroundColor = color;
                }

                if (i == position.endIndex)
                {
                    Console.ResetColor();
                }

                Console.Write(text[i]);
            }

            Console.WriteLine();
        }
    }
}