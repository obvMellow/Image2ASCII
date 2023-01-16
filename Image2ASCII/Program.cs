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

            int outputIndex = 0;

            if (Directory.Exists("output"))
                Directory.Delete("output", true);

            Directory.CreateDirectory("output");
            Directory.SetCurrentDirectory("output");

            while (true)
            {
                if (File.Exists($"output{outputIndex}.txt"))
                    File.Delete($"output{outputIndex}.txt");

                string input;
                float sizeMultiplier;
                if (args.Length == 0)
                {
                    Console.Write("\nEnter the path to the image: ");
                    input = Console.ReadLine();
                    Console.Write("Enter the size multiplier (according to console size): ");
                    string size = Console.ReadLine();
                    size = size == "" ? "1" : size;
                    sizeMultiplier = float.Parse(size);
                }
                else
                {
                    input = args[0];
                    sizeMultiplier = float.Parse(args[1]);
                }

                if (!File.Exists(input) || input == "")
                {
                    PrintlnColored("[ERROR] Input file doesn't exitst!", ConsoleColor.Red, (1, 6));
                    continue;
                }

                PrintlnColored("\n[INFO] Resizing image...", ConsoleColor.Yellow, (2, 6));

                var originalImage = new Bitmap(input);

                float imageAspectRatio = originalImage.Width / (float)originalImage.Height;
                float consoleAspectRatio = Console.WindowWidth / (float)Console.WindowHeight;

                int newWidth;
                int newHeight;
                if (imageAspectRatio > consoleAspectRatio)
                {
                    // Image is wider than console, so scale based on width
                    newWidth = (int)(Console.WindowWidth * sizeMultiplier);
                    newHeight = (int)(Console.WindowWidth / imageAspectRatio * sizeMultiplier);
                }
                else
                {
                    // Image is taller than console, so scale based on height
                    newWidth = (int)(Console.WindowHeight * imageAspectRatio * sizeMultiplier);
                    newHeight = (int)(Console.WindowHeight * sizeMultiplier);
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
                stretchedImage.Save($"output{outputIndex} debug.png");
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

                if (sizeMultiplier <= 1)
                {
                    Console.WriteLine();
                    Console.Write(stringBuilder.ToString());
                }

                var text = File.CreateText($"output{outputIndex}.txt");

                text.Write(stringBuilder.ToString());

                text.Close();

                PrintlnColored($"\n[SUCCESS] Created the output int 'output{outputIndex}.txt'", ConsoleColor.Green, (2, 9));

                Console.ReadKey(true);

                outputIndex++;
            }
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