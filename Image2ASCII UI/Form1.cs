using System.Diagnostics;
using System.Text;

namespace Image2ASCII_UI
{
    public partial class Form1 : Form
    {
        private const string brightnessMap = @".'`^,:;Il!i><~+_-?][}{1)(|\/tfjrxnuvczXYUJCLQ0OZmwqpdbkhao*#MW&8%B@$";

        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists($"output.txt"))
                File.Delete($"output.txt");

            if (!File.Exists(path.Text))
            {
                MessageBox.Show("Cannot find the file specified.");
                return;
            }

            float multiplierInt;
            try
            {
                float.Parse(multiplier.Text);
            }
            catch
            {
                MessageBox.Show("Please enter a valid multiplier.");
                return;
            }
            multiplierInt = float.Parse(multiplier.Text);

            Image image = Image.FromFile(path.Text);
            Bitmap scaledImage = new(image, new Size((int)(image.Width * multiplierInt), (int)(image.Height * multiplierInt)));

            float strecthFactor = 2f;

            Bitmap stretchedImage = new Bitmap((int)(scaledImage.Width * strecthFactor), (int)(scaledImage.Height * strecthFactor));
            using (Graphics g = Graphics.FromImage(stretchedImage))
            {
                g.ScaleTransform(strecthFactor, 1.0f);
                g.DrawImage(scaledImage, 0, 0);
            }

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

            var text = File.CreateText($"output.txt");

            text.Write(stringBuilder.ToString());

            text.Close();

            Process.Start("CMD.exe", $"/C start output.txt");
        }

        private void multiplier_TextChanged(object sender, EventArgs e)
        {
        }
    }
}